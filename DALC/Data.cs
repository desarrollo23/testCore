using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DALC
{
    public static class Data
    {
        private static SqlConnection con = new SqlConnection("Server=localhost;Database=api;Trusted_Connection=True;");

        public static List<Pais> ObtenerPaises()
        {
            var lstPiases = new List<Pais>();

            try
            {
                SqlCommand command = new SqlCommand();
                con.Open();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "ObtenerPaises";
                command.Connection = con;

                var data = command.ExecuteReader();

                while(data.Read())
                {
                    var pais = new Pais
                    {
                        IdPais = data.GetInt32(0),
                        NombrePais = data.GetString(1)
                    };

                    lstPiases.Add(pais);
                }

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return lstPiases;
        }

        public static bool CrearPais(Pais pais)
        {
            try
            {
                SqlCommand command = new SqlCommand();

                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@NombrePais", pais.NombrePais);

                con.Open();

                command.Parameters.AddRange(parameters);

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "CrearPais";
                command.Connection = con;

                var reg = command.ExecuteNonQuery();

                return reg > 0;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
