using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System;
using Microsoft.VisualBasic.CompilerServices;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;

namespace Invaders
{
    public partial class Invaders
    {

        public static System.Windows.Forms.Timer Timer;

        //load game and timer
        private void Invaders_Load(object sender, EventArgs e)
        {
            Timer = _TimerMain;
            Game.Load();
            DoubleBuffered = true;
        }
        //timer on tick game process starts
        private void _TimerMain_Tick(object sender, EventArgs e)
        {
            Game.Process();
        }
        //movement when key pressed
        private void Invaders_KeyDown(object sender, KeyEventArgs e)
        {
            Player.HandleMovement(e, "KeyDown");
        }
        //movement for when key pressed
        private void Invaders_KeyUp(object sender, KeyEventArgs e)
        {
            Player.HandleMovement(e, "KeyUp");
        }

    }
}
