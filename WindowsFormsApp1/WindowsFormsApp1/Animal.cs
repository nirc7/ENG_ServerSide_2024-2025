using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    abstract internal class Animal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        //public virtual string MakeSound()
        //{
        //    return "???";
        //}

        public abstract string MakeSound();
        
    }

    class Dog : Animal
    {
        public bool HasBone { get; set; }

        public override string MakeSound() { return "Bark"; }
    }

    class Cat : Animal
    {
        public int NumOfLives { get; set; }
        public override string MakeSound()
        {
            return "meow";
        }
    }
}
