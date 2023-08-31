using System;
using System.Collections.Generic;
using System.Text;
// Agregar la siguiente namespace
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Sistema_de_control
{
    class Generales
    {
        // Metodo que permite en ingreso solo de valores numericos
        public void soloNumero(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;
            if (e.KeyChar == 8) e.Handled = false;
        }

        // Metodo que permite el ingreso de valores monetarios
        public void moneda(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;
            if (e.KeyChar == 8 || e.KeyChar == 46) e.Handled = false;
        }
    }

    // Creamos una clase para el cursor ocupado
    class miCursor
    {
        [DllImport("user32.dll", EntryPoint = "LoadCursorFromFileW", CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr LoadCursorFromFile(string filename);

        public static Cursor Crear(string filename)
        {
            IntPtr hCursor = default(IntPtr);
            Cursor result = null;

            try
            {
                hCursor = LoadCursorFromFile(filename);
                if (!IntPtr.Zero.Equals(hCursor))
                {
                    result = new Cursor(hCursor);
                }
                else
                {
                    throw new ApplicationException("No es posible visualizar el cursor: " + filename);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!");
            }

            return result;
        }
    }
}
