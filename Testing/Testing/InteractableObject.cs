using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Testing
{
    abstract class InteractableObject
    {
        // Priority is largest numbers = last drawn
        private int priority;
        abstract public void draw(Graphics g);
        abstract public int priorityValueIs();
    }
}
