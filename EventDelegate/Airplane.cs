using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventDelegate
{
    public class Airplane
    {
        public delegate void InfoHandler(string mes, string name);
        private static event InfoHandler _info;
        public static event InfoHandler Info
        {
            add
            {
                _info += value;
                Console.WriteLine(value.Method.Name + " add handler");
            }
            remove
            {
                _info -= value;
                Console.WriteLine(value.Method.Name + " remove handler");
            }
        }
        private string Name { get; set; }
        public int Duration { get; private set; } = 1000;
        public Airplane(string name)
        {
            Name = name;
        }
        public void SetFly(int d)
        {
            Duration = d;
        }
        private void Fly()
        {
            _info?.Invoke("Start fly " + DateTime.Now.TimeOfDay.ToString(), this.Name);
            Thread.Sleep(Duration);
            _info?.Invoke("End of fly " + DateTime.Now.TimeOfDay.ToString(), this.Name);
        }
        public async Task FlyAsync()
        {
            await Task.Run(() => Fly());
        }
    }
}
