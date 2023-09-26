using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Kimberly Midkiff
// COP2360
// SPC ID 2319889

// Create a database and import the list of cities and populations
// create queries to sort data by various parameters
// create queries to determine average, largest, and smallest population
// create buttons to add coding execute the queries
// add coding to the buttons to call to the methods

namespace Population_Database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cityBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cityBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cityDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cityDataSet.City' table. You can move, or remove it, as needed.
            this.cityTableAdapter.Fill(this.cityDataSet.City);

        }

        private void sortAlphButton_Click(object sender, EventArgs e)
        {
            this.cityTableAdapter.FillByCity(this.cityDataSet.City);
        }

        private void sortPopDescButton_Click(object sender, EventArgs e)
        {
            this.cityTableAdapter.FillByPopDesc(this.cityDataSet.City);
        }

        private void sortPopButton_Click(object sender, EventArgs e)
        {
            this.cityTableAdapter.FillByPopAsc(this.cityDataSet.City);
        }

        private void largestPopButton_Click(object sender, EventArgs e)
        {
            decimal largestPopulation;

            largestPopulation = (decimal)this.cityTableAdapter.LargestPopulation();

            MessageBox.Show("The Largest Population is " + largestPopulation);
        }

        private void smallestPopButton_Click(object sender, EventArgs e)
        {
            decimal smallestPopulation;

            smallestPopulation = (decimal)this.cityTableAdapter.LowestPopulation();

            MessageBox.Show("The Smallest Population is " +  smallestPopulation);
        }

        private void avgPopButton_Click(object sender, EventArgs e)
        {
            decimal averagePopulation;

            averagePopulation = (decimal)(this.cityTableAdapter.AveragePopulation());

            MessageBox.Show("The Average Population is " +  averagePopulation);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
