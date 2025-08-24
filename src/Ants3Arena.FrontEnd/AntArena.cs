using Ant_3_Arena.Ants;
using Ant3Arena.Business.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Ant_3_Arena
{
    public partial class AntArena : Form
    {
        private List<IAnt> antsContext = new List<IAnt>();

        // Refactor constructor to accept multiple ants of each color
        public AntArena(List<IAnt> ants)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImage = Properties.Resources.bg;

            antsContext = ants;
        }


        private void AntArena_Paint(object sender, PaintEventArgs e)
        {
            antsContext.ForEach(ant => e.Graphics.DrawImage(ant.AntImage, ant.X, ant.Y, 32, 36));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            antsContext.ForEach(ant => ant.Move(this.ClientSize));
            Invalidate();
        }

        private void AntArena_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }

    }
}