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
        Game newGame;

        public Form1()
        {
            InitializeComponent();
            this.Focus();
            this.KeyPress += new KeyPressEventHandler(KeyPressingMethod);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            newGame = new Game(panel1);

        }

        private void KeyPressingMethod(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            newGame.move(Char.ToUpper(e.KeyChar).ToString());
            //newGame.draw();
            e.Handled = true;
        }
    }
}
