using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Media;

namespace Invaders
{
class Player
{

        //variables for this class 
        static int Speed = 8; // Player speed
        static int ShotSpeed = 32; // Player shot speed
        static bool SRight; //player right
        static bool SLeft; //player left
        public static int Damage = 50; //sprite damage
        public static int Health = 100; //initial health
        public static Control ShotSprite = Game.MainWindow.Controls["_ShotSprite"];
        public static Control Sprite = Game.MainWindow.Controls["_PlayerSprite"];
        private static SoundPlayer gunshotSound = new SoundPlayer(Resources.pew); //sound

        //movement for player 
        public static void HandleMovement(KeyEventArgs e, String eventType)
        {

        if (eventType == "KeyDown")
            {
                if (e.KeyValue == (int)Keys.Right || e.KeyValue == (int)Keys.D)
                {
                    SRight = true;
                    SLeft = false;
                }

                if (e.KeyValue == (int)Keys.Left || e.KeyValue == (int)Keys.A)
                {
                    SLeft = true;
                    SRight = false;
                }
               if (e.KeyValue == (int)Keys.Space & ShotSprite.Visible == false)
                {
                  //when space is pressed fire shot and play sound
                    gunshotSound.Play();
                    ShotSprite.Top = Sprite.Top;
                    ShotSprite.Left = (Sprite.Left + Sprite.Width / 2 - ShotSprite.Width / 2);
                    ShotSprite.Visible = true;
                }
                // p to pause game
                if (e.KeyValue == (int)Keys.P)
                {
                    if (Game.Paused == true)
                    {
                        Game.Timer.Enabled = true;
                        Game.Paused = false;
                    }
                    else
                    {
                        Game.Timer.Enabled = false;
                        Game.Paused = true;
                    }
                }
            }
            if (eventType == "KeyUp")
            {
                if (e.KeyValue == (int)Keys.Right || e.KeyValue == (int)Keys.D)
                {
                    SRight = false;
                }
                if (e.KeyValue == (int)Keys.Left || e.KeyValue == (int)Keys.A)
                {
                    SLeft = false;
                }
            }
        }

        // mavement of player 
        public static void Move()
        {
            if (SRight == true & Sprite.Left + Sprite.Width < Game.MainWindow.ClientRectangle.Width)
                Sprite.Left += Speed;
            if (SLeft == true & Sprite.Left > Game.MainWindow.ClientRectangle.Left)
                Sprite.Left -= Speed;
        }
        // below is shot speed and hide shot once hits top
        public static void FireShot()
        {
            if (ShotSprite.Visible == true)
            {
                ShotSprite.Top -= ShotSpeed;
            }

            if (ShotSprite.Top + ShotSprite.Height < Game.MainWindow.ClientRectangle.Top)
            {
                ShotSprite.Visible = false;
            }
        }
        // damage taken
        public void TakeDamage(int damageTaken)
        {
            Health -= damageTaken;
        }

    }
}
