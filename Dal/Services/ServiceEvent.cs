using Dal.Irepo;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Dal.Services
{
    public class ServiceEvent : Irepo<Evenement>
    {

        #region singleton 

        private static ServiceEvent _instance;

        public static ServiceEvent Instance
        {
            get
            {
                _instance = _instance ?? new ServiceEvent();
                return _instance;
            }
        }


        #endregion

        #region SqlConnection

        private SqlConnection _connection;

        protected ServiceEvent()
        {
            _connection = new SqlConnection(@"Data Source=DESKTOP-DLBID37\SQL2019DEV;Initial Catalog=db3;Integrated Security=True");
            _connection.Open();
        }

        #endregion


        #region create 
        public int Create(Evenement e)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "insert into Event output inserted.Id values ( @NomSpectacle, @Realisateur, @Description, @Duree, @PlaceRestante, @Image, @Prix)";
                cmd.Parameters.AddWithValue("NomSpectacle", e.NomSpectacle);
                cmd.Parameters.AddWithValue("Realisateur", e.Realisateur);
                cmd.Parameters.AddWithValue("Description", e.Description);
                cmd.Parameters.AddWithValue("Duree",e.Duree);
                cmd.Parameters.AddWithValue("PlaceRestante", e.PlaceRestante);
                cmd.Parameters.AddWithValue("Image", e.Image);
                cmd.Parameters.AddWithValue("Prix", e.Prix);

                return (int)cmd.ExecuteScalar();
            }
        }

        #endregion

        #region Delete 

        public void Delete(int id)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "delete from Event where id = @Id";
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }

        #endregion


        #region get( *, 1 , name)
        public IEnumerable<Evenement> GetAll()
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "select * from Event";
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<Evenement> l = new List<Evenement>();
                    while (reader.Read())
                    {
                        l.Add(new Evenement
                        {
                            Id = (int)reader["Id"],
                            NomSpectacle =(string)reader["NomSpectacle"],
                            Realisateur =(string)reader["Realisateur"],
                            Description =(string)reader["Description"],
                            Duree =(TimeSpan)reader["Duree"],
                            PlaceRestante =(int)reader["PlaceRestante"],
                            Prix =(int)reader["prix "],
                            Image = (reader["Image"] is DBNull)? null : (string)reader["Image"],
                        });
                    }
                    return l;
                }
            }
        }

        public Evenement GetById(int id)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "select * from Event where Id = @id";
                cmd.Parameters.AddWithValue("id", id);
                //_connection.Open();
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Evenement
                        {
                            Id = (int)reader["Id"],
                            NomSpectacle = (string)reader["NomSpectacle"],
                            Realisateur = (string)reader["Realisateur"],
                            Description = (string)reader["Description"],
                            Duree = (TimeSpan)reader["Duree"],
                            PlaceRestante = (int)reader["PlaceRestante"],
                            Image = (reader["Image"] is DBNull) ? null : (string)reader["Image"],
                            Prix = (int)reader["prix "]
                        };
                    }
                    return null;
                }
            }
        }

        public Evenement GetByName(string name)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "select *from Event where Nom = @name";
                cmd.Parameters.AddWithValue("name", name);
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Evenement
                        {
                            Id = (int)reader["Id"],
                            NomSpectacle = (string)reader["NomSpectacle"],
                            Realisateur = (string)reader["Ralisateur"],
                            Description = (string)reader["Description"],
                            Duree = (TimeSpan)reader["Duree"],
                            PlaceRestante = (int)reader["PlaceRestance"],
                            Image = (reader["Image"] is DBNull) ? null : (string)reader["Image"],
                            Prix = (int)reader["prix "]
                        };
                    }
                    return null;
                }
            }
        }

        #endregion


        public void Update(Evenement e)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "update Event NomSpectacle = @NomSpectacle, Realisateur = @Realisateur, Description = @Description , PlaceRestante = @PlaceRestante, IdSalle = @IdSalle, Image = @Image";
                cmd.Parameters.AddWithValue("NomSpectecle", e.NomSpectacle);
                cmd.Parameters.AddWithValue("Realisateur", e.Realisateur);
                cmd.Parameters.AddWithValue("Description", e.Description);
                cmd.Parameters.AddWithValue("Duree", e.Duree);
                cmd.Parameters.AddWithValue("PlaceRestante", e.PlaceRestante);
                cmd.Parameters.AddWithValue("Image", e.Image);



                cmd.ExecuteNonQuery();
            }
        }

        public List<DateEvent> GetInfoEvent(int id)//date
        {
            using (SqlCommand cmd = _connection.CreateCommand()) 
            {
                cmd.CommandText = "select d.date from Event e join DateEvent d on d.IdEvent = e.Id where e.Id = @id";
                cmd.Parameters.AddWithValue("id", id);
                List<DateEvent> lE = new List<DateEvent>();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lE.Add(new DateEvent
                        {
                            DateRepresentation = (DateTime)reader["Date"]
                        });
                    }
                    return lE;
                }
            }
        }

        public List<infoReservation> GetInfoReservation(int id)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "select de.date, s.Nom from Event e join DateEvent de on de.IdEvent = e.Id join Salles s on s.Id = de.IdSalle where e.Id = @id";
                cmd.Parameters.AddWithValue("id", id);

                List<infoReservation> lir = new List<infoReservation>();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lir.Add(new infoReservation
                        {
                            DateRepresentetion = (DateTime)reader["date"],
                            NomEvent = (string)reader["Nom"]
                        });
                    }
                    return lir;
                }
            }
        }
    


        public List<Evenement> GetEventByIdSalle(int id)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "select e.* from Event e join DateEvent de on e.Id = de.IdEvent where de.IdSalle = @id";
                cmd.Parameters.AddWithValue("id", id);
                List<Evenement> Le = new List<Evenement>();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Le.Add(new Evenement
                        {
                            Id = (int)reader["Id"],
                            NomSpectacle = (string)reader["NomSpectacle"],
                            Realisateur = (string)reader["Realisateur"],
                            Description = (string)reader["Description"],
                            Duree = (TimeSpan)reader["Duree"],
                            PlaceRestante = (int)reader["PlaceRestante"],
                            Image = (reader["Image"] is DBNull) ? null : (string)reader["Image"],
                            Prix = (int)reader["prix "]
                        });
                    }
                    return Le;
                }
            }
        }
    }
}
