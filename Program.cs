using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DMSoft; // Agregar

namespace Sistema_de_control
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DMSoft.SkinCrafter.Init();
            DMSoft.SkinCrafter SkinOb = new DMSoft.SkinCrafter();
            SkinOb.InitLicenKeys("SKINCRAFTER", "SKINCRAFTER.COM",
            "esupport@skincrafter.com", "DEMOSKINCRAFTERLICENCE");
            SkinOb.InitDecoration(true);
            SkinOb.LoadSkinFromFile("SkinasticST.skf"); // nombre del skin a aplicar
            SkinOb.ApplySkin();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            SkinOb.DeInitDecoration();
            DMSoft.SkinCrafter.Terminate();
        }
    }
}
