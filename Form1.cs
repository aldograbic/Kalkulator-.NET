using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bttnNumClick(object sender, EventArgs e)
        {
            if (this.tBoxDisplay.Text != "0" && this.noviUnos == false)
                this.tBoxDisplay.Text += ((Button)sender).Text;
            else
            {
                this.tBoxDisplay.Text = ((Button)sender).Text; this.noviUnos = false;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                case Keys.D0:
                    this.bttnNumClick(this.bttnNum0, new EventArgs());
                    this.bttnNum0.Focus();
                    e.Handled = true;
                    break;
                case Keys.NumPad1:
                case Keys.D1:
                    this.bttnNumClick(this.bttnNum1, new EventArgs());
                    this.bttnNum1.Focus(); e.Handled = true;
                    break;
                case Keys.NumPad2:
                case Keys.D2:
                    this.bttnNumClick(this.bttnNum2, new EventArgs());
                    this.bttnNum2.Focus();
                    e.Handled = true;
                    break;
                case Keys.NumPad3:
                case Keys.D3:
                    this.bttnNumClick(this.bttnNum3, new EventArgs());
                    this.bttnNum3.Focus();
                    e.Handled = true;
                    break;
                case Keys.NumPad4:
                case Keys.D4:
                    this.bttnNumClick(this.bttnNum4, new EventArgs());
                    this.bttnNum4.Focus();
                    e.Handled = true;
                    break;
                case Keys.NumPad5:
                case Keys.D5:
                    this.bttnNumClick(this.bttnNum5, new EventArgs());
                    this.bttnNum5.Focus();
                    e.Handled = true;
                    break;
                case Keys.NumPad6:
                case Keys.D6:
                    this.bttnNumClick(this.bttnNum6, new EventArgs());
                    this.bttnNum6.Focus();
                    e.Handled = true;
                    break;
                case Keys.NumPad7:
                case Keys.D7:
                    this.bttnNumClick(this.bttnNum7, new EventArgs());
                    this.bttnNum7.Focus();
                    e.Handled = true;
                    break;
                case Keys.NumPad8:
                case Keys.D8:
                    this.bttnNumClick(this.bttnNum8, new EventArgs());
                    this.bttnNum8.Focus();
                    e.Handled = true;
                    break;
                case Keys.NumPad9:
                case Keys.D9:
                    this.bttnNumClick(this.bttnNum9, new EventArgs());
                    this.bttnNum9.Focus();
                    e.Handled = true;
                    break;
                case Keys.Decimal:
                case Keys.Oemcomma:
                case Keys.OemPeriod:
                    this.bttnDecTocka_Click(this.bttnDecTocka, new EventArgs());
                    this.bttnDecTocka.Focus();
                    e.Handled = true;
                    break;
                case Keys.Back:
                    this.bttnBackspace_Click(this.bttnBackspace, new EventArgs());
                    this.bttnBackspace.Focus();
                    e.Handled = true;
                    break;
                case Keys.Delete:
                    this.bttnC_Click(this.bttnC, new EventArgs());
                    this.bttnC.Focus();
                    e.Handled = true;
                    break;
                case Keys.Oemplus:
                case Keys.Add:
                    this.bttnMathOperacija(this.bttnZbrajanje, new EventArgs());
                    this.bttnZbrajanje.Focus();
                    e.Handled = true;
                    break;
                case Keys.OemMinus:
                case Keys.Subtract:
                    this.bttnMathOperacija(this.bttnOduzimanje, new EventArgs());
                    this.bttnOduzimanje.Focus();
                    e.Handled = true;
                    break;
                case Keys.Multiply:
                    this.bttnMathOperacija(this.bttnMnozenje, new EventArgs());
                    this.bttnMnozenje.Focus();
                    e.Handled = true;
                    break;
                case Keys.Divide:
                    this.bttnMathOperacija(this.bttnDijeljenje, new EventArgs());
                    this.bttnDijeljenje.Focus();
                    e.Handled = true;
                    break;
                case Keys.F12:
                    this.bttnIzracunaj_Click(this.bttnIzracunaj, new EventArgs());
                    this.bttnIzracunaj.Focus();
                    e.Handled = true;
                    break;
                case Keys.F11:
                    this.bttnPreznak_Click(this.bttnPreznak, new EventArgs());
                    this.bttnPreznak.Focus();
                    e.Handled = true;
                    break;
                case Keys.F10:
                    this.bttnCE_Click(this.bttnCE, new EventArgs());
                    this.bttnCE.Focus();
                    e.Handled = true;
                    break;
            }
        }


        private void bttnDecTocka_Click(object sender, EventArgs e)
        {
            if (this.tBoxDisplay.Text.Contains(',') == false && this.noviUnos == false)
                this.tBoxDisplay.Text += ",";
        }

        private void bttnPreznak_Click(object sender, EventArgs e)
        {
            if (this.tBoxDisplay.Text != "0")
            {
                if (this.tBoxDisplay.Text.Contains('-') == true)
                {
                    this.tBoxDisplay.Text = this.tBoxDisplay.Text.Remove(0, 1);
                }
                else
                {
                    this.tBoxDisplay.Text = "-" + this.tBoxDisplay.Text;
                }
            }
        }

        private void bttnBackspace_Click(object sender, EventArgs e)
        {
            if (this.tBoxDisplay.Text != "0" && this.noviUnos == false)
            {
                this.tBoxDisplay.Text = this.tBoxDisplay.Text.Remove(this.tBoxDisplay.Text.Length -1);
                if (this.tBoxDisplay.Text.Length == 0 || this.tBoxDisplay.Text == "-")
                    this.tBoxDisplay.Text = "0";
            }
        }

        private void bttnC_Click(object sender, EventArgs e)
        {
            this.tBoxDisplay.Text = "0";
            this.noviUnos = true;
        }


        private bool noviUnos = true, unosOperand2 = false;
        private double operand1, operand2;

        

        private byte mathOperacija = 0;

        private void bttnMathOperacija(object sender, EventArgs e)
        {
            if (this.unosOperand2 == false)
                double.TryParse(this.tBoxDisplay.Text, out this.operand1);
            else
                this.bttnIzracunaj_Click(sender, e);
            switch (((Button)sender).Text)
            {
                case "+":
                    this.mathOperacija = 1;
                    break;
                case "-":
                    this.mathOperacija = 2;
                    break;
                case "*":
                    this.mathOperacija = 3;
                    break;
                case "/":
                    this.mathOperacija = 4;
                    break;
            }
            this.noviUnos = true;
            this.unosOperand2 = true;
        }

        private void bttnIzracunaj_Click(object sender, EventArgs e)
        {
            if (this.noviUnos == false)
                double.TryParse(this.tBoxDisplay.Text, out this.operand2);
            switch (this.mathOperacija)
            {
                case 1:
                    this.operand1 = this.operand1 + this.operand2;
                    break;
                case 2:
                    this.operand1 = this.operand1 - this.operand2;
                    break;
                case 3:
                    this.operand1 = this.operand1 * this.operand2;
                    break;
                case 4:
                    this.operand1 = this.operand1 / this.operand2;
                    break;
            }
            this.tBoxDisplay.Text = this.operand1.ToString();
            this.noviUnos = true;
            this.unosOperand2 = false;
        }

        private void bttnCE_Click(object sender, EventArgs e)
        {
            this.mathOperacija = 0;
            this.operand1 = 0; this.operand2 = 0;
            this.tBoxDisplay.Text = "0";
            this.noviUnos = true;
        }
    }
}
