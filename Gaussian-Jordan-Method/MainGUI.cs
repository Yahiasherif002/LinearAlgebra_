using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace ConsoleApplication6
{
    // YAHIA 
    public partial class MainGUI : Form
    {
        GaussianJordanElimination gaus = new GaussianJordanElimination();
        private int det;

        public MainGUI()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void MainGUI_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private DataTable createTable(int rows, int cols)
        {
            DataTable table = new DataTable();
            for (int x = 0; x < cols; x++)
            {
                table.Columns.Add("X" + x, typeof(double));
            }
            for (int y = 0; y < rows; y++)
            {
                table.Rows.Add(); // Add empty rows
            }
            return table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rows = 0;
            int cols = 0;

            try
            {
                cols = int.Parse(textBox1.Text);
                rows = int.Parse(textBox2.Text);

                if (cols <= 0 || rows <= 0)
                {
                    MessageBox.Show("Rows and Columns must be a positive integer");
                }

                DataTable table = createTable(rows, cols);
                dataGridView1.Visible = true;
                dataGridView1.DataSource = table;
                dataGridView1.Size = new Size((cols * 70) + 30, (rows * 25) + 15); // Adjusted column width
                Console.WriteLine(rows + " " + cols);
            }
            catch (FormatException)
            {
                MessageBox.Show("Rows and Columns must be an integer");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable table = (DataTable)dataGridView1.DataSource;
            int rows = table.Rows.Count;
            int cols = table.Columns.Count;
            double[,] data = new double[rows, cols];

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    if (!double.TryParse(table.Rows[y][x].ToString(), out data[y, x]))
                    {
                        MessageBox.Show("Invalid input at row " + (y + 1) + ", column " + (x + 1));
                        return;
                    }
                }
            }

            //double det = GaussianJordanElimination.DET(rows, data);

            

            
            
                gaus.setArray(data);
                string solution = gaus.solve();

                richTextBox1.Text = "Step 1: Create the Augmented Matrix\n";
                richTextBox1.Text += "The augmented matrix for this system is:\n";
                richTextBox1.Text += gaus.matToString(data) + "\n";

                if (solution.Contains("infinite set of solutions"))
                {
                    richTextBox1.Text += "Step 2: Perform Gaussian Jordan Elimination\n";
                    richTextBox1.Text += "\n";
                    richTextBox1.Text += " the matrix transformations step by step.\n\n";
                    richTextBox1.Text += "Step-by-Step Gaussian Jordan Elimination:\n";
                    richTextBox1.Text += solution;
                }
                else
                {
                    richTextBox1.Text += "Solution:\n";
                    richTextBox1.Text += solution;
                    //richTextBox1.Text += "\nNow, let's determine the nature of the solution based on the structure of the augmented matrix to see if it has no solution or an infinite set of solutions.";
                    richTextBox1.Text += "DONE";
                }
            
        }


                private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
