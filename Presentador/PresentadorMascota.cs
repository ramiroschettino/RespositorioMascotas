using Veterinaria.Modelo;
using Veterinaria.Vista;

namespace Veterinaria.Presentador
{
    public class PresentadorMascota
    {
        //Campos

        private IVistaMascota vista;
        private IRepositorioMascotas repositorio;
        private BindingSource mascotasBindingSource;
        private IEnumerable<ModeloMascota> listaMascotas;


        //Constructor
        public PresentadorMascota(IVistaMascota vista, IRepositorioMascotas repositorio)
        {

            this.mascotasBindingSource = new BindingSource();
            this.vista = vista;
            this.repositorio = repositorio;

            //Le mando los event handlers a los eventos de la vista
            this.vista.SearchEvent += BuscarMascota;
            this.vista.AddNewEvent += AddNewEvent;
            this.vista.DeleteEvent += DeleteEvent;
            this.vista.EditEvent += EditEvent;
            this.vista.SaveEvent += SaveEvent;

            //Seteo el binding source
            this.vista.SetPetListBindingSource(this.mascotasBindingSource);

            //Cargar la vista de la lista de mascotas
            CargarTodoListaMascotas();

            //Mostrar Lista
            this.vista.Mostrar();
        }

        private void CargarTodoListaMascotas()
        {
            listaMascotas = repositorio.GetAll();
            mascotasBindingSource.DataSource = listaMascotas;
        }

        private void BuscarMascota(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.vista.ValorBusqueda);
            if (emptyValue == false) {
                listaMascotas = repositorio.GetByValue(this.vista.ValorBusqueda);
            } else
            {
                listaMascotas = repositorio.GetAll();
            }
            mascotasBindingSource.DataSource = listaMascotas;
        }

        private void AddNewEvent(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteEvent(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void EditEvent(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SaveEvent(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


    }
}
