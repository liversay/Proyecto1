
using System.Runtime.InteropServices.ObjectiveC;

namespace Proyecto1
{
    public class Eventos
    {
        public void ingresarTexto(TextBox txt, Button btn)
        {
            txt.Text = txt.Text + btn.Text;
        }
    }
}
