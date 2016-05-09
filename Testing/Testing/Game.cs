using System;
using System.Threading;
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
        public Thread drawThread;
        public System.Timers.Timer aTimer;
        System.Diagnostics.Stopwatch gameWatch;
        public Boolean isOver;



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
            MainCharacter = new Player(Properties.Resources.Char, 99999);
            //    MainCharacter.setPriority(99999);
            listOfObjectsInGame = new List<InteractableObject>();
            this.isOver = false;
            this.init();
        }

        private void init()
        {
            // Initialization function

            item = new Item(Properties.Resources.pokeball, 1);
            //    item.setPriority(1);
            item.setX(300);
            item.setY(10);
            MainCharacter.setX(0);
            MainCharacter.setY(500);
            item.pass();
            listOfObjectsInGame.Add(MainCharacter);
            listOfObjectsInGame.Add(item);
            listOfObjectsInGame.Sort(ComparePriorities);

            //for (int i = 0; i < listOfObjectsInGame.Count; i++)
            //{
            //Console.WriteLine(listOfObjectsInGame.ElementAt(i).priorityValueIs());
            //}
            drawThread = new Thread(moveThings);
            drawThread.Start();

        }

        public void draw()
        {
            Graphics g = targetPanel.CreateGraphics();
            g.Clear(Color.White);
            g.DrawImage(Properties.Resources.background, 0, 0);

            //Console.WriteLine(listOfObjectsInGame.Count);
            for (int i = 0; i < listOfObjectsInGame.Count; i++)
            {
                listOfObjectsInGame.ElementAt(i).draw(g);
            }
            //            MainCharacter.drawTwo(g);
        }

        public void gameOver()
        {
            //Console.WriteLine("Collision");
            this.isOver = true;
            Graphics g = targetPanel.CreateGraphics();
            Font dank = new Font("Comic Sans", 12, FontStyle.Bold);
            SolidBrush testBrush = new SolidBrush(Color.Aquamarine);
            g.Clear(Color.White);
            g.DrawImage(Properties.Resources.sadpika, 0, 0);
            g.DrawString("You have lost. :(", dank, testBrush, 10, 10);
            gameWatch.Stop();
            TimeSpan totalTime = gameWatch.Elapsed;
            String time = "" + totalTime.Minutes + " hours " + totalTime.Seconds + " seconds " + totalTime.Milliseconds + " milliseconds";
            g.DrawString("Time Elapsed: " + time, dank, testBrush, 10, 50);
            aTimer.Stop();
            aTimer.Dispose();
        }
        public void moveThings()
        {
            gameWatch = new System.Diagnostics.Stopwatch();
            gameWatch.Start();
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += myTimer_Elapsed;
            aTimer.Interval = 100;
            aTimer.Enabled = true;
            aTimer.Start();


            /*            System.Threading.Timer aTimer = 
                            new System.Threading.Timer((TimerCallback)delegate
                        {
                            moveEnvironment();
                            Console.WriteLine("Hello World!");
                            this.draw();
                        }, null, 1000, 1000);*/

        }
        private void myTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.isCollide(this.MainCharacter, this.item))
                this.gameOver();
            else
            {
                if (gameWatch.ElapsedTicks % 1000 == 0)
                {
                    moveEnvironment();
                }
                this.draw();
            }
        }

        public void moveEnvironment()
        {
            for (int i = 0; i < 10; i++)
                listOfObjectsInGame.ElementAt(1).move("W");
        }

        public void move(String direction)
        {
            InteractableObject a = this.MainCharacter;
            InteractableObject b = this.item;

            if (direction == "W")
                direction = "N";
            else if (direction == "A")
                direction = "W";
            else if (direction == "D")
                direction = "E";

            if (this.isCollide(a, b) == true)
            {
                /* Commenting out code that bumps you back!
                if (direction == "W")
                {
                    direction = "E";
                }
                else if (direction == "E")
                {
                    direction = "W";
                }
                else if (direction == "N")
                {
                    direction = "S";
                }
                else if (direction == "S")
                {
                    direction = "N";
                }
                */
                this.gameOver();
            }
            else
            {
                this.MainCharacter.move(direction);
            }

        }
        private Boolean isCollide(InteractableObject a, InteractableObject b)
        {
            Boolean output = false;
            if ((a.getX() < b.getX()) & (b.getX() < (a.getX() + a.getWidth()))
                || (b.getX() < a.getX() & (b.getX() + b.getWidth() > a.getX())))
            {
                if ((a.getY() < b.getY()) & (b.getY() < (a.getY() + a.getHeight()))
                || (b.getY() < a.getY() & (b.getY() + b.getHeight() > a.getY())))
                    output = true;
            }



            return output;
        }

    }
}
