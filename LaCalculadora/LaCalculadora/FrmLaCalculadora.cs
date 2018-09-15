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

namespace LaCalculadora
{
    public partial class FrmLaCalculadora : Form
    {
        public FrmLaCalculadora()
        {
            InitializeComponent();
        }

        private void FrmLaCalculadora_Load(object sender, EventArgs e)
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            //Validar que solo permita ingresar datos numéricos
            double AsignarNum1, AsignarNum2;
            if (!Double.TryParse(txtNumero1.Text, out AsignarNum1))
            {
                errorProvider1.SetError(txtNumero1, "Debe ingresar un número");
                MessageBox.Show("Debe ingresar un número TexBox 1");
                txtNumero1.Focus();
                return;
            }

            if (!Double.TryParse(txtNumero2.Text, out AsignarNum2))
            {
                errorProvider1.SetError(txtNumero2, "Debe ingresar un número");
                MessageBox.Show("Debe ingresar un número TexBox 2");
                txtNumero1.Focus();
                return;
            }

            errorProvider1.SetError(txtNumero1, "");
            errorProvider2.SetError(txtNumero2, "");

            double esperandoResultado = ResultadoOperar();
            lblResultado.Text = esperandoResultado.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            string message = "Desea salir del Formulario ?";
            string caption = "Salida";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Muestra el Mensaje

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                // Cierra el formulatio
                //Application.Exit();
                Close();
            }
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = LlamarABinario();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            lblResultado.Text = LlamarADecimal();
        }

        /// <summary>
        /// En este metodo se calcula la operación se convierten los datos del formulario
        /// de tipo texto a double, y devuelve su valor en double para que luego se le asigne 
        /// el valor al label, que debera convertir
        /// </summary>
        /// <returns></returns>
        public double ResultadoOperar()
        {
            double n1 = Convert.ToDouble(txtNumero1.Text);
            double n2 = Convert.ToDouble(txtNumero2.Text);
            double res;

            Numero myNumero1 = new Numero(n1);
            Numero myNumero2 = new Numero(n2);

            var calculadora = new Calculadora();

            res = calculadora.Operar(myNumero1, myNumero2, cmbOperador.Text);

            return res;
        }

        public void LimpiarCampos()
        {
            //Limpiando cajas de texto 
            txtNumero1.Clear();
            txtNumero2.Clear();
            //Lipiando asignandole un blanco 
            cmbOperador.Text = "";
            //Volviendo a colocar al lebel la palabra Resultado
            lblResultado.Text = "Resultado";
        }

        public string LlamarABinario()
        {
            double n1 = Convert.ToDouble(lblResultado.Text);
            return Numero.DecimalBinario(n1);
        }

        public string LlamarADecimal()
        {
            double n1;
            n1 = Numero.BinarioDecimal(lblResultado.Text);
            return n1.ToString();

        }
    }
}
