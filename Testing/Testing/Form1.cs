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
        player newChar = new player(Testing.Properties.Resources.mc);

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }

 

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                newChar.move("W");
            }
            else if (e.KeyCode == Keys.Right)
            {
                newChar.move("E");
            }
            else if (e.KeyCode == Keys.Up)
            {
                newChar.move("N");
            }
            else if (e.KeyCode == Keys.Down)
            {
                newChar.move("S");
            }
            newChar.draw(ref panel1);
        }
    }
}
