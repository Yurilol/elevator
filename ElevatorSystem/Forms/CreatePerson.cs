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
    public partial class CreatePerson : Form
    {
        private int firstFloor;
        private int endFloor;

        public CreatePerson()
        {
            InitializeComponent();
            firstFloor = 0;
            endFloor = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" || textBox1.Text != "")
            {
                firstFloor = Convert.ToInt32(textBox1.Text);
                endFloor = Convert.ToInt32(textBox2.Text);
            }

            if ((firstFloor < 1) || (endFloor < 1))
            {
                label3.Text = "Данные введены неверно!";
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else {
                this.Close();
            }
           
        }

        public int FirstFloor { 
            get {
                return firstFloor;
            }
        }

        public int EndFloor
        {
            get
            {
                return endFloor;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
