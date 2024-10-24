
using System.Data;
using System.Data.SqlClient;

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

        string connectionString = @"Server=.\sqlexpress;Database=Calculadora;TrustServerCertificate=true;Integrated Security=SSPI;";
        SqlConnection conexion;

        public Calculadora()
        {
            InitializeComponent();
            InitializeDatabase();
        }
        private void InitializeDatabase()
        {
            try
            {
                conexion = new SqlConnection(connectionString);
                conexion.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}");
            }
        }

        private void GuardarOperacion(double primerNumero, double segundoNumero, string operador, double resultado)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Calculos (Operacion, Resultado) VALUES (@Operacion, @Resultado)", conexion))
                {
                    string operacion = $"{primerNumero} {operador} {segundoNumero}";
                    cmd.Parameters.AddWithValue("@Operacion", operacion);
                    cmd.Parameters.AddWithValue("@Resultado", resultado);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la operación: {ex.Message}");
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (conexion != null && conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            btnNumeroClick(sender);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            btnNumeroClick(sender);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            btnNumeroClick(sender);
        }

        private void btn3_Click_1(object sender, EventArgs e)
        {
            btnNumeroClick(sender);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            btnNumeroClick(sender);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            btnNumeroClick(sender);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            btnNumeroClick(sender);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            btnNumeroClick(sender);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            btnNumeroClick(sender);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            btnNumeroClick(sender);
        }

        private void btnC_Click(object sender, EventArgs e)
        {
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
                GuardarOperacion(primerNumero, segundoNumero, operador, resultado);
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
            catch (Exception)
            {
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
            catch (Exception)
            {
                MessageBox.Show("Primero agregue el número al cual desea sacarle raíz");
            }
        }

        private void Calculadora_Load(object sender, EventArgs e)
        {

        }

        private void btnPorcentaje_Click(object sender, EventArgs e)
        {

        }
    }
}
