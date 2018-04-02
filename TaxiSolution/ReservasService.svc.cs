using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TaxiSolution.Dominio;
using TaxiSolution.Errores;
using TaxiSolution.Persistencia;

namespace TaxiSolution
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ReservasService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ReservasService.svc o ReservasService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ReservasService : IReservasService
    {
        private ReservaDAO reservaDAO = new ReservaDAO();
        public Reserva CrearReserva(Reserva reservaACrear)
        {
            if (reservaDAO.Obtener(reservaACrear)!=null)
            {
                throw new FaultException<AdministradorExcepciones>(new
                    AdministradorExcepciones()
                { Codigo = "0101", Descripcion = "La reserva ya existe." }, new FaultReason("Error al intentar crear una reserva.")
                    );
            }
            return reservaDAO.Crear(reservaACrear);
        }
        
        public void EliminarReserva(Reserva reservaAEliminar)
        {
            reservaDAO.Eliminar(reservaAEliminar);
        }

        public List<Reserva> ListarReserva()
        {
            return reservaDAO.ListarReserva();
        }

        public Reserva ModificarReserva(Reserva reservaAModificar)
        {
            if (reservaDAO.Obtener(reservaAModificar) == null)
            {
                throw new FaultException<AdministradorExcepciones>(new
                    AdministradorExcepciones()
                { Codigo = "0102", Descripcion = "La reserva no existe." }, new FaultReason("La reserva no existe. No se puede modificar")
                    );
            }
            return reservaDAO.Modificar(reservaAModificar);
        }

        public Reserva ObtenerReserva(Reserva reservaAObtener)
        {
            return reservaDAO.Obtener(reservaAObtener);
        }
    }
}
