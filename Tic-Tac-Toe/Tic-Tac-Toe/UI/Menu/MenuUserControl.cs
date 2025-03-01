﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe.Menu
{
    public partial class MenuUserControl : UserControl
    {
        public event Action PlayClicked;
        public MenuUserControl()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            PlayClicked?.Invoke();
        }
    }
}
