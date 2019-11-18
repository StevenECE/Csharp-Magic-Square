using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // display 3 by 3 magic square
        private void size3_CheckedChanged(object sender, EventArgs e)
        {
            PrintMS(MagicSquareOdd(3), 3, 65);
        }

        // display 5 by 5 magic square
        private void size5_CheckedChanged(object sender, EventArgs e)
        {
            PrintMS(MagicSquareOdd(5), 5, 25);
        }

        // display 7 by 7 magic square
        private void size7_CheckedChanged(object sender, EventArgs e)
        {
            PrintMS(MagicSquareOdd(7), 7, 15);
        }

        public void PrintMS(int[,] a, int size, int font)
        {
            // clear out the existing controls and generate a new table layout
            panel.Controls.Clear();

            // clear out the existing row and column styles
            panel.ColumnStyles.Clear();
            panel.RowStyles.Clear();

            // assign number of row and column and background color
            panel.RowCount = size;
            panel.ColumnCount = size;
            panel.BackColor = Color.Black;

            // set each square to equal size
            for (int i = 0; i < size; i++)
            {
                var percent = 100f / (float)size;
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percent));
                panel.RowStyles.Add(new RowStyle(SizeType.Percent, percent));
            }

            // generate button for each square and assign corresponding number of magic square to button text
            for (var x = 0; x < size; x++)
            {      
                for (var y = 0; y < size; y++)
                {                                                                            
                    Button button = new Button();                    
                    button.BackColor = Color.Lime;
                    button.FlatStyle = FlatStyle.Flat;
                    button.Text = a[y, x].ToString();
                    button.Font = new Font("Times New Roman", font, FontStyle.Bold);
                    button.Name = string.Format("Button{0}", button.Text);
                    button.Dock = DockStyle.Fill;
                    panel.Controls.Add(button, x, y);
                }
            }
        }

        // method for constructing a magic square of odd order (Siamese method or De la Loubère method)
        static int[,] MagicSquareOdd(int n)
        {
            int[,] arr = new int[n, n];
            arr[0, (n - 1) / 2] = 1;
            int x = 0, y = (n - 1) / 2;
            for (int c = 2; c <= n * n; c++)
                while (true)
                {
                    x--; y++;
                    while (true)
                    {
                        if (x < 0) x += n;
                        if (y >= n) y -= n;
                        if (y < 0) y += n;
                        if (arr[x, y] != 0)
                        {
                            x += 2;
                            y -= 1;
                            if (x >= n) x -= n;
                            if (y < 0) y += n;
                        }
                        break;
                    }
                    arr[x, y] = c; break;
                }
            // return resulted matrix
            return arr;
        }
    }
}