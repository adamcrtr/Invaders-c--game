using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invaders
{
    class Game
    {


        // Level ENUM List
        private enum Level
        {
            One,
            Two,
            Three
        }


        // static variables for this class 
        static Level currentLevel = Level.One;
        static int x;
        public static int NumOfInvaders;
        public static List<Invader> InvadersList = new List<Invader>();
        // store invader form in mainwindow variable
        public static Form MainWindow = Application.OpenForms["Invaders"];
        public static Timer Timer = Invaders.Timer;
        public static int ShotDown;
        public static bool Paused;
        private static SoundPlayer introSound = new SoundPlayer(Resources.fanfare_x);
        private static SoundPlayer failedSound = new SoundPlayer(Resources.laugh2);


        // when load is called load invaders and settings
        public static void Load()
        {

            foreach (Invader item in InvadersList)
            {
                if (item.PictureBox.Name == "Invader")
                {
                    MainWindow.Controls.Remove(item.PictureBox);
                }

            }
            InvadersList = new List<Invader>();
            Game.MainWindow.Invalidate();
            LoadInvaders();
            LoadSettings();
        }
          //load new invaders depending on which level
        private static void LoadInvaders()
        {
            x = 0;
            // below level one code
            if (currentLevel == Level.One)
            {   // here adding number of invaders
                NumOfInvaders = 20;
                for (x = 0; x <= NumOfInvaders; x++)
                { //assigning new invader and assigning its type used in invader class
                    InvadersList.Add(new Invader("normal"));
                    MainWindow.Controls.Add(InvadersList[x].PictureBox);
                }
            }
            else if (currentLevel == Level.Two)
            {
                NumOfInvaders = 10;
                for (x = 0; x <= NumOfInvaders; x++)
                {
                    InvadersList.Add(new Invader("boss"));
                    MainWindow.Controls.Add(InvadersList[x].PictureBox);
                }

            }
            else if (currentLevel == Level.Three)
            {
                NumOfInvaders = 0;
                for (x = 0; x <= NumOfInvaders; x++)
                {
                    InvadersList.Add(new Invader("final"));
                    MainWindow.Controls.Add(InvadersList[x].PictureBox);
                }

            }



        }

        // load settings and also if pause is false then timer must run
        private static void LoadSettings()
        {
            Paused = false;
            for (x = 0; x <= NumOfInvaders; x++)
            {
                Invader.IRight[x] = true;
                InvadersList[x].PictureBox.Left = -InvadersList[x].PictureBox.Width * x - x * 5;
                InvadersList[x].PictureBox.Top = 0;
                InvadersList[x].PictureBox.Visible = true;
            }
           Timer.Enabled = true;
        }

        // loads various methods
        public static void Process()
        {
            
            Player.Move();
            Player.FireShot();
            Invader.Move();
            Invader.DrawHealth();
            Game.CheckHit();
            Game.CheckGameOver();
            Game.UpdateScore();
        }

        // check whether invader been hit
        static void CheckHit()
        {
            for (x = 0; x <= NumOfInvaders; x++)
            {
                if (Player.ShotSprite.Top + Player.ShotSprite.Height >= InvadersList[x].PictureBox.Top & Player.ShotSprite.Top <= InvadersList[x].PictureBox.Top + InvadersList[x].PictureBox.Height & Player.ShotSprite.Left + Player.ShotSprite.Width >= InvadersList[x].PictureBox.Left & Player.ShotSprite.Left <= InvadersList[x].PictureBox.Left + InvadersList[x].PictureBox.Width & Player.ShotSprite.Visible == true & InvadersList[x].PictureBox.Visible == true)
                {
                    Player.ShotSprite.Visible = false;
                    Game.ShotDown += InvadersList[x].TakeDamage(Player.Damage);
                 }
            }
        }


        // checks wether all enemies killed exit or starts again if player failed next level if player won 
        static void CheckGameOver()
        {
            for (x = 0; x <= NumOfInvaders; x++)
            {
                if (InvadersList[x].PictureBox.Top + InvadersList[x].PictureBox.Height >= Player.Sprite.Top & InvadersList[x].PictureBox.Visible == true || Player.Health < 0)
                {
                    Game.Timer.Enabled = false;
                    x = NumOfInvaders - 1;
                    ShotDown = 0;
                    failedSound.Play();
                    Interaction.MsgBox("The Castle is overun, our enemies have won. Game Over");
                   
                    PlayAgain();
                }

                if (ShotDown == NumOfInvaders + 1)
                {
                    ShotDown = 0;
                    Game.Timer.Enabled = false;
                    if(currentLevel == Level.Three)
                    {
                        var Result = MessageBox.Show("Well done the enemies are gone. Start again?", "Message", MessageBoxButtons.YesNo);

                        if (Result == DialogResult.Yes)
                        {
                            currentLevel = Level.One;
                            Load();
                        }
                        else
                        {
                            Application.Exit();
                        }
                    }
                    else
                    {
                        // loads next level 
                        introSound.Play();
                        var Result = MessageBox.Show("The Castle is saved for now. Next Level?", "Message", MessageBoxButtons.YesNo);
                        
                        if (Result == DialogResult.Yes)
                        {
                            if (currentLevel == Level.One)
                            {
                                currentLevel = Level.Two;
                            }
                            else if (currentLevel == Level.Two)
                            {
                                currentLevel = Level.Three;
                              
                            }


                            Load();
                        }
                        else
                        {
                            Application.Exit();
                        }
                    }

                }
            }
        }
        
        // asks the player to play again
        static void PlayAgain()
        {
          var Result = MessageBox.Show("Play Again?","Message", MessageBoxButtons.YesNo);

            if (Result == DialogResult.Yes)
            {
                Load();
            }
            else
            {
                Application.Exit();
            }
        }


        // updates score if an invader has been shot down
        static void UpdateScore()
        {
            // updates score text box
            MainWindow.Controls["_lblScore"].Text = ShotDown.ToString();
        }


    }
}
