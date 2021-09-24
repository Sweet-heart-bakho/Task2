using System;

namespace _2._1
{
    class Man
    {
        protected uint age;
        protected string name;

        public Man(string name)
        {
            Name = name;
        }
        public Man(string name, uint age)
        {
            Name = name;
            Age = age;
        }

        private uint Age { set { age = value; } }

        public string Name
        {
            get { return name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException();
                name = value;
            }
        }
        public virtual void ChangeAge(uint age) => Age = age;
        public virtual void ChangeName(string name) => Name = name;

        public virtual void WriteToConsoleInfo()
        {
            Console.WriteLine($"Человек, {{{name}}}, {{{age}}}");
        }
    }

    class Teenager : Man
    {

        private string school;
        public string School { set { school = value; } }
        public Teenager(string name, uint age, string school) : base(name)
        {
            Age = age;
            School = school;
        }

        public uint Age
        {
            get { return age; }
            set
            {
                if (value >= 13 && value <= 19)
                {
                    age = value;
                }
                else { Console.WriteLine("Возраст может быть только от 13 до 19"); }
            }
        }

        public override void ChangeAge(uint age) => Age = age;
        public override void WriteToConsoleInfo()
        {
            Console.WriteLine($"Подросток, {{{name}}}, {{{age}}}, Место учебы: {{{school}}}");
        }
    }

    class Worker : Man
    {
        public Worker(string name, uint age, string work_place) : base(name)
        {
            Age = age;
            WorkPlace = work_place;
        }

        public uint Age
        {
            get { return age; }
            set
            {
                if (value >= 16 && value <= 70)
                {
                    age = value;
                }
                else { Console.WriteLine("Возраст может быть только от 16 до 70"); }
            }
        }
        string work_place;
        private string WorkPlace { set { work_place = value; } }

        public override void ChangeAge(uint age) => Age = age;
        public override void WriteToConsoleInfo()
        {
            Console.WriteLine($"Работник, {{{name}}}, {{{age}}}, Место работы: {{{work_place}}}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("--------Class Man--------");

            Man man = new Man("Worker");
            man.ChangeAge(22);
            man.WriteToConsoleInfo();

            Console.WriteLine("--------Class Teenager--------");

            Teenager teenager = new Teenager("Teenager", 20, "Mayami");
            teenager.ChangeAge(17);
            teenager.WriteToConsoleInfo();

            Console.WriteLine("--------Class Worker--------");

            Worker worker = new Worker("Worker", 25, "P&G");
            worker.ChangeAge(26);
            worker.WriteToConsoleInfo();
        }
    }
}
