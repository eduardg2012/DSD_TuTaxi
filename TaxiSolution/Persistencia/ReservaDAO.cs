using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TaxiSolution.Dominio;

namespace TaxiSolution.Persistencia
{
    public class ReservaDAO
    {
        private SqlConnection AbrirConexion() {
            String servidor = ConfigurationManager.AppSettings.Get("ServidorBD"); ;
            String baseDatos = ConfigurationManager.AppSettings.Get("BaseDatos");

            string cadenaConexion = "Data Source=" + servidor + ";Initial Catalog=" + baseDatos + ";Integrated Security=True";
            try
            {
                SqlConnection cn = new SqlConnection(cadenaConexion);
                cn.Open();
                return cn;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private void CerrarConexion(SqlConnection cn)
        {
            try
            {
                cn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Reserva Crear(Reserva reserva) {
            string sentenciasql = "Reserva_Crear";
            Reserva reservaNueva = null;
            using (SqlConnection cn = this.AbrirConexion())
            {
                using (SqlCommand comando = new SqlCommand(sentenciasql, cn))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Numero", reserva.Numero);
                    comando.Parameters.AddWithValue("@IDUsuario", reserva.IDUsuario);
                    comando.Parameters.AddWithValue("@IDChofer", reserva.IDChofer);
                    comando.Parameters.AddWithValue("@FechaHora", reserva.FechaHora);
                    comando.Parameters.AddWithValue("@IDMedioPago", reserva.IDMedioPago);
                    comando.Parameters.AddWithValue("@Estado", reserva.Estado);
                    comando.ExecuteNonQuery();
                }                                
            }

            reservaNueva = Obtener(reserva);
            return reservaNueva;
        }

        public Reserva Obtener(Reserva reserva) {
            string sentenciasql = "Reserva_Obtener";
            Reserva reservaGuardada = null;
            using (SqlConnection cn = this.AbrirConexion())
            {
                SqlCommand comando = new SqlCommand(sentenciasql, cn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Numero", reserva.Numero);
                using (SqlDataReader dr=comando.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        reservaGuardada = new Reserva() {
                            Numero = (string)dr["Numero"],
                            IDUsuario = (int)dr["IDUsuario"],
                            IDChofer = (int)dr["IDChofer"],
                            FechaHora = (DateTime)dr["FechaHora"],
                            IDMedioPago = (int)dr["IDMedioPago"],
                            Estado = (string)dr["Estado"]
                        };
                    }
                }                
            }
            return reservaGuardada;
        }

        public Reserva Modificar(Reserva reservaAModificar)
        {
            string sentenciasql = "Reserva_Modificar";
            Reserva reservaNueva = null;
            using (SqlConnection cn = this.AbrirConexion())
            {
                using (SqlCommand comando = new SqlCommand(sentenciasql, cn))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Numero", reservaAModificar.Numero);
                    comando.Parameters.AddWithValue("@IDUsuario", reservaAModificar.IDUsuario);
                    comando.Parameters.AddWithValue("@IDChofer", reservaAModificar.IDChofer);
                    comando.Parameters.AddWithValue("@FechaHora", reservaAModificar.FechaHora);
                    comando.Parameters.AddWithValue("@IDMedioPago", reservaAModificar.IDMedioPago);
                    comando.Parameters.AddWithValue("@Estado", reservaAModificar.Estado);
                    comando.ExecuteNonQuery();
                }
            }

            reservaNueva = Obtener(reservaAModificar);
            return reservaNueva;
        }

        public void Eliminar(Reserva reserva)
        {
            string sentenciasql = "Reserva_Eliminar";            
            using (SqlConnection cn = this.AbrirConexion())
            {
                using (SqlCommand comando = new SqlCommand(sentenciasql, cn))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Numero", reserva.Numero);                    
                    comando.ExecuteNonQuery();
                }
            }           
        }

        public List<Reserva> ListarReserva()
        {
            string sentenciasql = "Reserva_Listar";
            Reserva reservaGuardada = null;
            List<Reserva> reservas = null;
            using (SqlConnection cn = this.AbrirConexion())
            {
                SqlCommand comando = new SqlCommand(sentenciasql, cn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;                
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    reservas = new List<Reserva>();
                    while (dr.Read())
                    {
                        reservaGuardada = new Reserva()
                        {
                            Numero = (string)dr["Numero"],
                            IDUsuario = (int)dr["IDUsuario"],
                            IDChofer = (int)dr["IDChofer"],
                            FechaHora = (DateTime)dr["FechaHora"],
                            IDMedioPago = (int)dr["IDMedioPago"],
                            Estado = (string)dr["Estado"]
                        };
                        reservas.Add(reservaGuardada);
                    }
                }
            }
            return reservas;
        }

    }
}