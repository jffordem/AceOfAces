using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Aces
{
    public partial class InputPageDialogBox : Form
    {
        public InputPageDialogBox()
        {
            InitializeComponent();
        }
        public string PageNumber { get { return this.textBoxPageNumber.Text; } set { this.textBoxPageNumber.Text = value; } }
    }
}
