namespace Veterinaria.Modelo
{
    public interface IRepositorioMascotas
    {
        void Add(ModeloMascota modeloMascota);
        void Edit(ModeloMascota modeloMascota);
        void Delete(int id);
        IEnumerable<ModeloMascota> GetAll();
        IEnumerable<ModeloMascota> GetByValue(string value);
    }
}