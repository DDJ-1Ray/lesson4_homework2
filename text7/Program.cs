using System;

namespace text7
{
    public delegate void ClockHander(object sender,ClockEventArgs args);
    public class ClockEventArgs
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        
    }
    public class Clock
    {
        public event ClockHander Tick;
        public event ClockHander Alarm;
        public int hour;
        public int minute;
      
        public Clock(int h,int m)//初始化時間
        {
            this.hour = h;
            this.minute = m;
        }
        public void tick()
        {
            minute++;
            if (minute > 60)
            {
                hour++;
                minute = 0;
            }
            if (hour > 24)
            {
                minute = 0;
                hour = 0;
            }
            ClockEventArgs args = new ClockEventArgs()
            {
                Hour = hour,
                Minute = minute
            };
            Tick(this,args);
        }
        public void alarm(int h, int m)
        {
            //Console.WriteLine("這一波只能說和程序配合的不好");
            if (hour == h&&minute == m){
                ClockEventArgs args = new ClockEventArgs()
                {
                    Hour =h,
                    Minute = m
                };
                Alarm(this, args);
            }
        }
    }
    public class Form
    {
        public Clock alarmclock1 = new Clock(0,0);
        public Form()
        {
            //ClockHander DLC = new ClockHander(ClockTick);
            //DLC += new ClockHander(ClockAlarm);
            alarmclock1.Tick += new ClockHander(ClockTick);
            alarmclock1.Alarm += new ClockHander(ClockAlarm);
        }
        void ClockTick(object sender,ClockEventArgs args)
        {
            //while (true)
            //{
            //    Console.WriteLine("trick");
            //    if()
            //}
            
            Console.WriteLine($"Tick...{args.Hour}:{args.Minute}");
        }
        void ClockAlarm(object sender,ClockEventArgs args)
        {
            Console.WriteLine("Ring...Ring...");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            Console.WriteLine("設置時間:");
            int sethour = Int32.Parse(Console.ReadLine());
            int setminute = Int32.Parse(Console.ReadLine());
            while (true)
            {
                //
                //form.alarmclock1.tick();
                form.alarmclock1.tick();
                form.alarmclock1.alarm(sethour, setminute);
                System.Threading.Thread.Sleep(1000);
            }
            
        }
    }
}
