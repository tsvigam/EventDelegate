using System;
using System.Threading;
using System.IO;
using System.Threading.Tasks;

namespace EventDelegate
{
    class Program
    {
        static object locker = new object();
        static void Main(string[] args)
        {
            Airplane boeng = new Airplane("Boeng");
            Airplane.Info += DisplayInfo; // just methods
            Airplane.Info += FileInfo;
            Airplane.Info += delegate (string mes, string name) //anonymous methods
            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(mes + " from anonim method");
                                Console.ForegroundColor = ConsoleColor.White;
                            };
            Airplane.Info += (mes, name) => Console.WriteLine(mes + " from lambda"); //lambda sequence
            boeng.SetFly(5000);
            boeng.FlyAsync();

            //  boeng.Info -= DisplayInfo;
            //  boeng.SetFly(1000);
            //  boeng.Fly();
            Airplane airtube = new Airplane("Airtube");
            airtube.SetFly(4000);
            airtube.FlyAsync();
            Console.ReadLine();
        }

        private static void FileInfo(string mes, string name)
        {
            Logger L = Logger.GetLogger();
            lock (locker)
            {
                StreamWriter writer = new StreamWriter(L.FileName, true);
                writer.WriteLine(mes + " in " + name);
                writer.Close();
                writer.Dispose();
            }
        }

        private static void DisplayInfo(string mes, string name)
        {
            Console.WriteLine(mes + " in " + name);
        }
    }
}
