using Veterinaria.Modelo;
using Veterinaria.Vista;
using Veterinaria._Repositorios;
using System.Configuration;
using Veterinaria.Presentador;

namespace Veterinaria
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();
            string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString; 

            IVistaPrincipal vista = new VistaPrincipal();
            new PresentadorPrincipal(vista, sqlConnectionString);

            Application.Run((Form)vista);
        }
    }
}