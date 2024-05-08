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
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Insert into Pet values (@nombre,@tipo,@color)";
                command.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = modeloMascota.Nombre;
                command.Parameters.Add("@tipo", SqlDbType.NVarChar).Value = modeloMascota.Tipo;
                command.Parameters.Add("@color", SqlDbType.NVarChar).Value = modeloMascota.Color;

                command.ExecuteNonQuery();
            }

        }
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "delete from Pet where id_mascotas = @id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;


                command.ExecuteNonQuery();
            }
        }
        public void Edit(ModeloMascota modeloMascota)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "update Pet set Nombre = @nombre,Tipo = @tipo,Color = @color where Id_mascotas = @id;";
                command.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = modeloMascota.Nombre;
                command.Parameters.Add("@tipo", SqlDbType.NVarChar).Value = modeloMascota.Tipo;
                command.Parameters.Add("@color", SqlDbType.NVarChar).Value = modeloMascota.Color;
                command.Parameters.Add("@id", SqlDbType.Int).Value = modeloMascota.Id;

                command.ExecuteNonQuery();
            }
        }
        //Terminar esto
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
