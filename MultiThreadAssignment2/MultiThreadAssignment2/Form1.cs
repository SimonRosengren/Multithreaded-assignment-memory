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
            writer = new Writer(characterPanel, answerBox, submitButton);
            FillComboBoxes();
            answerBox.Enabled = false;
            submitButton.Enabled = false;
            
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            startGameButton.Enabled = false;
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

        private void submitButton_Click(object sender, EventArgs e)
        {
            Brush brush = new SolidBrush(Color.DarkGreen);
            Console.WriteLine(CharacterBuffer.finalString);


            if (answerBox.Text == CharacterBuffer.finalString)
            {
                resultPanel.CreateGraphics().DrawString("CORRERCT!", new Font("Arial", 16), brush, 10f, 10f);              
            }
            else
                resultPanel.CreateGraphics().DrawString("INCORRECT: \nThe answer was: \n" + CharacterBuffer.finalString, new Font("Arial", 16), brush, 10f, 10f);   
        }
        private void Form1_Closing(object sender, EventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }

    }
}
