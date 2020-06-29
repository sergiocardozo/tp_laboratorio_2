using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPPal : Form
    {

        private Correo correo;
        public FrmPPal()
        {
            InitializeComponent();
            this.correo = new Correo();
        }
        /// <summary>
        /// Comprueba los estados de los envios de paquetes 
        /// </summary>
        private void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEnViaje.Items.Clear();
            this.lstEntregado.Items.Clear();

            foreach (Paquete paquete in this.correo.Paquetes)
            {
                switch (paquete.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEnViaje.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEntregado.Items.Add(paquete);
                        break;
                }
            }
        }
        /// <summary>
        /// Agrega un paquete al listbox y comienza su simulacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
            paquete.InformarEstado += this.paq_InformarEstado;
            if (!(txtDireccion.Text == ""))
            {
                if (!(mtxtTrackingID.Text == ""))
                {
                    try
                    {
                        this.correo += paquete;
                    }
                    catch (TrackingIdRepetidoException ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    this.ActualizarEstados();
                }
                else
                    MessageBox.Show("Ingrese un ID de envio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Ingrese una direccion de envio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Muestra la informacion de todos los paquetes que llegaron a destino
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }
        /// <summary>
        /// Al cerrar el formulario, termina con todos los hilos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPPal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }
        /// <summary>
        /// Muestra la informacion de los elementos y lo guarda en el escritorio
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!(elemento is null))
            {
                this.rtbMostrar.Clear();
                if (elemento is Correo)
                    this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                else if (elemento is Paquete)
                    this.rtbMostrar.Text = elemento.ToString();
                elemento.MostrarDatos(elemento).Guardar("salida");
            }
        }
        /// <summary>
        /// Muestra la informacion de un paquete seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEntregado.SelectedItem);
        }
        /// <summary>
        /// Al generarse un cambio de estado, actualiza todos los estados de los paquetes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformarEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformarEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
                this.ActualizarEstados();
        }
    }
}
