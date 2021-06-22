using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;
using System.Resources;

namespace Invaders
{
    [DesignerGenerated()]
    public partial class Invaders : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                    components.Dispose();
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;
        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        public Invaders()
        {
            InitializeComponent();
        }

        public static void Main()
        {
            
            MainMenu main = new MainMenu();
            Application.Run(main);
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._TimerMain = new System.Windows.Forms.Timer(this.components);
            this._lblScore = new System.Windows.Forms.Label();
            this._ShotSprite = new System.Windows.Forms.PictureBox();
            this._PlayerSprite = new System.Windows.Forms.PictureBox();
            this.lblinfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._ShotSprite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._PlayerSprite)).BeginInit();
            this.SuspendLayout();
            // 
            // _TimerMain
            // 
            this._TimerMain.Enabled = true;
            this._TimerMain.Interval = 20;
            this._TimerMain.Tick += new System.EventHandler(this._TimerMain_Tick);
            // 
            // _lblScore
            // 
            this._lblScore.AutoSize = true;
            this._lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblScore.Location = new System.Drawing.Point(92, 397);
            this._lblScore.Name = "_lblScore";
            this._lblScore.Size = new System.Drawing.Size(24, 25);
            this._lblScore.TabIndex = 2;
            this._lblScore.Text = "0";
            // 
            // _ShotSprite
            // 
            this._ShotSprite.BackColor = System.Drawing.Color.Red;
            this._ShotSprite.Location = new System.Drawing.Point(222, 231);
            this._ShotSprite.Name = "_ShotSprite";
            this._ShotSprite.Size = new System.Drawing.Size(10, 20);
            this._ShotSprite.TabIndex = 1;
            this._ShotSprite.TabStop = false;
            this._ShotSprite.Visible = false;
            // 
            // _PlayerSprite
            // 
            this._PlayerSprite.BackColor = System.Drawing.Color.Transparent;
            this._PlayerSprite.Image = global::Invaders.Resources.bowplayer;
            this._PlayerSprite.Location = new System.Drawing.Point(281, 361);
            this._PlayerSprite.Name = "_PlayerSprite";
            this._PlayerSprite.Size = new System.Drawing.Size(85, 58);
            this._PlayerSprite.TabIndex = 0;
            this._PlayerSprite.TabStop = false;
            // 
            // lblinfo
            // 
            this.lblinfo.AutoSize = true;
            this.lblinfo.BackColor = System.Drawing.SystemColors.Control;
            this.lblinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinfo.Location = new System.Drawing.Point(12, 397);
            this.lblinfo.Name = "lblinfo";
            this.lblinfo.Size = new System.Drawing.Size(74, 25);
            this.lblinfo.TabIndex = 3;
            this.lblinfo.Text = "Score:";
            // 
            // Invaders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Invaders.Resources.level1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(614, 431);
            this.Controls.Add(this.lblinfo);
            this.Controls.Add(this._lblScore);
            this.Controls.Add(this._ShotSprite);
            this.Controls.Add(this._PlayerSprite);
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Invaders";
            this.Text = "Medieval Besieged";
            this.Load += new System.EventHandler(this.Invaders_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Invaders_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Invaders_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this._ShotSprite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._PlayerSprite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        private PictureBox _PlayerSprite;

        internal PictureBox PlayerSprite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PlayerSprite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PlayerSprite != null)
                {
                  //  _Player.Click -= Player_Click;
                }

                _PlayerSprite = value;
                if (PlayerSprite != null)
                {
                  //  _Player.Click += Player_Click;
                }
            }
        }

        private Timer _TimerMain;

        internal Timer TimerMain
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TimerMain;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TimerMain != null)
                {
                    _TimerMain.Tick -= _TimerMain_Tick;
                }

                _TimerMain = value;
                if (_TimerMain != null)
                {
                    _TimerMain.Tick += _TimerMain_Tick;
                }
            }
        }

        private PictureBox _ShotSprite;

        internal PictureBox Shot
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ShotSprite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ShotSprite != null)
                {
                }

                _ShotSprite = value;
                if (_ShotSprite != null)
                {
                }
            }
        }

        private Label _lblScore;
        private Label lblinfo;

        internal Label lblScore
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblScore;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblScore != null)
                {
                }

                _lblScore = value;
                if (_lblScore != null)
                {
                }
            }
        }
    }
}
