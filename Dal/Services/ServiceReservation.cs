using Dal.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Dal.Services
{
    public class ServiceReservation
    {
        #region pinacle
        private static ServiceReservation _instance;

        public static ServiceReservation Instance
        {
            get
            {
                _instance = _instance ?? new ServiceReservation();
                return _instance;
            }
        }

        private SqlConnection _connection;

        protected ServiceReservation()
        {
            _connection = new SqlConnection(@"Data Source=DESKTOP-DLBID37\SQL2019DEV;Initial Catalog=amelioration;Integrated Security=True");
            _connection.Open();
        }
#endregion

        public int Create(Reservation reservation)
        {
            using (SqlCommand cmd = _connection.CreateCommand() )
            {
                cmd.CommandText = "insert into Reservation output inserted.Id values (@Date, @NbrPlace, @Idclient, @IdEvent, @prixPlace)";
                cmd.Parameters.AddWithValue("Date", reservation.Date);
                cmd.Parameters.AddWithValue("NbrPlace", reservation.NbrPlace);
                cmd.Parameters.AddWithValue("Idclient", reservation.IdClient);
                cmd.Parameters.AddWithValue("IdEvent", reservation.IdEvent);
                cmd.Parameters.AddWithValue("prixTotal", reservation.PrixTotal);

                return (int)cmd.ExecuteScalar();
            }
           
        }

        public Reservation Get(int id)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "select * from Reservation where Id = @id";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Reservation
                        {
                            Date = (DateTime)reader["Date"],
                            NbrPlace =(int)reader["NbrPlace"],
                            IdClient = (int)reader["IdClient"],
                            IdEvent = (int)reader["IdEvent"],
                            PrixTotal = (int)reader["prixTotal"]
                        };
                    }
                    else return null;
                }
            }
        }


        public List<Reservation> Get()
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "select * from Reservation";
                List<Reservation> rl = new List<Reservation>();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rl.Add(new Reservation
                        {
                            Date = (DateTime)reader["Date"],
                            NbrPlace = (int)reader["NbrPlace"],
                            IdClient = (int)reader["IdClient"],
                            IdEvent = (int)reader["IdEvent"],
                            PrixTotal = (int)reader["prixTotal"]
                        });
                    }
                    return rl;
                }
            }
        }
    }
}
