using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCargaTextBoxMultilinea
{
    public partial class Form1 : Form
    {
        private const int MAX = 20;

        // Definición de la estructura de Articulos
        public struct ARTICULO
        {
            public int Codigo;
            public string Nombre;
            public float Precio;
        };
        // Arreglo de Articulos
        ARTICULO[] articulos;
        int Posicion; // indice de carga del arreglo

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // crear el arreglo de Articulos de 20 elementos
            articulos = new ARTICULO[MAX];
            Posicion = 0; // indice de carga en cero

            // limpar los controles
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            // limpiar la grilla
            dgvDatos.Rows.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // una validación simple:
            if(txtCodigo.Text != "" && txtNombre.Text != "" && txtPrecio.Text != "")
            {
                // se agrega un nuevo elemento al arreglo
                articulos[Posicion].Codigo = int.Parse(txtCodigo.Text);
                articulos[Posicion].Nombre = txtNombre.Text;
                articulos[Posicion].Precio = float.Parse(txtPrecio.Text);
                // incrementar el indice
                Posicion++;
                // contorlar si queda espacio
                if(Posicion == MAX)
                {
                    MessageBox.Show("Datos completos");
                    btnAgregar.Enabled = false;
                }
                // limpiar controles
                txtCodigo.Text = "";
                txtNombre.Text = "";
                txtPrecio.Text = "";
            }
            else
            {
                MessageBox.Show("Complete los datos solicitados");
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            // limpiar la grilla
            dgvDatos.Rows.Clear();

            int i; // indice auxiliar para recorrer el arreglo

            // controlar qué tipo de consulta se debe realizar
            if(chkPrecio.Checked) // mostrar sólo los artículos con precio > 1000
            {
                // recorrer el arreglo desde el inicio hasta la posición cargada
                for(i=0; i< Posicion; i++)
                {
                    // controlar si el precio es mayor a 1000 para mostrarlo
                    if(articulos[i].Precio > 1000)
                    {
                        // mostrar en la grilla
                        // grilla.Rows.Add(lista de valores): Agrega una nueva fila a la grilla
                        // en la lista de valores deben ser todos te tipo string
                        // y deben ir en el mismo orden que tienen las columnas configurardas en la grilla
                        dgvDatos.Rows.Add(articulos[i].Codigo.ToString(),
                                          articulos[i].Nombre,
                                          articulos[i].Precio.ToString());
                    }
                }
            }
            else // mostrar todos los artículos registrados
            {
                // recorrer el arreglo desde el inicio hasta la posición cargada
                for (i = 0; i < Posicion; i++)
                {
                    // mostrar en la grilla
                    dgvDatos.Rows.Add(articulos[i].Codigo.ToString(),
                                        articulos[i].Nombre,
                                        articulos[i].Precio.ToString());
                }
            }
        }
    }
}
