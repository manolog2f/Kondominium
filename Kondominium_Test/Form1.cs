using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kondominium_Process;

namespace Kondominium_Test
{
    public partial class Form1 : Form
    {
        private Process obj_process = new Process();
        public static string str_ruta;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool fileValid;

            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Title = "Seleccionar archivo del banco";
            openFileDialog1.FileName = "BAG_*";
            openFileDialog1.Filter = "(*.txt)|*.txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    str_ruta = openFileDialog1.FileName;
                    (dgvArchivos.DataSource, fileValid) = obj_process.LeerArchivo(str_ruta);
                    if (fileValid == true)
                    {
                        //FormatViews(dgvArchivos);
                    }
                    else
                    {
                        MessageBox.Show("El archivo seleccionado no es valido, intente de nuevo por favor");
                    }

                }
                catch (Exception)
                {
                    dgvArchivos.Rows.Clear();
                    MessageBox.Show("El archivo seleccionado no tiene el formato valido");
                }
            }
        }
    }
}
