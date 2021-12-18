using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElevatorSystem
{
    public partial class PersonInformation : Form
    {
        String status;

        public PersonInformation(string status)
        {
            InitializeComponent();
            this.status = status;
            label4.Text = "" + status;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            label4.Text = "" + status;
        }
    }
}
