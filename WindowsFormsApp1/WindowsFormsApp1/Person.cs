using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Person
    {
        int id;
        public int Id
        {
            get { return id * 7; }
            set
            {
                if (0 < value && value <= 100)
                {
                    id = value;
                }
                else
                {
                    throw new InvalidOperationException("Wornd Id Go 2 SCholol!");
                }
            }
        }
        public string Name { get; set; }


        public Person()
        {
            Id = 1;
            Name = "no name";
        }

        public virtual string Show()
        {
            return $"{Id}, {Name}";
        }
    }

    class Student : Person
    {
        public int Grade { get; set; }


        public override string Show()
        {
            return base.Show() + $", {Grade}";
        }
    }

    class SuperStudent : Student
    {
        public bool Bonus { get; set; }

        public override  string Show()
        {
            return base.Show() + $"{Bonus}";
        }
    }
}
