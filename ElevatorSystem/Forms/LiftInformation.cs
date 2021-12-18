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
    public partial class LiftInformation : Form
    {
        private int count;
        private List<Button> buttons;
        private int oldIndex;

        public LiftInformation(int count)
        {
            InitializeComponent();
            this.count = count;
            initialButtons();
        }
        private void initialButtons() 
        {
            oldIndex = 0;
            buttons = new List<Button>();
            int pos = 60;
            for (int i = 0; i < count; i++)
            {
                Button newbutton = new Button();
                newbutton.Text = "Этаж " + (i + 1);
                newbutton.Width = 128;
                newbutton.Height = 60;
                newbutton.Location = new Point(100, pos);
                newbutton.Enabled = true;
                newbutton.BackColor = Color.White;
                Controls.Add(newbutton);
                buttons.Add(newbutton);
                pos += 62;
            }
        }

        public void painButton(int index) 
        {
            buttons[oldIndex].BackColor = Color.White;
            buttons[index].BackColor = Color.Green;
            oldIndex = index;
        }

        public void painButtonFalse()
        {
            buttons[oldIndex].BackColor = Color.White;
        }

        public void painMove(bool enable)
        {
            if (enable) 
            {
                button1.BackColor = Color.Green;
            } else
            {
                button1.BackColor = Color.White;
            }
            
        }
        public void addWeight(int weight)
        {
            label2.Text = "Вес: " + weight;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void LiftInformation_Load(object sender, EventArgs e)
        {

        }
    }
}
