using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TaxiSolution.Dominio;
using TaxiSolution.Errores;

namespace TaxiSolution
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IReservasService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IReservasService
    {
        [FaultContract(typeof (AdministradorExcepciones))]
        [OperationContract]
        Reserva CrearReserva(Reserva reservaACrear);

        [OperationContract]
        Reserva ObtenerReserva(Reserva reservaAObtener);

        [FaultContract(typeof(AdministradorExcepciones))]
        [OperationContract]
        Reserva ModificarReserva(Reserva reservaAModificar);

        [OperationContract]
        void EliminarReserva(Reserva reservaAEliminar);

        [OperationContract]
        List<Reserva> ListarReserva();
    }
}
