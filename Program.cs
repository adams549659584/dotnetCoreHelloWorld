using System.Text;
using System.IO;
using System.Timers;
using System;

namespace Hello
{
  class Program
  {
    static Timer tim = new Timer(1000 * 1);

    static void Main(string[] args)
    {
      Console.WriteLine("开始");
      tim.Elapsed += TimElapsed;
      tim.Start();
      Console.WriteLine("计数器开始");
      var key = Console.ReadLine();
      while (key != "exit")
      {
        key = Console.ReadLine();
      }
      Console.WriteLine("结束");
    }

    static void TimElapsed(object sender, ElapsedEventArgs e)
    {
      var fullPath = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName, "log");
      if (!Directory.Exists(fullPath))
      {
        Directory.CreateDirectory(fullPath);
      }
      var fullName = Path.Combine(fullPath, string.Format("{0}.log", DateTime.Now.ToString("yyyyMMddHHmmssfff")));
      using (StreamWriter sw = new StreamWriter(fullName, true, Encoding.UTF8))
      {
        var log = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        Console.WriteLine(log);
        sw.WriteLine(log);
      }
    }
  }
}
