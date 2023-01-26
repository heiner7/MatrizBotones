using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrizBotones
{
    public partial class Form1 : Form
    {
        Button nuevoBoton = new Button();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
              
                float numero = 0.0f;
                int num1 = int.Parse(txtFila.Text);
                int num2 = int.Parse(txtColumna.Text);

               

                Button[,] matrizBoton = new Button[num1, num2];
                for (int i = 0; i < num1; i++)
                {
                   
                    for (int j = 0; j < num2; j++)
                    {

                        matrizBoton[i, j] = new Button();
                        matrizBoton[i, j].Width = 30;
                        matrizBoton[i, j].Height = 30;
                        matrizBoton[i, j].Text = Convert.ToString(numero);
                        matrizBoton[i, j].Top = i * 30;
                        matrizBoton[i, j].Left = j * 30;
                        //this.Controls.Add(matrizBoton[i, j]);

                        // nuevoBoton.Text = Convert.ToString(numero);
                        nuevoBoton = matrizBoton[i, j];
                        nuevoBoton.Click += new EventHandler(nuevoBoton_Click);
                        numero += 0.1f;
                        groupBox1.Controls.Add(nuevoBoton);
                       
                    }
                }
                txtFila.Text = ""; txtColumna.Text = ""; 
            }
            catch (Exception)
            {
                MessageBox.Show("Ingresar valores en los campos", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void nuevoBoton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            ColorDialog color = new ColorDialog();
            if(color.ShowDialog()== DialogResult.OK)
            {
                btn.BackColor = color.Color;
            }
        }

        private void txtFila_KeyUp(object sender, KeyEventArgs e)
        {
            var txt = sender as TextBox; //Sender obtiene el objeto actual 
            try
            {
                int a = Int32.Parse(txt.Text); //Intentamos covertir el string a número 
            }
            catch (Exception )
            {
                txt.Text = ""; //En caso de error se limpia el Campo
            }
        }

    }
}
