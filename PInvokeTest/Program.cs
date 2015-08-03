using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace PInvokeTest
{
    interface IManagedStruct
    {
        int getA();
    }

    struct ManagedStruct : IManagedStruct
    {
        public int A { get; set; }
        public int B { get; set; }
        public int getA() { return A; }
    }

    class ManagedStructWrapper
    {
        public IManagedStruct ManagedStruct { get; set; }
    }

    [StructLayout(LayoutKind.Sequential)] // これがないと中身をダンプしてもあんまり意味ない
    class ManagedClass
    {
        public int A { get; set; }
        public int B { get; set; }

        public ManagedClass()
        {
            A = 0;
            B = 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            print_line("Hello PInvoke!!!");
            Console.WriteLine();

            var buf = new StringBuilder(5);
            var bufCanary = new StringBuilder(5);
            get_string(buf, buf.Capacity );

            Console.WriteLine("buf:" + buf + "[EOB] " + buf.Capacity);
            Console.WriteLine("canary:" + bufCanary + "[EOB] " + bufCanary.Capacity);

            var intBuf = new int[5];
            var intBufCanary = new int[5];
            takes_an_int_array(intBuf, intBuf.Length + 5);

            for (int i = 0; i < intBuf.Length; i++)
            {
                Console.WriteLine("intBuf:" + intBuf[i] + "[EOB] " + intBuf.Length);
            }
            for (int i = 0; i < intBufCanary.Length; i++)
            {
                Console.WriteLine("canary:" + intBufCanary[i] + "[EOB] " + intBufCanary.Length);
            }


            // class や struct を native に渡して、アドレスとか中身を見てみる
            var managedClass = new ManagedClass();
            managed_ptr_class(managedClass);
            var managedClass2 = new ManagedClass() { A = 1, B = 0xFF, };
            managed_ptr_class(managedClass2);
            var managedClass3 = new ManagedClass() { A = 0xFF, B = 0xFF, };
            managed_ptr_class(managedClass3);

            var managedStruct = new ManagedStruct();
            managed_ptr_struct(ref managedStruct);
            var managedStruct2 = new ManagedStruct() { A = 1, B = 0xEE, };
            managed_ptr_struct(ref managedStruct2);
            var managedStruct3 = new ManagedStruct() { A = 0xFF, B = 0xFFFF, };
            managed_ptr_struct(ref managedStruct3);

            // Boxsing っぷりをみたかったけど、msw.ManagedStruct をそのままは渡せないのかも？
            var msw = new ManagedStructWrapper();
            var ms = new ManagedStruct()  { A = 1, B = 2, }; 
            msw.ManagedStruct = ms;
            managed_ptr_struct(ref ms);
            var ms2 = (ManagedStruct)msw.ManagedStruct;
            managed_ptr_struct(ref ms2);

            Console.WriteLine("\n\nPress any key...");
            Console.ReadKey();
        }

        [DllImport("NativeLib.dll")]
        private static extern void print_line(string str);

        [DllImport("NativeLib.dll")]
        private static extern void get_string(StringBuilder buf, int len);

        [DllImport("NativeLib.dll")]
        private static extern void takes_an_int_array(
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] intArray,
            int len
            );

        [DllImport("NativeLib.dll")]
        private static extern void managed_ptr_class(ManagedClass managedObject);

        [DllImport("NativeLib.dll")]
        private static extern void managed_ptr_struct(ref ManagedStruct managedObject);
    }
}
