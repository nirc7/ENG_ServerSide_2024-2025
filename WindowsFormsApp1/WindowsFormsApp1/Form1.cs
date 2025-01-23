using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSayHello_Click(object sender, EventArgs e)
        {
            string input = txtName.Text;
            input = "Hello " + input;
            lblRes.Text = input;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region Polymorphism
            Person p1 = new Person() { Id = 7, Name = "avi" };
            lblOuput.Text = p1.Show() + "\n";

            Student s1 = new Student() { Id = 8, Name = "benny", Grade = 100 };
            lblOuput.Text += s1.Show() + "\n\n\n" ;
            //reference x = new Object()
            Person p2 = new Student(); 
            //p2.id
            //Student s2 = new Person(); //ERROR
            //s2.

            Random rnd = new Random();
            Person p3;
            if (rnd.Next(1, 100) % 2 == 0)
            {
                p3 = new Person() { Id = 29, Name = "cahlrie" };
            }
            else
            {
                p3 = new Student() { Id = 39, Name = "nir", Grade=77 };
            }



            Person[] persons = new Person[] {
                p1,
                s1,
                new Person() {Id=5, Name="Dora" },
                new Student(){Id=20, Name="Gil", Grade=200 },
                p3,
                new SuperStudent(){Id=20, Name="nathan", Grade=150 , Bonus=true},
            };

            foreach (var per in persons)
            {
                lblOuput.Text += per.Show() + "\n";
            }

            #endregion

            #region Abstract

            Animal[] zoo = new Animal[] {
                new Dog(){ID=1, Name="Snoopy", HasBone=true    },
                new Cat(){ID=2, Name="garfield", NumOfLives=9 },
                //new Animal(){ID=3, Name="ET", Age=20 }
            };

            foreach (var ani in zoo)
            {
                lblAnimals.Text += ani.MakeSound() + "\n";
            }

            #endregion
        }
    }
}
