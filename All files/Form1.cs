using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms.DataVisualization.Charting; 
using System.Data.OleDb;


using System.Collections;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        /*
        *all the univercal variables
        */
        internal int[] dataAray;// put the randum numbers in an array
        internal int numData; // number of data to generate
        internal int max; // max number of data generated
        internal int min; // min number of data generated
         int startLine; // the line to start to sort
         int numLines; // total number of lines to sort
        internal string[] lengthString; //array to hold in the string from the file that oppened
        internal int[] fileString;  // array that only contain numbers to sort

        public Form1()
        {
            /*
             * decleraing all of the values to of the buttons
             *
              */
            InitializeComponent();
            numData = (int)numericUpDown1.Value;
            max = (int)numericUpDown3.Value; ;
            min= (int)numericUpDown2.Value; ;
            startLine= (int)numericUpDown4.Value;
            numLines = (int)numericUpDown5.Value;
            /*
          * the properties of the chart
          * declaring that the chart will deliever points
          */
            chart1.Series.Add("Quick Sort");
            chart1.Series.Add("Gnome Sort");
            chart1.Series.Add("Shell Sort");
            chart1.Series["Quick Sort"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series["Gnome Sort"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series["Shell Sort"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
      
            Stopwatch stopwatch = new Stopwatch(); // stopwatch for the arrays
        }

        int number { get; set; } // the number of the generated data

        /*
         * This class contain the generated randum numbers 
         *at which it passes through all the sort method that
         *are avalibe: Quich sort, Shell sort, gnomme sort 
         *the sort method sort all of the data and desplay it on the second text box
         */
        private void generateData(int number)
        {
                // create randum number
                Random random = new Random(); 
                dataAray = new int[number]; // put the generated data needed to an array
                 // if the max is less than the min tell the user to change
                if (max < min)
                {
                    MessageBox.Show("plase enter a value for max that is more than the min");
                }
                // if every thing is correct continue the code
                else
                {
                // for to show the generated data in the text box
                    for (int i = 0; i < number; i++)
                    {
                        dataAray[i] = random.Next(min, max); // asks the user of the max and min and put it in the random to generate
                        textBox1.Text += ", " + dataAray[i];

                    }
                    textBox4.Text = "" + number + "";

                    // if the Quick sort cheak box is clicked than sort the quick sort
                    if (checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked)
                    {
           
                        textBox2.Text += "Quicksort: ";
                        Stopwatch stopwatch = Quiksort.quickSort(dataAray, 0, number - 1);
                        chart1.Series["Quick Sort"].Points.AddXY(number, stopwatch.ElapsedTicks); // graphing the num of data generated vs the time
                        chart1.Update();
                    // loop for the sorted number from the quick sort to be desplaied in the other textbox
                        for (int j = 0; j < number; j++)
                        {
                            textBox2.Text += " " + dataAray[j] + "";
                        }
                        textBox3.Text = "" + stopwatch.Elapsed.Ticks;
                        textBox5.Text = "Quick Sort";

                    }
                    // if the gnome sort is selected
                    else if (!checkBox1.Checked && checkBox2.Checked && !checkBox3.Checked)
                    {
                        textBox2.Text += "Gnome sort: ";
                        Stopwatch stopwatch = Gnome_Sort.gnomeSort(dataAray, 1, number - 1);// graphing the num of data generated vs the time
                    chart1.Series["Gnome Sort"].Points.AddXY(number, stopwatch.ElapsedTicks); // graphing the num of data generated vs the time
                    chart1.Update();
                    // loop for the sorted number from the Gnome sort to be desplaied in the other textbox
                    for (int k = 0; k < number; k++)
                        {
                            textBox2.Text += "  " + dataAray[k] + "";
                        }

                        textBox3.Text = "" + stopwatch.Elapsed.Ticks;
                        textBox5.Text = "Gnome Sort";
                    }
                // loop for the sorted number from the shell sort to be desplaied in the other textbox
                else if (!checkBox1.Checked && !checkBox2.Checked && checkBox3.Checked)
                    {
                        textBox2.Text += "ShellSort: ";
                        Stopwatch stopwatch = ShellSort.Shell(dataAray, 1, number - 1);// graphing the num of data generated vs the time
                        chart1.Series["Shell Sort"].Points.AddXY(number, stopwatch.ElapsedTicks);
                        chart1.Update();
                    // loop for the sorted number from the Gnome sort to be desplaied in the other textbox
                    for (int j = 0; j < number; j++)
                        {
                            textBox2.Text += " " + dataAray[j] + "";
                        }

                        textBox3.Text = "" + stopwatch.ElapsedTicks;
                        textBox5.Text = "Shell Sort";
                    }
                    // if the user selecrted more than one sort method or if he didnt select any than tell him
                    else {
                        textBox1.Clear();
                        textBox2.Clear();
                        MessageBox.Show("please select only one sort method");
                    }
                } // end else of the generated data to sort
        }
        /*
       * 
       * if the user clicked the reset click button than restart every thing
       */
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
        if (checkBox4.Checked)
            {
                textBox1.Clear(); // restart the generated data
                textBox2.Clear(); // the sorted data
                textBox3.Clear(); // the time
                textBox4.Clear(); // the generated number count
                textBox5.Clear(); // the sort type
                // to restart the graph 
                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }

            }
        }

        /*
       * allow the user to put the maximun number
       */
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            max = (int)numericUpDown3.Value; ;
        }
        /*
      * allow the user to put the minimum number
      */
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            min = (int)numericUpDown2.Value; ;
        }

        // code of thesaving file is being inspired from https://msdn.microsoft.com/en-CA/library/8bh11f1k.aspx
        /*
 `     * the save file button
        * this button with the help of the cheakbox that is availibe can do
        *save the generated data to a file
        *save the sorted data to file 
        *save the statisticks that has the timpe of the count of the generated data and the sort type
        *save the chart as an image
        *save the data that the user selceted to sort
        */
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
           file.Filter= "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|.txt files (*.txt)|*.txt";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            //  *save the generated data to a file
            if (checkBox6.Checked && !checkBox5.Checked && !checkBox7.Checked && !checkBox8.Checked && !checkBox9.Checked)
                {
                if (file.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText("" + file.FileName, "Randum Numbers: " + textBox1.Text + "");
                }
                }
            //  *save the sorted data to file 
            else if (!checkBox6.Checked && checkBox5.Checked && !checkBox7.Checked && !checkBox8.Checked && !checkBox9.Checked)
                {
                if (file.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText("" + file.FileName, "The Time is " + textBox3.Text + " milliseconds.\\nThe generated number is:" + textBox4.Text + "\nThe Sort Method used is: " + textBox5.Text);
                }
                }
            //*save the statisticks that has the timpe of the count of the generated data and the sort type
                else if (!checkBox6.Checked && !checkBox5.Checked && !checkBox7.Checked && checkBox8.Checked && !checkBox9.Checked)
                {
                if (file.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText("" + file.FileName, "Sorted Numbers: " + textBox2.Text + "");
                }
                }
           // *save the chart as an image
               else if (!checkBox6.Checked && !checkBox5.Checked && checkBox7.Checked && !checkBox8.Checked &&!checkBox9.Checked)
                {
                if (file.ShowDialog() == DialogResult.OK)
                {
                    //code from http://stackoverflow.com/questions/2069048/setting-the-filter-to-an-openfiledialog-to-allow-the-typical-image-formats
                    //  System.IO.File.WriteAllText("" + file.FileName, "Randum Numbers: " + textBox1.Text + " Sorted Numbers " + textBox2.Text + " Statistics: The Time is " + textBox3.Text + " milliseconds.\\nThe generated number is: " + textBox4.Text + "\nThe Sort Method used is: " + textBox5.Text);
                    file.Filter= "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif"; // the type of the file for the image
                    int width = Convert.ToInt32(chart1.Width); // the witdh of the image
                    int height = Convert.ToInt32(chart1.Height); // the hieght of the image
                    Bitmap bmp = new Bitmap(width, height);     
                    chart1.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                    bmp.Save(file.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
                }
            //save the data that the user selceted to sort
            else if (!checkBox6.Checked && !checkBox5.Checked && !checkBox7.Checked && !checkBox8.Checked && checkBox9.Checked)
            {
                if (file.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText("" + file.FileName, "Start line: " + (int)numericUpDown4.Value + " Number of lines to sort after the start is " + (int)numericUpDown5.Value + " The data is " + textBox1.Text);
                }
            }
            //if the user did a wrong function tell him
            else
                {
                    MessageBox.Show("please select one type of sort file you want to save");
                }    
        }
        //code is from http://stackoverflow.com/questions/13900441/c-sharp-read-txt-file-into-textbox on just hoe to open a file
        /*
    * This button is used to open a file
    *this file can do
    *it open the number that are in the file as an string
    *it goes through all of the numbers and if it find any string that does not have any number it ignors it and only take the number to sort
    * it sends the information of the numbers to the sorting method  to be sorted
    * Data its sort it deped on the user, the user have to give the line to start sort and the line to finish sort
    * 
    */
        private void button3_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog(); // declaring the file to oipen
           openFileDialog1.Filter = ".txt files (*.txt)|*.txt"; // file type
            openFileDialog1.FilterIndex = 2;
              openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            string fileText = "";// telling the file to read all text 
                            string test = openFileDialog1.FileName;
                            // this for loop go through the line of the file to select only the lines the user indicated
                          
                            String noString = "";

                            //this for loop is to detect any string and remove it from the file if it has any
                            char[] x = fileText.ToCharArray();
                            for (int y = 0; y < x.Length; y++)
                            {
                                if (char.IsDigit(x[y]))
                                {
                                    noString += x[y] + " ";
                                }
                            }
                            noString = noString.Trim();
                            textBox1.Text = noString;
                            //lengthString = noString.Split(' '); // after it ignore all of the string this split the number to be stored in an array
                            lengthString = noString.Split(' ');
                            fileString = new int[lengthString.Length]; // declaring the length of the array
                            // converting all of the arrays to integer
                            for (int yi = 0; yi < lengthString.Length; yi++)
                            {                          
                               fileString[yi] += Convert.ToInt32(lengthString[yi]);
                            }

                        }
                       
                    }
                }
                catch (Exception ex)
               {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
             }
            }
        }

        /* 
         * This button sort all of the data that is being declared from the file
         * it will sort to quick sort and add the graph of the quick sort 
         * it will sort using shell sort and add the graph of the shell sort
         * it will sort using gnome sort and add the graph of teh gnome sort
         * it also delcalre the total number of number that it sorted from the file 
         * it also gives the total time it took all of the sorting method to be sorted in miliseconds
        */
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // if the user clicked the quick sort
                if (checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked)
                {
                    Stopwatch stopwatch = Quiksort.quickSort(fileString, 0, lengthString.Length - 1); // the prameter in this method is diffrent from the first one, it pases diffrent information of thearray and the length
                    chart1.Series["Quick Sort"].Points.AddXY(lengthString.Length, stopwatch.ElapsedTicks);
                    chart1.Update();
                    // adding the sorting number in the text box
                    for (int j = 0; j < lengthString.Length; j++)
                    {
                        textBox2.Text += " " + fileString[j] + "";
                    }
                    textBox3.Text = "" + stopwatch.Elapsed.Ticks;
                    textBox5.Text = "" + "Quick Sort";
                    textBox4.Text = "" + "" + lengthString.Length;
                }
                // if the user clickrf gnome sort
                else if (!checkBox1.Checked && checkBox2.Checked && !checkBox3.Checked)
                {
                    Stopwatch stopwatch = Gnome_Sort.gnomeSort(fileString, 1, lengthString.Length - 1);
                    chart1.Series["Gnome Sort"].Points.AddXY(lengthString.Length, stopwatch.ElapsedTicks);
                    chart1.Update();
                    // adding the sorting number in the text box
                    for (int y = 0; y < lengthString.Length; y++)
                    {
                        textBox2.Text += " " + fileString[y] + "";
                    }
                    textBox3.Text = "" + stopwatch.Elapsed.Ticks;
                    textBox5.Text = "Gnome Sort";
                    textBox4.Text = "" + "" + lengthString.Length;
                }
                // if the user clicked the shell sort
                else if (!checkBox1.Checked && !checkBox2.Checked && checkBox3.Checked)
                {
                    Stopwatch stopwatch = ShellSort.Shell(fileString, 1, lengthString.Length - 1);
                    chart1.Series["Shell Sort"].Points.AddXY(lengthString.Length, stopwatch.ElapsedTicks);
                    chart1.Update();
                    // adding the sorting number in the text box
                    for (int x = 0; x < lengthString.Length; x++)
                    {
                        textBox2.Text += " " + fileString[x] + "";
                    }
                    textBox3.Text = "" + stopwatch.Elapsed.Ticks;
                    textBox5.Text = "Shell Sort";
                    textBox4.Text = "" + "" + lengthString.Length;
                }
                //if the user did any thing wring tell him
                else
                {
                    textBox2.Clear();
                    MessageBox.Show("please select only one sort method");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: No data to sort. Original error: " + ex.Message);
            }
        }

        /*
        * code is from http://www.codeproject.com/Questions/224097/How-to-draw-trendline-in-graph-using-Windows-Forms
         * This method generate the line of best fit for the chart 
         *
         */
        private void button5_Click(object sender, EventArgs e)
        {
            try {
                chart1.Series.Add("Line of Best Fit");
                chart1.Series["Line of Best Fit"].ChartType = SeriesChartType.Line;
                chart1.Series["Line of Best Fit"].BorderWidth = 3;
                chart1.Series["Line of Best Fit"].Color = Color.Red;
                // Line of best fit is linear
                string typeRegression = "Linear";//"Exponential";//
                                                 // The number of days for Forecasting
                string forecasting = "1";
                // Show Error as a range chart.
                string error = "false";
                // Show Forecasting Error as a range chart.
                string forecastingError = "false";
                // Formula parameters
                string parameters = typeRegression + ',' + forecasting + ',' + error + ',' + forecastingError;
                chart1.Series[0].Sort(PointSortOrder.Ascending, "X");
                // Create Forecasting Series.
                chart1.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, parameters, chart1.Series[0], chart1.Series["Line of Best Fit"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not graph line of best fit. Original error: " + ex.Message);
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

        }
        //num of line to begin with sorting
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            startLine = (int)numericUpDown4.Value;
            System.Diagnostics.Debug.WriteLine(startLine);

        }
        // number of data to end with sorting
        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            numLines = (int)numericUpDown5.Value;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
   
        //this is the first button it generate data from the max and min of the user
        private void button1_Click(object sender, EventArgs e)
       {
            generateData(numData);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numData = (int)numericUpDown1.Value;
            System.Diagnostics.Debug.WriteLine(numData);
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void a_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void checkBox9_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}

