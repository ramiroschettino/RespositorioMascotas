using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Modelo;
using Veterinaria.Repositorios;
using System.Data.SqlClient;
using System.Data;

namespace Veterinaria._Repositorios
{
    public class RepostorioMascotas : RepositorioBase, IRepositorioMascotas
    {

        //Constructor 

        public RepostorioMascotas(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //Metodos
        public void Add(ModeloMascota modeloMascota)
        {

        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public void Edit(ModeloMascota modeloMascota)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<ModeloMascota> GetAll()
        {
            var listaMascota = new List<ModeloMascota>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from pet order by Id_mascotas desc";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read()) {
                        var petModel = new ModeloMascota();
                        petModel.Id = (int)reader["Id_mascotas"];
                        petModel.Nombre = reader["nombre"].ToString();
                        petModel.Tipo = reader["tipo"].ToString();
                        petModel.Color = reader["color"].ToString();
                        listaMascota.Add(petModel);
                    }
                }
            }
            return listaMascota;
        }
        public IEnumerable<ModeloMascota> GetByValue(string value)
        {
            var listaMascota = new List<ModeloMascota>();
            int Id = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string Nombre = value;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"Select * from pet" +
                                        " where Id_mascotas = @id or nombre like @name+'%'" +
                                        " order by Id_mascotas desc";

                command.Parameters.Add("@id", SqlDbType.Int ).Value = Id;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = Nombre;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var petModel = new ModeloMascota();
                        petModel.Id = (int)reader["Id_mascotas"];
                        petModel.Nombre = reader["nombre"].ToString();
                        petModel.Tipo = reader["tipo"].ToString();
                        petModel.Color = reader["color"].ToString();
                        listaMascota.Add(petModel);
                    }
                }
            }
            return listaMascota;
        }
    }
}
