using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Vista;
using Veterinaria.Modelo;
using Veterinaria._Repositorios;

namespace Veterinaria.Presentador
{
    internal class PresentadorPrincipal
    {

        private IVistaPrincipal vistaPrincipal;
        private readonly string SqlConnectionString;

        public PresentadorPrincipal(IVistaPrincipal vistaPrincipal, string SqlConnectionString)
        {
            this.SqlConnectionString = SqlConnectionString;
            this.vistaPrincipal = vistaPrincipal;
            this.vistaPrincipal.showPetView += ShowPetsView;
            
        }

        private void ShowPetsView(object sender, EventArgs e)
        {
            IVistaMascota vista = VistaMascota.GetInstance((VistaPrincipal)vistaPrincipal);
            IRepositorioMascotas repositorio = new RepostorioMascotas(SqlConnectionString);
            new PresentadorMascota(vista, repositorio);
        }
    }
}
