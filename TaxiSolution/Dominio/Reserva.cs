using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TaxiSolution.Dominio
{
    [DataContract]
    public class Reserva
    {

        [DataMember]
        public string Numero { get; set; }

        [DataMember]
        public int IDUsuario { get; set; }

        [DataMember]
        public int IDChofer { get; set; }
        
        [DataMember]
        public DateTime FechaHora { get; set; }


        [DataMember]
        public int IDMedioPago { get; set; }

        [DataMember(IsRequired =false)]
        public string Estado { get; set; }
        
    }
}