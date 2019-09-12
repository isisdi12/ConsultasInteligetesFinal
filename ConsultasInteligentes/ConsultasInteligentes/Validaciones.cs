using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDiseno
{
    public class validaciones
    {
        public void SOLOLETRAS(KeyPressEventArgs V)
        {
            try
            {
                if (char.IsLetter(V.KeyChar))
                {
                    V.Handled = false;
                }

                else if (char.IsControl(V.KeyChar))
                {
                    V.Handled = false;
                }

                else if (char.IsSeparator(V.KeyChar))
                {
                    V.Handled = false;
                }

                else
                {
                    V.Handled = true;
                    MessageBox.Show("Ingrese solo letras");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error de sistema");
            }
        }

        public void SOLONUMEROS(KeyPressEventArgs V)
        {
            try
            {
                if (char.IsNumber(V.KeyChar))
                {
                    V.Handled = false;
                }

                else if (char.IsControl(V.KeyChar))
                {
                    V.Handled = false;
                }

                else if (char.IsSeparator(V.KeyChar))
                {
                    V.Handled = false;
                }

                else
                {
                    V.Handled = true;
                    MessageBox.Show("Ingrese solo numeros");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema");

            }


        }
    }
}
