using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Testing
{
    class player
    {
        Bitmap self;
        int x;
        int y;

        public player()
        {
            // Default constructor
            self = new Bitmap(64, 64);
        }
        public player(Image inputImage)
        {
            self = new Bitmap(inputImage);
            this.x = 0;
            this.y = 0;
        }

        public void move (String direction)
        {
            // E = +1
            // W = -1
            // N = +1
            // S = -1
            if (direction == "E")
            {
                this.x++;
            }
            else if (direction == "W")
            {
                this.x--;
            }
            else if (direction == "N")
            {
                this.y++;
            }
            else
            {
                this.y--;
            }
        }
        public void draw(Panel target) {

            Graphics g = target.CreateGraphics();
            g.DrawImage(this.self, this.x, this.y);
        }
    }
}
