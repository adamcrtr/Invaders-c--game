using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Invaders
{
    class Invader
    {

        public double Health {  get; private set; }
        public double OriginalHealth;
        public Rectangle HealthBar;
        public PictureBox PictureBox = new PictureBox();
        public int Speed = 2;
        static int Drop ; // Invader
        public static bool[] IRight = new bool[Game.NumOfInvaders + 1]; // Invader
        static int x;
        
        //setting each invader depending on what level 
        public Invader(string EnemyType)
        {
            
            this.PictureBox.Name = "Invader";
            this.PictureBox.Visible = true;
            this.PictureBox.BringToFront();

            if (EnemyType == "normal")
            {
                this.Health = 100;
                this.OriginalHealth = 100;
                this.Speed = 5;
                this.PictureBox.Image = Resources.fpeasant;
                this.PictureBox.Width = Resources.fpeasant.Width;
                this.PictureBox.Height = Resources.fpeasant.Height;
                this.PictureBox.BackColor = Color.Transparent;
                //changes background image depending on level
                Game.MainWindow.BackgroundImage = Resources.level1;
                


            }
            else if (EnemyType == "boss")
            {
                this.Health = 200;
                this.OriginalHealth = 200;
                this.Speed = 5;
                this.PictureBox.Image = Resources.farcher;
                this.PictureBox.Width = Resources.farcher.Width;
                this.PictureBox.Height = Resources.farcher.Height;
                this.PictureBox.BackColor = Color.Transparent;
                Game.MainWindow.BackgroundImage = Resources.level3v2;

            }
            else if (EnemyType == "final")
            {
                this.Health = 2500;
                this.Speed = 1;
                this.OriginalHealth = 2500;
                this.PictureBox.Image = Resources.boss2;
                this.PictureBox.Width = Resources.boss2.Width;
                this.PictureBox.Height = Resources.boss2.Height;
                this.PictureBox.BackColor = Color.Transparent;
                Game.MainWindow.BackgroundImage = Resources.level2;

            }
            Drop = this.PictureBox.Image.Height + 10;
            int newHealth = (int)((this.Health / this.OriginalHealth) * 100) / 2;
            this.HealthBar = new Rectangle(this.PictureBox.Left, this.PictureBox.Top + this.PictureBox.Height, newHealth, 10);
        }

        //invader damage once shot by player 
        public int TakeDamage(int damageTaken)
        {
            //if statement for damage taken if no health left picturebox is false
            this.Health -= damageTaken;
            if (this.Health <= 0)
            {
                this.PictureBox.Visible = false;
                return 1;
            }
            return 0;
        }

        // health bar
        public static void DrawHealth()
        {

            // Create a brush of color for drawing red
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            // Create a GDI+ drawing surface on the Game window
            System.Drawing.Graphics formGraphics = Game.MainWindow.CreateGraphics();

            // For each invader
            for (x = 0; x <= Game.NumOfInvaders; x++)
            {
                // Invader.Health and Invader.OriginalHealth are doubles, Rectangle types don't accept doubles, so perform our scaling and then convert to integer.
                int newHealth = (int)((Game.InvadersList[x].Health / Game.InvadersList[x].OriginalHealth) * (Game.InvadersList[x].PictureBox.Width));
                // Create a rectangle under each Invader, 10 pixels tall, with the width corresponding to the Scaled Health we calculated above
                Rectangle newHealthBar = new Rectangle(Game.InvadersList[x].PictureBox.Left, Game.InvadersList[x].PictureBox.Top + Game.InvadersList[x].PictureBox.Height, newHealth, 10);
                // Draw the Rectangle under each Invader using the brush we defined earlier.
                formGraphics.FillRectangle(myBrush, newHealthBar);
            }

            // Release all memory resources held by brush and GDI+ drawing surface.
            formGraphics.Dispose();
            myBrush.Dispose();

        }


        //movement for player 
        public static void Move()
        {
           Game.MainWindow.Invalidate();
            for (x = 0; x <= Game.NumOfInvaders; x++)
            {

                if (IRight[x] == true)
                {
                    Game.InvadersList[x].PictureBox.Left += Game.InvadersList[x].Speed;
                }
                else
                {
                    Game.InvadersList[x].PictureBox.Left -= Game.InvadersList[x].Speed;
                }


                if (Game.InvadersList[x].PictureBox.Left + Game.InvadersList[x].PictureBox.Width > Game.MainWindow.ClientRectangle.Width & IRight[x] == true)
                {
                    IRight[x] = false;
                    Game.InvadersList[x].PictureBox.Top += Drop;
                }



                if (Game.InvadersList[x].PictureBox.Left < Game.MainWindow.ClientRectangle.Left & IRight[x] == false)
                {
                    IRight[x] = true;
                    Game.InvadersList[x].PictureBox.Top += Drop;
                }
            }
        }

       



    }
}
