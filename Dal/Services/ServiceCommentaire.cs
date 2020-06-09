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
            _connection = new SqlConnection(@"Data Source=DESKTOP-DLBID37\SQL2019DEV;Initial Catalog=db3;Integrated Security=True");
            _connection.Open();
        }

        public Commentaire GetById(int id)
        {
            throw new NotImplementedException();
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
                cmd.CommandText = "insert into Commentaire output inserted.Id values (@Commentaire, @IdClient, @IdEvent)";
                cmd.Parameters.AddWithValue("Commentaire", c.Commentaires);
                cmd.Parameters.AddWithValue("IdClient", c.IdClient);
                cmd.Parameters.AddWithValue("IdEvent", c.IdEvent);

                return (int)cmd.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Commentaire entity)
        {
            throw new NotImplementedException();
        }
    }
}
