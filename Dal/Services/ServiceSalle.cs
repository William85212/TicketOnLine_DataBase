using Dal.Irepo;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Dal.Services
{
    public class ServiceSalle : Irepo<Salles>
    {
        private static ServiceSalle _instance;
        public static ServiceSalle Instance
        {
            get
            {
                _instance = _instance ?? new ServiceSalle();
                return _instance;
            }
        }
        #region SqlConnection

        private SqlConnection _connection;

        protected ServiceSalle()
        {
            _connection = new SqlConnection(@"Data Source=DESKTOP-DLBID37\SQL2019DEV;Initial Catalog=dbtest;Integrated Security=True");
            
            _connection.Open();
        }

        #endregion
        public int Create(Salles salle)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                _connection.Open();
                cmd.CommandText = "insert into Salles output inserted.Id values (@Nom, @Lieux, @Capacite, @Image";
                cmd.Parameters.AddWithValue("Nom", salle.Nom);
                cmd.Parameters.AddWithValue("Lieux", salle.Lieux);
                cmd.Parameters.AddWithValue("Capacite", salle.Capacite);
                cmd.Parameters.AddWithValue("Image", salle.Image);

                return (int)cmd.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                _connection.Open();
                cmd.CommandText = "delete from Salles where Id = @id";
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        public IEnumerable<Salles> GetAll()
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
               // _connection.Open();
                List<Salles> l = new List<Salles>();
                cmd.CommandText = "Select * from Salles ";

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        l.Add(new Salles
                        {
                            Nom = (reader["Nom"] is DBNull ) ? null : (string)reader["Nom"],
                            Lieux = (string)reader["Lieux"],
                            Capacite = (int)reader["Capcite"],
                            Image = (reader["Image"] is DBNull)? null : (string)reader["Lieux"]
                        });
                    }
                    return l;
                }
            }
        }

        public Salles GetById(int id)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                _connection.Open();
                cmd.CommandText = "select * from Salles where Id = @id ";
                cmd.Parameters.AddWithValue("Id", id);
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Salles
                        {
                            Nom = (reader["Nom"] is DBNull) ? null : (string)reader["Nom"],
                            Lieux = (string)reader["Lieux"],
                            Capacite = (int)reader["Capacite"],
                            Image = (reader["Image"] is DBNull) ? null : (string)reader["Lieux"]
                        };
                    }
                    else
                        return null;
                }
            }
        }

        public void Update(Salles salle)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                _connection.Open();
                cmd.CommandText = "update Salles Nom = @Nom, Lieux = @Lieux, Capacite = @Capacite, Image = @Image";
                cmd.Parameters.AddWithValue("Nom", salle.Nom);
                cmd.Parameters.AddWithValue("Lieux", salle.Lieux);
                cmd.Parameters.AddWithValue("Capacite", salle.Capacite);
                cmd.Parameters.AddWithValue("Image", salle.Image);

                cmd.ExecuteNonQuery();

            }
        }
    }
}
