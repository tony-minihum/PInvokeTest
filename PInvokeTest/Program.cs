using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace PInvokeTest
{
  class Program
  {
    static void Main(string[] args)
    {
        print_line("Hello PInvoke!!!");
        Console.WriteLine();

        var buf = new StringBuilder(5);
        var bufCanary = new StringBuilder(5);
        get_string(buf, buf.Capacity);

        Console.WriteLine("buf:" + buf + "[EOB] " + buf.Capacity);
        Console.WriteLine("canary:" + bufCanary + "[EOB]" + bufCanary.Capacity);

        var intBuf = new int[5];
        var intBufCanary = new int[5];
        takes_an_int_array(intBuf, intBuf.Length);

        for (int i = 0; i < intBuf.Length; i++)
        {
            Console.WriteLine("intBuf:" + intBuf[i] + "[EOB] " + intBuf.Length);
        }
        for (int i = 0; i < intBufCanary.Length; i++)
        {
            Console.WriteLine("canary:" + intBufCanary[i] + "[EOB]" + intBufCanary.Length);
        }

        Console.WriteLine("\n\nPress any key...");
        Console.ReadKey();
    }

    [DllImport("NativeLib.dll")]
    private static extern void print_line(string str);

    [DllImport("NativeLib.dll")]
    private static extern void get_string(StringBuilder buf, int len);

      [DllImport("NativeLib.dll")]
    private static extern void takes_an_int_array(int[] intArray, int len);
  }
}
