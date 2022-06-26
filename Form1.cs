using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ЗАПОВІДНИК;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private static AnimalArray animalArrayObject;

        public Form1()
        {
            InitializeComponent();
            animalArrayObject = FactoryCreator.GetFactory().GetAnimalArray();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            animalArrayObject.AppendArray();
            animalArrayObject.AddIDToAnimalArray();
            dataGridView1.DataSource = animalArrayObject.GetAll();
            dataGridView2.DataSource = animalArrayObject.AnimalListedInRedBook();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index;
            int.TryParse(tb1.Text, out index);
            if (index > animalArrayObject.AnimalCountStartWork || index < 1)
            {
                MessageBox.Show("Index not found", "Error");
                throw new MyException(MyExceptionKind.WrongIndexExeption, "\nНеіснуючий індекс. Спробуйте Знову.\n"); 
            }
            MessageBox.Show(animalArrayObject[index].ToString(),"Found animal");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
