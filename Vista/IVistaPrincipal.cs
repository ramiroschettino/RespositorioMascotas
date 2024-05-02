using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Vista
{
    internal interface IVistaPrincipal
    {
        event EventHandler showPetView;
        event EventHandler showOwnerView;
        event EventHandler showVetsView;
    }
}
