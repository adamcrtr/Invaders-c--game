using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invaders
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        // when play is pressed load game
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Invaders = new Invaders();
            Invaders.Closed += (s, args) => this.Close();
            Invaders.Show();
        }


        // ignore below
        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        // exits game
        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      
    }
}
