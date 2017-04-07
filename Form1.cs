using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
     public partial class Form1 : Form
     {
          Boolean ActionPressed = false, DecimalPlaced = false, EqualsDone = false, ActionNow = false, inversion = false;
          Boolean aEntered = false, bEntered = false;
          char type;
          double a, b;
          private void buttonProcessing(int button)
          {
               if (ActionPressed) { textBox1.Text = null; ActionPressed = false; }
               textBox1.Text = textBox1.Text + button;
               ActionNow = false;
          }
          private void ActionProcessing(char localType) {
               if (ActionNow && localType == '-')
               {
                    inversion = true;
               }               
               if (!aEntered&& Convert.ToBoolean(textBox1.Text.Length)&&!ActionNow)
               {
                    a = Convert.ToDouble(textBox1.Text);
                    aEntered = true;
                    if (aEntered && localType == '√')
                    {
                         a = Math.Pow(a, 0.5);
                         textBox1.Text = Convert.ToString(a);
                         aEntered = false;
                         return;
                    }
               }
               else if (!bEntered && Convert.ToBoolean(textBox1.Text.Length)&&!ActionNow)
               {
                    b = inversion? -Convert.ToDouble(textBox1.Text) : Convert.ToDouble(textBox1.Text);
                    bEntered = true;
                    EqualsProcessing();
               }
               if (!inversion) type = localType;
               textBox1.Text = null;
               ActionPressed = true;
               ActionNow = true;
               textBox1.Text = textBox1.Text + type;
               bEntered = false;
          }
          private void EqualsProcessing() {
               if (ActionNow) return;
               double result=0;
               if (!bEntered||!EqualsDone)
               {
                    b = inversion ? -Convert.ToDouble(textBox1.Text) : Convert.ToDouble(textBox1.Text);
                    bEntered = true;
               }
               switch (type)
               {
                    case '/':
                         if (b != 0)
                         {
                              result = a / b;
                              textBox1.Text = Convert.ToString(result);
                         }
                         else textBox1.Text = "DIV BY 0";
                         break;
                    case '+':
                         result = a + b;
                         textBox1.Text = Convert.ToString(result);
                         break;
                    case '-':
                         result = a - b;
                         textBox1.Text = Convert.ToString(result);
                         break;
                    case '*':
                         result = a * b;
                         textBox1.Text = Convert.ToString(result);
                         break;
                    case '^':
                         result = Math.Pow(a,b);
                         textBox1.Text = Convert.ToString(result);
                         break;
                    default:
                         break;
               }
               a = result;
               EqualsDone = true;
               ActionNow = false;
               inversion = false;
          }
          public Form1()
          {
               InitializeComponent();
          }

          private void textBox1_TextChanged(object sender, EventArgs e)
          {
               if (textBox1.Text.Length == 0)
               {
                    return;
               }

               float height = textBox1.Height;
               float width = textBox1.Width;

               textBox1.SuspendLayout();

               Font tryFont = textBox1.Font;
               Size tempSize = TextRenderer.MeasureText(textBox1.Text, tryFont);

               float heightRatio = height / tempSize.Height;
               float widthRatio = width / tempSize.Width;

               tryFont = new Font(tryFont.FontFamily, Convert.ToInt16(tryFont.Size * Math.Min(widthRatio, heightRatio)), tryFont.Style);

               textBox1.Font = tryFont;
               textBox1.ResumeLayout();
          }

          private void buttonZero_Click(object sender, EventArgs e)
          {
               buttonProcessing(0);
          }

          private void button1_Click(object sender, EventArgs e)
          {
               buttonProcessing(1);
          }

          private void button2_Click(object sender, EventArgs e)
          {
               buttonProcessing(2);
          }

          private void button3_Click(object sender, EventArgs e)
          {
               buttonProcessing(3);
          }

          private void button4_Click(object sender, EventArgs e)
          {
               buttonProcessing(4);
          }

          private void button5_Click(object sender, EventArgs e)
          {
               buttonProcessing(5);
          }

          private void button6_Click(object sender, EventArgs e)
          {
               buttonProcessing(6);
          }

          private void button7_Click(object sender, EventArgs e)
          {
               buttonProcessing(7);
          }

          private void button8_Click(object sender, EventArgs e)
          {
               buttonProcessing(8);
          }

          private void button9_Click(object sender, EventArgs e)
          {
               buttonProcessing(9);
          }

          private void buttonDecimal_Click(object sender, EventArgs e)
          {
               if (ActionPressed) { textBox1.Text = null; ActionPressed = false; }
               if (!DecimalPlaced) { textBox1.Text = textBox1.Text + ","; DecimalPlaced = true; }

          }

          private void buttonClear_Click(object sender, EventArgs e)
          {
               if (ActionPressed) { textBox1.Text = null; ActionPressed = false; }
               textBox1.Text = null;
               DecimalPlaced = false;
               ActionPressed = false;
               EqualsDone = false;
               aEntered = false;
               bEntered = false;
               a = 0;
               b = 0;
          }

          private void buttonBack_Click(object sender, EventArgs e)
          {
               if (Convert.ToBoolean(textBox1.Text.Length))
               {
                    if (textBox1.Text[textBox1.Text.Length - 1] == ',')
                         DecimalPlaced = false;
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
               }
               else buttonClear_Click(sender, e);
          }

          private void buttonDivision_Click(object sender, EventArgs e)
          {
               ActionProcessing('/');
          }

          private void buttonInversion_Click(object sender, EventArgs e)
          {
               if (!ActionNow && !ActionPressed)
               {
                    double c = Convert.ToDouble(textBox1.Text);
                    c = -c;
                    textBox1.Text = Convert.ToString(c);
               }
          }

          private void buttonRoot_Click(object sender, EventArgs e)
          {
               ActionProcessing('√');
          }

          private void buttonMultiplication_Click(object sender, EventArgs e)
          {
               ActionProcessing('*');
          }

          private void buttonSubstraction_Click(object sender, EventArgs e)
          {
               ActionProcessing('-');          
          }

          private void buttonSum_Click(object sender, EventArgs e)
          {
               ActionProcessing('+');
          }

          private void buttonPower_Click(object sender, EventArgs e)
          {
               ActionProcessing('^');
          }

          private void buttonEquals_Click(object sender, EventArgs e)
          {
               EqualsProcessing();
          }
     }
}
