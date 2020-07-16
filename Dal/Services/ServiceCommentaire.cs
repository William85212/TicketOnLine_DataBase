using Dal.Irepo;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Dal.Services
{
    public class ServiceCommentaire : Irepo<Commentaire>
    {
        private static ServiceCommentaire _instance;
        public static ServiceCommentaire Istance
        {
            get
            {
                _instance = _instance ?? new ServiceCommentaire();
                return _instance;
            }
        }

        public SqlConnection _connection;

        public ServiceCommentaire()
        {
            _connection = new SqlConnection(@"Data Source=DESKTOP-DLBID37\SQL2019DEV;Initial Catalog=amelioration;Integrated Security=True");
            _connection.Open();
        }

        public Commentaire GetById(int id)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "Select * from Commentaire where Id = @id";
                cmd.Parameters.AddWithValue("id", id);
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Commentaire
                        {
                            Id = (int)reader["Id"],
                            Commentaires = (string)reader["Commentaire"],
                            Jaime = (reader["Jaime"] is DBNull) ? 0 : (int)reader["Jaime"],
                            JaimePas = (reader[""] is DBNull) ? 0 : (int)reader["JaimePas"],
                            IdClient = (int)reader["IdClient"],
                            IdEvent = (int)reader["IdEvent"]
                            //Image = (reader["Image"] is DBNull) ? null : (string)reader["Image"],
                        };
                    }
                    else return null;
                }
            }
        }

        public IEnumerable<Commentaire> GetAll()
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "Select * from Commentaire";
                List<Commentaire> c = new List<Commentaire>();
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        c.Add(new Commentaire
                        {
                            Id =  (int)reader["Id"],
                            Commentaires =  (string)reader["Commentaire"],
                            Jaime = (int)reader["Jaime"],
                            JaimePas = (int)reader["JaimePas"],
                            IdClient =  (int)reader["IdClient"],
                            IdEvent =  (int)reader["IdEvent"]
                        });
                    }
                    return c; 
                }
            }
        }

        public int Create(Commentaire c)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "insert into Commentaire output inserted.Id values (@Commentaire, @Jaime, @JaimePas, @IdClient, @IdEvent)";
                cmd.Parameters.AddWithValue("Commentaire", c.Commentaires);
                cmd.Parameters.AddWithValue("Jaime", c.Jaime);
                cmd.Parameters.AddWithValue("JaimePas", c.JaimePas);
                cmd.Parameters.AddWithValue("IdClient", c.IdClient);
                cmd.Parameters.AddWithValue("IdEvent", c.IdEvent);

                return (int)cmd.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "delete from Commentaire where Id = @id";
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Commentaire entity)
        {
            throw new NotImplementedException();
        }
    }
}
