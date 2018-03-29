using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TaxiSolution
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ITaxiService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ITaxiService
    {
        [OperationContract]
        string Loguear(string usuario, string password);
    }
}
