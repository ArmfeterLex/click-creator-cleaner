using System;
using System.Drawing;
using System.Windows.Forms;

namespace proj11
{
    public partial class Form1 : Form
    {
        private bool isButtonNext = true;
        private int controlCount = 0;

        public Form1()
        {
            InitializeComponent();
            this.MouseClick += Form1_MouseClick;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                controlCount++;

                if (isButtonNext)
                {
                    Button b = new Button();
                    b.Location = new Point(e.X, e.Y);
                    b.Size = new Size(75, 23);
                    b.Text = $"Кнопка {controlCount}";
                    b.Parent = this;
                }
                else
                {
                    TextBox tb = new TextBox();
                    tb.Location = new Point(e.X, e.Y);
                    tb.Size = new Size(100, 20);
                    tb.Text = $"Текст {controlCount}";
                    tb.Parent = this;
                }
                isButtonNext = !isButtonNext;
            }
            else if (e.Button == MouseButtons.Right)
            {
                for (int i = Controls.Count - 1; i >= 0; i--)
                {
                    if (Controls[i] is Button || Controls[i] is TextBox)
                    {
                        Controls[i].Dispose();
                    }
                }
                controlCount = 0;
            }
        }
    }
}