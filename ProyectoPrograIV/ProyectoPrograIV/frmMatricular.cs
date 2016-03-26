﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPrograIV
{
    public partial class frmMatricular : Form
    {
        public frmMatricular()
        {
            InitializeComponent();
            this.ActiveControl = txtNombre;//pone el foco en el textbox especificado.
            this.StartPosition = FormStartPosition.CenterScreen;//pone el form en el centro.
            //Se ponen ambos textBox en readOnly para poderlos validar mas abajo.
            txtCorreo.ReadOnly = true;
            txtGrupo.ReadOnly = true;
        }//fin constructor

        private String generarCarne()
        {
            //Se guarda el valor del año en un variable temporal.
            int anno = DateTime.Now.Year;

            //Se crea un numero aleatorio para finalizar el carne
            Random random = new Random();
            int num = random.Next(1, 10000);//Se crea un un numero de cuatro digitos

            //se crea un carne para el estudiante poniendo el año de matricula, el grupo y el random.
            String carne = anno.ToString() + txtGrupo.Text + num;

            return carne;
        }//fin metodo String generarCarne()

        private void guardarRegistro()
        {
            //se crea el query para guardar los valores
            string query = "INSERT INTO Estudiantes(Carne,Nombre,Correo,Grupo) values('" + txtCarne.Text + "','" + txtNombre.Text + "','" + txtCorreo.Text + "','" + txtGrupo.Text + "')";

            //se crea una nueva instancia de logica para reutlizar el codigo de la clase
            Logica logica = new Logica();

            //se utliza el metodo para conectar a la base de datos y guardar los valores
            logica.ConectarAccess(query, "Los datos del estudiante se han guardado correctamente.");

        }//fin metodo void guardarRegistro ()

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //se valida que los TextBox no esten vacios
                if(txtNombre.Text != "" && txtNombre.Text != " " || txtCorreo.Text != "" && txtCorreo.Text != " " || txtGrupo.Text != "" && txtGrupo.Text != " ")
                {
                    //se llama al metodo para gurdar los valores
                    guardarRegistro();
                }//fin if de validacion
                else
                {
                    MessageBox.Show("Se deben llenar todos los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }//fin else de validacion
            }//fin try
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }//fin catch
        }//fin evento btnAgregar_Click(object sender, EventArgs e)

        private void txtGrupo_TextChanged(object sender, EventArgs e)
        {
            //llama al metodo para que genere un carne para el estudiante y lo muestre en la casilla.
            txtCarne.Text = generarCarne();
        }//fin evento txtGrupo_TextChanged(object sender, EventArgs e)

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //se limpian todos los campos
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtGrupo.Text = "";
            txtCarne.Text = "";
        }//fin evento btnLimpiar_Click(object sender, EventArgs e)

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            if(txtCorreo.Text != "" && txtCorreo.Text != " ")
            {
                txtGrupo.ReadOnly = false;
            }//fin if de validacion
            else
            {
                txtGrupo.ReadOnly = true;
            }//fin else de validacion
        }//fin evento txtCorreo_TextChanged(object sender, EventArgs e)

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtNombre.Text != " ")
            {
                txtCorreo.ReadOnly = false;
            }//fin if de validacion
            else
            {
                txtCorreo.ReadOnly = true;
            }//fin else de validacion
        }//fin evento txtNombre_TextChanged(object sender, EventArgs e)
    }//fin class
}//fin namespace