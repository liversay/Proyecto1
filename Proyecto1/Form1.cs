namespace Proyecto1
{
    public partial class Calculadora : Form
    {
        Eventos evento = new Eventos();
        double primerNumero = 0;
        double segundoNumero = 0;
        string operador = "";
        double resultado = 0;
        bool esNuevoNumero = false;

        public Calculadora()
        {
            InitializeComponent();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            btnNumeroClick(sender);
            //evento.ingresarTexto(txtOperacion, btn0);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            btnNumeroClick(sender);
            //evento.ingresarTexto(txtOperacion, btn1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            btnNumeroClick(sender);
            //evento.ingresarTexto(txtOperacion, btn2);
        }

        private void btn3_Click_1(object sender, EventArgs e)
        {
            btnNumeroClick(sender);
            //evento.ingresarTexto(txtOperacion, btn3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            btnNumeroClick(sender);
            //evento.ingresarTexto(txtOperacion, btn4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            btnNumeroClick(sender);
            //evento.ingresarTexto(txtOperacion, btn5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            btnNumeroClick(sender);
            //evento.ingresarTexto(txtOperacion, btn6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            btnNumeroClick(sender);
            //evento.ingresarTexto(txtOperacion, btn7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            btnNumeroClick(sender);
            //evento.ingresarTexto(txtOperacion, btn8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            btnNumeroClick(sender);
            //evento.ingresarTexto(txtOperacion, btn9);
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            //agregar la eliminacion del historial
            txtResultado.Clear();
            txtOperacion.Clear();
            primerNumero = 0;
            segundoNumero = 0;
            operador = "";
            resultado = 0;
            esNuevoNumero = false;
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txtResultado.Clear();
            //txtOperacion.Clear();
            primerNumero = 0;
            segundoNumero = 0;
            operador = "";
            resultado = 0;
            esNuevoNumero = false;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text.Length > 0)
            {
                txtResultado.Text = txtResultado.Text.Substring(0, txtResultado.Text.Length - 1);
            }
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            evento.ingresarTexto(txtOperacion, btnDivision);
            btnOperadorClick(sender);
        }

        private void btnMultiplicacion_Click(object sender, EventArgs e)
        {
            evento.ingresarTexto(txtOperacion, btnMultiplicacion);
            btnOperadorClick(sender);
        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            evento.ingresarTexto(txtOperacion, btnResta);
            btnOperadorClick(sender);
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtResultado.Text))
            {
                segundoNumero = Convert.ToDouble(txtResultado.Text);

                switch (operador)
                {
                    case "+":
                        resultado = primerNumero + segundoNumero;
                        break;
                    case "-":
                        resultado = primerNumero - segundoNumero;
                        break;
                    case "*":
                        resultado = primerNumero * segundoNumero;
                        break;
                    case "/":
                        if (segundoNumero != 0)  // Verifica que no se divida entre 0
                        {
                            resultado = primerNumero / segundoNumero;
                        }
                        else
                        {
                            MessageBox.Show("Error: División por cero no permitida.");
                            return;
                        }
                        break;
                    case "^":
                        resultado = Math.Pow(primerNumero, segundoNumero);
                        break;
                    default:
                        MessageBox.Show("Operador no válido.");
                        break;
                }

                txtOperacion.Text = primerNumero + " " + operador + " " + segundoNumero + " =";
                txtResultado.Text = resultado.ToString();
                esNuevoNumero = true;
            }
        }

        private void btnSuma_Click(object sender, EventArgs e)
        {
            evento.ingresarTexto(txtOperacion, btnSuma);
            btnOperadorClick(sender);
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            if (!txtResultado.Text.Contains("."))
            {
                if (string.IsNullOrEmpty(txtResultado.Text))
                {
                    txtResultado.Text = "0.";
                }
                else
                {
                    txtResultado.Text += ".";
                }
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            evento.ingresarTexto(txtOperacion, btnPI);
        }

        private void btnOperadorClick(object sender)
        {
            if (!string.IsNullOrEmpty(txtResultado.Text))
            {
                // Guardar el primer número y el operador seleccionado
                primerNumero = Convert.ToDouble(txtResultado.Text);
                Button btnOperador = (Button)sender;
                operador = btnOperador.Text;

                // Mostrar la operación en txtOperacion
                txtOperacion.Text = primerNumero + " " + operador;
                txtResultado.Clear(); // Limpiar txtResultado para el segundo número
            }
        }

        private void btnNumeroClick(object sender)
        {
            Button btnNumero = (Button)sender;

            if (esNuevoNumero)
            {
                txtResultado.Clear();
                esNuevoNumero = false;
            }

            evento.ingresarTexto(txtResultado, btnNumero);
        }

        private void btnSigno_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtResultado.Text))
            {
                double numero = Convert.ToDouble(txtResultado.Text);
                numero = -numero;
                txtResultado.Text = numero.ToString();
            }
        }

        private void btnPotencia_Click(object sender, EventArgs e)
        {
            try
            {
                primerNumero = Convert.ToDouble(txtResultado.Text);
                txtOperacion.Text = primerNumero + "^";
                operador = "^";
                txtResultado.Clear();
            }
            catch (Exception) {
                MessageBox.Show("Primero agregue el número al cual desea sacarle potencia");
            }
        }

        private void btnRaiz_Click(object sender, EventArgs e)
        {
            try
            {
                double numero = Convert.ToDouble(txtResultado.Text);

                if (numero >= 0)
                {
                    resultado = Math.Sqrt(numero);
                    txtOperacion.Text = "\u221A(" + numero + ")";
                    txtResultado.Text = resultado.ToString();
                    esNuevoNumero = true;
                }
                else
                {
                    MessageBox.Show("Error: No se puede calcular la raíz cuadrada de un número negativo.");
                }
            }
            catch (Exception) {
                MessageBox.Show("Primero agregue el número al cual desea sacarle raíz");
            }
        }
    }
}
