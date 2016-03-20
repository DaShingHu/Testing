using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Testing
{
    class Game
    {
        List<InteractableObject> listOfObjectsInGame;
        Panel targetPanel;
        public Player MainCharacter;
        public Item item;
        

        private static int ComparePriorities(InteractableObject x, InteractableObject y)
        {
            // Compares the priorities of two objects, x and y
            // If x's priority is greater than y, then you must return a number greater than 0
            // If same priority, then return 0
            // If x's priority is less than y, then you must return a number less than 0.

            int output;
            if (x == null && y == null)
            {
                output = 0;
            }
            else if (x == null && y != null)
            {
                // If x is null and y is not null, y must have a higher priority than x
                output = -1;
            }
            else if (x != null && y == null)
            {
                // If x is not null but y is null, then x must have a higher proirity than y
                output = 1;
            }
            else
            {
                if (x.priorityValueIs() > y.priorityValueIs())
                {
                    output = 1;
                }
                else if (x.priorityValueIs() < y.priorityValueIs())
                {
                    output = -1;
                }
                else
                {
                    output = 0;
                }
            }
            return output;
        }
        public Game()
        {
            targetPanel = null;
            listOfObjectsInGame = new List<InteractableObject>();
        }
        public Game(Panel target)
        {
            targetPanel = target;
            MainCharacter = new Player(Properties.Resources.Char,99999);
        //    MainCharacter.setPriority(99999);
            listOfObjectsInGame = new List<InteractableObject>();
            this.init(); 
        }

        private void init()
        {
            // Initialization function

            item = new Item(Properties.Resources.pokeball,1);
        //    item.setPriority(1);
            item.setX(100);

            listOfObjectsInGame.Add(MainCharacter);
            listOfObjectsInGame.Add(item);
            listOfObjectsInGame.Sort(ComparePriorities);

            for (int i = 0; i < listOfObjectsInGame.Count; i++)
            {
                Console.WriteLine(listOfObjectsInGame.ElementAt(i).priorityValueIs());
            }
        }
        
        public void draw()
        {
            Graphics g = targetPanel.CreateGraphics();
            g.Clear(Color.White);
            g.DrawImage(Properties.Resources.background, 0, 0);
            
            Console.WriteLine(listOfObjectsInGame.Count);
            for (int i = 0; i < listOfObjectsInGame.Count ; i++)
            {
                listOfObjectsInGame.ElementAt(i).draw(g);
            }
//            MainCharacter.drawTwo(g);
        }
    }
}
