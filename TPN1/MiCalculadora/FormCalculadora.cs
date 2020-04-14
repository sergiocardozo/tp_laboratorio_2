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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        bool baseActualDecimal = true;
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperaciones.Text = "";
            lblResultado.Text = "";
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            return Calculadora.Operar(num1, num2, operador);
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperaciones.Text).ToString();
            baseActualDecimal = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != "")
            {
                if (baseActualDecimal)
                {
                    if (Convert.ToDouble(lblResultado.Text) > Int64.MaxValue)
                        MessageBox.Show("El numero es muy grande para convertir a binario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
                        baseActualDecimal = false;
                    }
                }
                else
                    MessageBox.Show("El resultado ya esta en binario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != "")
            {
                if (!baseActualDecimal)
                {
                    lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
                    baseActualDecimal = true;
                }
                else
                    MessageBox.Show("El mensaje ya se encuentra en decimal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperaciones.Items.Add("+");
            cmbOperaciones.Items.Add("-");
            cmbOperaciones.Items.Add("*");
            cmbOperaciones.Items.Add("/");
            lblResultado.Text = "";
        }
    }
}
