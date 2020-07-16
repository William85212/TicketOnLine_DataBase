using Dal.Irepo;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Dynamic;
using System.Text;

namespace Dal.Services
{
    public class ServiceClient : Irepo<Clients>
    {
        #region singleton
        private static ServiceClient _instance;

        public static ServiceClient Istance
        {
            get
            {
                _instance = _instance ?? new ServiceClient();
                return _instance;
            }
        }

        #endregion

        #region sqlConnection

        private SqlConnection _connection;
        protected ServiceClient()
        {
            _connection = new SqlConnection(@"Data Source=DESKTOP-DLBID37\SQL2019DEV;Initial Catalog=amelioration;Integrated Security=True");
            _connection.Open();
        }

        #endregion

        #region create

        public int Create(Clients client)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "insert into client output inserted.Id values(@Nom, @Prenom, @DateNaissance, @Sexe, @Adresse, @Email, @IsActive, @IsAdmin, @Password ) ";
              // cmd.Parameters.AddWithValue("id", client.Id);
                cmd.Parameters.AddWithValue("Nom", client.Nom);
                cmd.Parameters.AddWithValue("Prenom",client.Prenom);
                cmd.Parameters.AddWithValue("DateNaissance", client.DateNaisance);
                cmd.Parameters.AddWithValue("Sexe",client.Sexe);
                cmd.Parameters.AddWithValue("Adresse",client.Adresse);
                cmd.Parameters.AddWithValue("Email",client.Email);
                cmd.Parameters.AddWithValue("IsActive",1);
                cmd.Parameters.AddWithValue("IsAdmin", 0);
                cmd.Parameters.AddWithValue("Password", client.Password);

                return (int)cmd.ExecuteScalar();
            }
        }
        #endregion

        #region Get (id, all , name)

        public IEnumerable<Clients> GetAll()
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "select * from Client ";
                using(SqlDataReader reader= cmd.ExecuteReader())
                {
                    List<Clients> l = new List<Clients>();
                    while (reader.Read())
                    {
                        l.Add(new Clients
                        {
                            Id = (int)reader["Id"],
                            Nom = (string)reader["Nom"],
                            Prenom = (string)reader["Prenom"],
                            DateNaisance = (DateTime)reader["DateNaissance"],
                            Sexe = (string)reader["Sexe"],
                            Adresse = (string)reader["Adresse"],
                            Email = (string)reader["Email"],
                            IsActive = (bool)reader["IsActive"],
                            IsAdmin = (bool)reader["IsAdmin"],
                            Password = (string)reader["Password"]
                        });
                    }
                    return l; 
                }
            }
        }

        public Clients GetById(int id)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "select * from Client where Id = @id";
                cmd.Parameters.AddWithValue("id", id);
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Clients
                        {
                            Id = (int)reader["Id"],
                            Nom = (string)reader["Nom"],
                            Prenom = (string)reader["Prenom"],
                            DateNaisance = (DateTime)reader["DateNaissance"],
                            Sexe = (string)reader["Sexe"],
                            Adresse = (string)reader["Adresse"],
                            Email = (string)reader["Email"],
                            IsActive = (bool)reader["IsActive"],
                            IsAdmin = (bool)reader["IsAdmin"],
                            Password = (string)reader["Password"]
                        };
                    }
                    return null;
                }

            }
        }

        public Clients GetByName(string name)
        {
            using(SqlCommand cmd  = _connection.CreateCommand())
            {
                cmd.CommandText = "select * from Clients where Nom = @name";
                cmd.Parameters.AddWithValue("name", name);
                using( SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Clients
                        {
                            Nom = (string)reader["Nom"],
                            Prenom = (string)reader["Prenom"],
                            DateNaisance = (DateTime)reader["DateNaissance"],
                            Sexe = (string)reader["Sexe"],
                            Adresse = (string)reader["Adresse"],
                            Email = (string)reader["Email"],
                            IsActive = (bool)reader["IsActive"],
                            IsAdmin = (bool)reader["IsAdmin"],
                            Password = (string)reader["Password"]
                        };
                    }
                    return null;
                }

            }
        }

        #endregion  

        #region delete

        public void Delete(int id)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "delete from Client where Id = @id";
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }

        #endregion

        #region Update 
        public void Update(Clients c)
        {
           using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "update Client Nom = @Nom, Prenom = @Prenom, DateNaissance = @DateNaissance, Sexe = @Sexe, Adresse = @Adresse, Email = @Email";
                cmd.Parameters.AddWithValue("Nom", c.Nom);
                cmd.Parameters.AddWithValue("Prenom", c.Prenom);
                cmd.Parameters.AddWithValue("DateNaissance", c.DateNaisance);
                cmd.Parameters.AddWithValue("Sexe", c.Sexe);
                cmd.Parameters.AddWithValue("Adresse", c.Adresse);
                cmd.Parameters.AddWithValue("Email", c.Email);

                cmd.ExecuteNonQuery();
            }
        }

        #endregion

    }
}
