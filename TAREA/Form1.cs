using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAREA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
//
//Llamado a la funcion ingreso de datos desde el boton de ingresar
//
        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            Ingreso_Datos();                        
        }
//
//LLamado a la funcion de busqueda cuando se hace click sobre el BtnBusqueda
//
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }
        private void TxtCantidad_TextChanged_1(object sender, EventArgs e)
        {
            if (TxtCantidad.Text != string.Empty)
            {
                BtnIngresar.Enabled = true;
            }
            else
            {
                BtnIngresar.Enabled = false;
            }
        }
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if ((TxtBuscar.Text != string.Empty) && (TxtCantidad.Text != string.Empty))
            {
                BtnBuscar.Enabled = true;
            }
            else
            {
                BtnBuscar.Enabled = false;
            }
        }
        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 13) && (TxtCantidad.Text != string.Empty))
            {
                Ingreso_Datos();
            }
            else
            {
                if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
                {
                    MessageBox.Show("Solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
        }
        private void TxtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 13) && (TxtBuscar.Text != string.Empty))
            {
                Busqueda();
            }
            else
            {
                if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
                {
                    MessageBox.Show("Solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
        }
        //
        //Funcion en la que pide el numero de datos y los almacena en la lista
        //
        private void Ingreso_Datos()
        {
            int[] datos;
            int dato, ncant;

            ncant = Convert.ToInt32(TxtCantidad.Text);

            datos = new int[ncant];

            for (int i = 0; i < ncant; i++)
            {
                dato = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Ingrese la nota " + (i + 1), "NOTAS"));
                datos[i] = dato;
                LstDatos.Items.Add(datos[i]);
            }
        }
        //
        //funcion que primero verifica si el numero buscado se encutra realmente en la lista 
        //luego 
        private void Busqueda()
        {
            int resultado, busqueda;
            resultado = 0;
            busqueda = Convert.ToInt32(TxtBuscar.Text);

            if (LstDatos.Items.Contains(busqueda))
            {
                foreach (int item in LstDatos.Items)
                {
                    if (item == busqueda)
                    {
                        resultado++;
                    }
                }
                TxtResultado.Text = resultado.ToString();
            }
            else
            {
                TxtResultado.Text = "El dato buscado no se encuentra en la lista de datos ingresados";
            }
        }
//
//Limpieza de las cajas de texto y la lista 
//
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            TxtBuscar.Clear();
            TxtCantidad.Clear();
            TxtResultado.Clear();
            LstDatos.Items.Clear();
        }
        //
        //boton salir que solicita confirmacion
        //
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult resp;
            resp = MessageBox.Show("¿Realmente desea salir del programa?", "MENSAJE", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resp == DialogResult.OK)
            {
                Close();
            }
        }
    }
}