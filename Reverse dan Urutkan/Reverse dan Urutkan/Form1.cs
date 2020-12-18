using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reverse_dan_Urutkan
{
    public partial class FormBoxString : Form
    {
        public FormBoxString()
        {
            InitializeComponent();
            this.ActiveControl = textBoxInput;
            textBoxInput.Focus();
        }
        private void textBoxInput_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void textBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            string input = textBoxInput.Text;
            if(e.KeyCode == Keys.Enter)
            {
                if (input == String.Empty)
                {
                    MessageBox.Show("Tolong isi textbox terlebih dahulu!");
                    labelOutput.Text = "Output";
                }
                else 
                {
                    this.ActiveControl = buttonReverse;
                    buttonReverse.Focus();
                }
            }
        }

        private void buttonReverse_Click(object sender, EventArgs e)
        {
            string s1 = textBoxInput.Text;
            char[] urutan = s1.ToCharArray();
            string reverse = "";
            for (int i = urutan.Length - 1; i > -1; i--)
            {
                reverse = reverse + urutan[i];
            }
            labelOutput.Text = reverse;
            textBoxInput.Clear();
            this.ActiveControl = textBoxInput;
            textBoxInput.Focus();
        }

        private void buttonReverse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                labelOutput_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Left)
            {
                this.ActiveControl = buttonUrutkan;
                buttonUrutkan.Focus();
            }
        }

        private void buttonUrutkan_Click(object sender, EventArgs e)
        {
            string s1 = textBoxInput.Text;
            char[] urutan = s1.ToCharArray();
            string urut = "";
            string urutKapital = "";
            string urutSimbol = "";
            char urutsimpan;
            for (int i = urutan.Length - 1; i > -1; i--)
            {
                for(int j = urutan.Length - 1; j > -1; j--)
                {
                    if (urutan[i] != ' ')
                    {
                        if (urutan[i] > urutan[j])
                        {
                            urutsimpan = urutan[i];
                            urutan[i] = urutan[j];
                            urutan[j] = urutsimpan;
                        }
                    }
                }
                if (urutan[i] >= 'a')
                {
                    urut = urut + urutan[i];
                    urutan[i] = 'z';                   
                }
                else if (urutan[i] <= 'Z')
                {
                    urutKapital = urutKapital + urutan[i];
                    urutan[i] = 'z';
                }
                else if (urutan[i] < 'A')
                {
                    urutSimbol = urutSimbol + urutan[i];
                    urutan[i] = 'z';
                }
            }
            labelOutput.Text = urut + urutKapital + urutSimbol;
            textBoxInput.Clear();
            this.ActiveControl = textBoxInput;
            textBoxInput.Focus();
        }

        private void buttonUrutkan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                labelOutput_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Right)
            {
                this.ActiveControl = buttonReverse;
                buttonReverse.Focus();
            }
        }

        private void labelOutput_Click(object sender, EventArgs e)
        {
            
        }
    }
}
