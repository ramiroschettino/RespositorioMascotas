public interface IVistaMascota
{
    //public string MascotaId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    string MascotaNombre { get; set; }
    string MascotaTipo { get; set; }
    string MascotaColor { get; set; }
    string ValorBusqueda { get; set; }
    bool IsEdit { get; set; }
    bool IsSuccessful { get; set; }
    string Message { get; set; }
    //Events
    event EventHandler SearchEvent;
    event EventHandler AddNewEvent;
    event EventHandler EditEvent;
    event EventHandler DeleteEvent;
    event EventHandler SaveEvent;
    event EventHandler CancelEvent;
    //Methods
    void SetPetListBindingSource(BindingSource petList);

    void Mostrar();
}