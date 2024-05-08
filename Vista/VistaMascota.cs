using System.Windows.Forms;

namespace Veterinaria.Vista
{
    public partial class VistaMascota : Form, IVistaMascota
    {
        //Campos
        private string message;
        private bool isSuccessful; 
        private bool isEdit;
        //Constructor
        public VistaMascota()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabPetList.TabPages.Remove(tabPage2);
            //btnClose.Click += delegate { this.Close(); };
        }
        private void AssociateAndRaiseViewEvents()
        {
            btnBuscar.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            txtBuscar.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            btnCerrar.Click += delegate { this.Close(); };
            //Others
            btnAgregar.Click += delegate {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabPetList.TabPages.Remove(tabPage1);
                tabPetList.TabPages.Add(tabPage2);
                tabPage2.Text = "Agregar nueva mascota";
            };


            btnEditar.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabPetList.TabPages.Remove(tabPage1);
                tabPetList.TabPages.Add(tabPage2);
                tabPage2.Text = "Edit pet";
            };

            btnEliminar.Click += delegate { 
                var resultado = MessageBox.Show("Estas seguro que queres borrar esta mascota?", "Warning", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };

            btnGuardar.Click += delegate { 
                SaveEvent?.Invoke(this, EventArgs.Empty); 
                if (IsSuccessful)
                {
                    tabPetList.TabPages.Remove(tabPage2);
                    tabPetList.TabPages.Add(tabPage1);
                }
                MessageBox.Show(Message);
            };
            btnCancelar.Click += delegate { 
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabPetList.TabPages.Remove(tabPage2);
                tabPetList.TabPages.Add(tabPage1);
            };
        }

        //Properties
        public string Id { get => this.txtId.Text; set => this.txtId.Text = value; }
        public string MascotaColor { get => this.txtColor.Text; set => this.txtColor.Text = value; }
        public string MascotaTipo { get => this.txtTipo.Text; set => this.txtTipo.Text = value; }
        public string MascotaNombre { get => this.txtNombre.Text; set => this.txtNombre.Text = value; }
        public string ValorBusqueda { get => this.txtBuscar.Text; set => this.txtBuscar.Text = value; }
        public bool IsEdit { get => isEdit; set => isEdit = value; }
        public bool IsSuccessful { get => isSuccessful; set => isSuccessful = value; }
        public string Message { get => message; set => message = value; }

        //Eventos

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;


        //Metodos
        public void SetPetListBindingSource(BindingSource petList)
        {
            dataGridView1.DataSource = petList;
        }

        public void Mostrar()
        {
            this.Show();
        }

        //Singleton
        private static VistaMascota instancia;

        public static VistaMascota GetInstance(Form parentContainer)
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new VistaMascota();
                instancia.MdiParent = parentContainer;
                instancia.FormBorderStyle = FormBorderStyle.None;
                instancia.Dock = DockStyle.Fill;
            }
               
                
            else
            {
                if(instancia.WindowState == FormWindowState.Minimized)
                    instancia.WindowState = FormWindowState.Normal;
                instancia.BringToFront();

            }
            return instancia;
        }


    }
}
