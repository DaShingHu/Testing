using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Testing
{
    class player : InteractableObject
    {
        Bitmap self;
        private int x;
        private int y;
        private int priority;

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

        public void setX(int input)
        {
            // Sets x value
            this.x = input;
        }
        public void setY(int input)
        {
            this.y = input;
        }
        public void setPriority(int input)
        {
            this.priority = input;
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
                this.y--;
            }
            else if (direction == "S")
            {
                this.y++;
            }
        }
        // This means to implement the method
        public override void draw(Graphics g)
        {
            g.DrawImage(this.self, this.x, this.y);
        }
        public override int priorityValueIs()
        {
            return this.priority;
        }
        
        public void drawTwo(Graphics g)
        {
            g.DrawImage(this.self, this.x, this.y);
        }
    }
}
