using Veterinaria.Modelo;
using Veterinaria.Vista;
using Veterinaria.Presentador.Comun;
using System.Windows.Forms;

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
            this.vista.CancelEvent += CancelAction;

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
            vista.IsEdit = false;
        }


        private void CancelAction(object? sender, EventArgs e)
        {
            CleanviewFields();
        }

        private void DeleteEvent(object? sender, EventArgs e)
        {
            try
            {
                var pet = (ModeloMascota)mascotasBindingSource.Current;
                repositorio.Delete(pet.Id);
                vista.IsSuccessful = true;
                vista.Message = "Mascota borrada satisfactoriamente";
                CargarTodoListaMascotas();
            }
            catch (Exception ex){
                vista.IsSuccessful = false;
                vista.Message = "Hubo un error, no se pudo borrar";
            }

        }

        private void EditEvent(object? sender, EventArgs e)
        {
            var pet = (ModeloMascota)mascotasBindingSource.Current;
            vista.Id = pet.Id.ToString();
            vista.MascotaNombre = pet.Nombre;
            vista.MascotaTipo = pet.Tipo;
            vista.MascotaColor = pet.Color;
            vista.IsEdit = true;
        }

        private void CleanviewFields()
        {
   
            vista.MascotaNombre = "";
            vista.MascotaTipo = "";
            vista.MascotaColor = "";
        }

        private void SaveEvent(object? sender, EventArgs e)
        {
            var model = new ModeloMascota();
            model.Nombre = vista.MascotaNombre;
            model.Tipo = vista.MascotaTipo;
            model.Color = vista.MascotaColor;
            model.Id = Int32.Parse(vista.Id);
            try{
                new Comun.ModelDataValidation().Validate(model);
                if (vista.IsEdit)
                {
                    repositorio.Edit(model);
                    vista.Message = "Mascota editada satisfactoriamente";
                } else
                {
                    repositorio.Add(model);
                    vista.Message = "Mascota agregada satisfactoriamente";
                }
                vista.IsSuccessful = true;
                CargarTodoListaMascotas();
                CleanviewFields();

            } catch (Exception ex)
            {
                vista.IsSuccessful= false;
                vista.Message= ex.Message;
            }
        }


    }
}
