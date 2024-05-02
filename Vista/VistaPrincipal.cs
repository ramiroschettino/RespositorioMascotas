using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veterinaria.Vista
{
    public partial class VistaPrincipal : Form, IVistaPrincipal
    {
        public VistaPrincipal()
        {
            InitializeComponent();
            btnPets.Click += delegate { showPetView?.Invoke(this, EventArgs.Empty); };

        }

        public event EventHandler showPetView;
        public event EventHandler showOwnerView;
        public event EventHandler showVetsView;
    }
}
