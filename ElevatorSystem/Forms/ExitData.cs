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
    public partial class ExitData : Form
    {
        public ExitData(int sum, int hol, int weigth, int countPers)
        {
            InitializeComponent();
            label1.Text = "Общее количество поездок: " + sum;
            label2.Text = "Количество холостых поездок: " + hol;
            label3.Text = "Суммарный перемещённый вес: " + weigth;
            label4.Text = "Общее количество человек: " + countPers;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ExitData_Load(object sender, EventArgs e)
        {

        }
    }
}
