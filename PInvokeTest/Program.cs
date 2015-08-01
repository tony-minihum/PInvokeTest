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

        Console.WriteLine("\n\nPress any key...");
        Console.ReadKey();
    }

    [DllImport("NativeLib.dll")]
    private static extern void print_line(string str);
  }
}
