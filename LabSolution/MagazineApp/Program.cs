using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Magazine.Services;
using Magazine.Persistence;

namespace MagazineApp
{
    static class Program
    { 
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IMagazineISWService service = new MagazineISWService(new EntityFrameworkDAL(new MagazineDbContext()));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BaseForm baseForm = new UnLoggedForm(service);
            Application.Run(baseForm);
        }
    }
}
