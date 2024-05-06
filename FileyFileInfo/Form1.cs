using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; 

namespace FileyFileInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Si el archivo no existe entonces crealo
            if(!File.Exists("ArchivoDos.txt"))
            {
                //File.Create("ArchivoUno.txt");
                FileInfo archivo = new FileInfo("ArchivoDos.txt");
                archivo.Create(); 
            }

             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.Delete("ArchivoDos.txt"); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("ArchivoTres.txt", FileMode.OpenOrCreate,FileAccess.Write );
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Esta es la primera linea");
            sw.WriteLine("Aqui acabo de escribir otra cosa");
            sw.WriteLine("Aqui escribi otra cosa"); 
            sw.Flush(); //Para mandar lo escrito
            sw.Close();
            fs.Close(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("ArchivoTres.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string texto = "";
            //Ciclo while nos permite leer hasta cierto condicion
            //La condicion será hasta que ya no existan caracteres
            while (!sr.EndOfStream)
            {
                texto += sr.ReadLine() + Environment.NewLine;
            }
            sr.Close();
            fs.Close(); 
            textBox1.Text = texto;
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            File.Copy("ArchivoTres.txt", @"C:\Temporal\ArchivoTres.txt"); 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FileInfo miArchivo = new FileInfo("ArchivoTres.txt");
            string propiedades = "";
            propiedades += miArchivo.Name + Environment.NewLine;
            propiedades += miArchivo.FullName + Environment.NewLine;
            propiedades += miArchivo.LastAccessTime + Environment.NewLine;
            propiedades += miArchivo.Length + Environment.NewLine;
            propiedades += miArchivo.LastWriteTimeUtc + Environment.NewLine;
            MessageBox.Show(propiedades); 
        }
    }
}
