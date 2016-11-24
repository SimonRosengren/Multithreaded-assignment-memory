using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MultiThreadAssignment2
{
    public partial class Form1 : Form
    {
        Thread thread1;
        Thread thread2;

        Reader reader;
        Writer writer;

        

        public Form1()
        {
            InitializeComponent();
            reader = new Reader(characterPanel);
            writer = new Writer();
            FillComboBoxes();
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            writer.SetAttributes((int)comboBox1.SelectedItem, (int)comboBox2.SelectedItem); //Unsafe att casta om till int?

            thread1 = new Thread(writer.StartAddingCharacters);
            thread2 = new Thread(reader.Update);
            thread1.Start();
            thread2.Start();
        }
        void FillComboBoxes()
        {
            //Characters
            comboBox1.Items.Add(3);
            comboBox1.Items.Add(4);
            comboBox1.Items.Add(5);
            comboBox1.Items.Add(6);
            comboBox1.Items.Add(7);

            //Times between
            comboBox2.Items.Add(1000);
            comboBox2.Items.Add(2000);
            comboBox2.Items.Add(3000);
            comboBox2.Items.Add(4000);
            comboBox2.Items.Add(5000);
        }
    }
}
