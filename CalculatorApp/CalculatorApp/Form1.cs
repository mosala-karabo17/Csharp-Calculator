using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            
        }
        float num1 = 0, num2 = 0;
        int oprClickCount = 0;
        bool isOprClick = false, isEqualClick = false;
        string opr;
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c is Button)
                {
                    if (c.Text != "Reset")
                    {
                        c.Click += new System.EventHandler(btn_click);
                    }
                    
                }
            }
        }

 

        private void btnZero_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            
        }

        //create a button click event
        public void btn_click(Object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (!isOperator(button)) //if the button is a number 
            {

                if (isOprClick)
                {
                    num1 = float.Parse(textBox1.Text);
                    textBox1.Text = " ";
                }

                // if the button text doesn't contain "."
                if (!textBox1.Text.Contains("."))
                {
                    if (textBox1.Text.Equals("0") && !button.Text.Equals("."))
                    {
                        // delete the first "0"
                        //set button text to the textbox
                        // if the button text is not "."
                        textBox1.Text = button.Text;
                        isOprClick = false;
                    }
                    else
                    {
                    
                        textBox1.Text += button.Text;
                        isOprClick = false;
                    }

                }
                else if(button.Text.Equals("."))
                {
                    textBox1.Text += button.Text;
                }
            }
            else //if the button is an operator [+ - / * =] 
            {
                if (oprClickCount == 0)// if its's first time we click on an operator 
                {
                    oprClickCount++;
                    //convert textbox to float and send it into num1
                    num1 = float.Parse(textBox1.Text);
                    // get the operator from button text
                    opr = button.Text;
                    // set oprclick to true
                    isOprClick = true;
                }
                else
                {
                    if (!button.Text.Equals("="))// if the operator is not "="
                    {
                        if (!isEqualClick)
                        {
                            num2 = float.Parse(textBox1.Text);
                            textBox1.Text = Convert.ToString(calc(opr,num1,num2));
                            num2 = float.Parse(textBox1.Text);

                            opr = button.Text;
                            isOprClick = true;
                            isEqualClick = false;
                        }
                        else
                        {
                            isEqualClick = false;
                            opr = button.Text;
                        }
                    }
                }
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            num1 = 0;
            num2 = 0;
            opr = " ";
            isOprClick = false;
            isEqualClick = false;
            oprClickCount = 0;
            textBox1.Text = "0";
        }

        //create a function to check if the clicked button is a numbers or an operator
        public bool isOperator(Button button)
        {
            string buttonText = button.Text;
            if (buttonText.Equals("+") || buttonText.Equals("-") ||
                buttonText.Equals("x") || buttonText.Equals("/") ||
                buttonText.Equals("=") || buttonText.Equals("Clear"))
            {
                return true; 
            }
            else
            {
                return false;
            }
        }

        //function to calculate
        public float calc(string opr, float n1, float n2)
        {
            float result = 0;

            switch (opr)
            {
                case "+":
                    result = n1 + n2;
                    break;
                case "-":
                    result = n1 - n2;
                    break;
                case "x":
                    result = n1 * n2;
                    break;
                case "/":
                    if (n2 != 0)
                    {
                        result = n1 / n2;
                    }
                    
                    break;
               

            }

            return result;
        }
    }
}
