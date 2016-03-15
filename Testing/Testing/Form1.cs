using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing
{
    public partial class Form1 : Form
    {
        player newChar = new player(Testing.Properties.Resources.kanye);

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

 

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Hello!");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Round 2");
            newChar.move("E");
            newChar.draw(panel1);
        }
    }
}
