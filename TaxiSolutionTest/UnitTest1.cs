using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
using System.Collections.Generic;

namespace TaxiSolutionTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1CrearReservaOK()
        {
            ReservasWS.ReservasServiceClient proxy = new ReservasWS.ReservasServiceClient();
            DateTime fecha = DateTime.Now;
            ReservasWS.Reserva reservaCreada = proxy.CrearReserva(new ReservasWS.Reserva() {
                Numero = "001-10", IDUsuario = 10, IDChofer = 10, FechaHora = fecha, IDMedioPago = 10, Estado = "PENDIENTE" }
            );
            Assert.AreEqual("001-10", reservaCreada.Numero);
            Assert.AreEqual(10, reservaCreada.IDUsuario);
            Assert.AreEqual(10, reservaCreada.IDChofer);
            //Assert.AreEqual(fecha, reservaCreada.FechaHora);
            Assert.AreEqual(10, reservaCreada.IDMedioPago);
            Assert.AreEqual("PENDIENTE", reservaCreada.Estado);
        }

        [TestMethod]
        public void Test1CrearReservaError()
        {
            ReservasWS.ReservasServiceClient proxy = new ReservasWS.ReservasServiceClient();
            DateTime fecha = DateTime.Now;
            try
            {
                ReservasWS.Reserva reservaCreada = proxy.CrearReserva(new ReservasWS.Reserva()
                {
                    Numero = "001-10", IDUsuario = 10, IDChofer = 10, FechaHora = fecha, IDMedioPago = 10, Estado = "PENDIENTE"
                }
            );              
            }
            catch (FaultException<ReservasWS.AdministradorExcepciones> error)
            {
                Assert.AreEqual("Error al intentar crear una reserva.", error.Reason.ToString());
                Assert.AreEqual(error.Detail.Codigo, "0101");
                Assert.AreEqual(error.Detail.Descripcion, "La reserva ya existe.");
            }
            
        }

        [TestMethod]
        public void Test1EliminarReservaOK()
        {
            ReservasWS.ReservasServiceClient proxy = new ReservasWS.ReservasServiceClient();
            string numeroReserva = "001-10";
            ReservasWS.Reserva reserva=new ReservasWS.Reserva()
            {
                Numero = numeroReserva
            };
            proxy.EliminarReserva(reserva);
            ReservasWS.Reserva reservaguardada= proxy.ObtenerReserva(reserva);
            Assert.AreEqual(null, reservaguardada);
            
        }

        [TestMethod]
        public void Test1ListarReservaOK()
        {
            ReservasWS.ReservasServiceClient proxy = new ReservasWS.ReservasServiceClient();
            DateTime fecha = DateTime.Now;
            List<ReservasWS.Reserva> reservas = proxy.ListarReserva();            
            Assert.AreNotEqual(0, reservas.Count);            
        }

        [TestMethod]
        public void Test1ModificarReservaOK()
        {
            ReservasWS.ReservasServiceClient proxy = new ReservasWS.ReservasServiceClient();
            DateTime fecha = DateTime.Now;
            ReservasWS.Reserva reservaCreada = proxy.ModificarReserva(new ReservasWS.Reserva()
            {
                Numero = "001-10",
                IDUsuario = 20,
                IDChofer = 20,
                FechaHora = fecha,
                IDMedioPago = 20,
                Estado = "PENDIENTE"
            }
            );
            Assert.AreEqual("001-10", reservaCreada.Numero);
            Assert.AreEqual(20, reservaCreada.IDUsuario);
            Assert.AreEqual(20, reservaCreada.IDChofer);
            //Assert.AreEqual(fecha, reservaCreada.FechaHora);
            Assert.AreEqual(20, reservaCreada.IDMedioPago);
            Assert.AreEqual("PENDIENTE", reservaCreada.Estado);
        }

        [TestMethod]
        public void Test1ModificarReservaError()
        {
            ReservasWS.ReservasServiceClient proxy = new ReservasWS.ReservasServiceClient();
            DateTime fecha = DateTime.Now;
            try
            {
                ReservasWS.Reserva reservaCreada = proxy.ModificarReserva(new ReservasWS.Reserva()
                {
                    Numero = "001-100",
                    IDUsuario = 10,
                    IDChofer = 10,
                    FechaHora = fecha,
                    IDMedioPago = 10,
                    Estado = "PENDIENTE"
                }
            );
            }
            catch (FaultException<ReservasWS.AdministradorExcepciones> error)
            {
                Assert.AreEqual("La reserva no existe. No se puede modificar", error.Reason.ToString());
                Assert.AreEqual("0102", error.Detail.Codigo);
                Assert.AreEqual("La reserva no existe.",error.Detail.Descripcion);
            }

        }

        [TestMethod]
        public void Test1ObtenerReservaOK()
        {
            ReservasWS.ReservasServiceClient proxy = new ReservasWS.ReservasServiceClient();
            DateTime fecha = DateTime.Now;
            ReservasWS.Reserva reservaCreada = proxy.ObtenerReserva(new ReservasWS.Reserva()
            {
                Numero = "001-10"
            }
            );
            Assert.AreEqual("001-10", reservaCreada.Numero);            
        }
    }
}
