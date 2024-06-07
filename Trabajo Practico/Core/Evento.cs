using System;
using System.Collections;

namespace Trabajo_Practico
{
	public class Evento
	{
		private Cliente datosCliente;
		private DateTime fechaHora;
		private Encargado encargado;
		private ArrayList servicios;
		private string tipo;
		private double costoTotal;
		private int montoSena;
		
		public Evento()
		{
			this.servicios = new ArrayList();
		}
		
		public Evento(Cliente datClie, DateTime fecHor, string tipo, Encargado encarg, ArrayList servic, double costTot, int montSen)
		{
			this.datosCliente = datClie;
			this.fechaHora = fecHor;
			this.tipo = tipo;
			this.encargado = encarg;
			this.servicios = servic;
			this.costoTotal = costTot;
			this.montoSena = montSen;
		}
		//-------------------------- Cliente --------------------------//
		
		public Cliente VerClienteEvento()
		{
			return datosCliente;
		}
		
		public void AgregarClienteEvento(Cliente cliente)
		{
			
			this.datosCliente = cliente;
		}
		
		//-------------------------- Encargado --------------------------//

		public Encargado VerEncargadoEvento()
		{
			return encargado;
		}
		
		public void AgregarEncargadoEvento(ArrayList empleados, double plus)
		{
			//Console.WriteLine(this.encargado);
			if(empleados.Count > 0){
			Empleado empleado = (Empleado)empleados[0];
			
			Encargado encargado = new Encargado(
				                      empleado.NombreEmpleado,
				                      empleado.ApellidoEmpleado,
				                      empleado.DniEmpleado,
				                      empleado.NumeroLegajo,
				                      empleado.Sueldo,
				                      empleado.Tarea,
				                      plus
			                      );
			this.encargado = encargado;	
			}
		}
		
		//-------------------------- Fecha --------------------------//

		public DateTime FechaHora{
			get { return fechaHora; }
		}
		
		public void AgregarFechaHoraEvento(int dia, int mes, int anio, int hora)
		{
			DateTime fechaHoraNew = new DateTime(anio, mes, dia, hora, 0, 0);
			this.fechaHora = fechaHoraNew;
		}
		
		//-------------------------- Servicio --------------------------//

		public ArrayList Servicios{
			get { return servicios; }
		}
		
		public bool ExisteServicioEvento(string nombre)
		{
			bool aux = false;
			foreach (Servicio elem in servicios) {
				if (elem.NombreServicio == nombre) {
					aux = true;
				}
			}
			return aux;
		}
		
		public Servicio BuscarServicioEvento(string nombre)
		{
			Servicio serv = new Servicio();
			foreach (Servicio elem in servicios) {
				if (elem.NombreServicio == nombre) {
					serv = elem;
				}
			}
			return serv;
		}
		
		public void AgregarServicioEvento(Servicio servicio)
		{
			this.servicios.Add(servicio);
		}

		
		public bool EliminarServicioEvento(string nombre)
		{
			bool aux = false;
			int index = -1;
			foreach (Servicio elem in servicios) {
				if (elem.NombreServicio == nombre) {
					index = this.servicios.IndexOf(elem);
					aux =  true;
				}
			}
			if(aux){
				this.servicios.RemoveAt(index);
			}
			return false;
		}
		
		//-------------------------- Tipo --------------------------//
		
		public string Tipo {
			set { tipo = value; }
			get { return tipo; }
		}
		
		//-------------------------- MontoSena --------------------------//

		public int MontoSena{
			set { montoSena = value; }
			get { return montoSena; }
		}
		
		//-------------------------- Costo Total --------------------------//
		
		public double CalcularCostoTotalEvento()
		{
			double resultTotal = 0;
			foreach (Servicio elem in servicios) {
				double resultElem = elem.CostoUnidad * elem.CantidadServicio;
				resultTotal = resultTotal + resultElem;
			}
			return resultTotal;
		}

		public double CostoTotal{
			set { costoTotal = value; }
			get { return costoTotal; }
		}
		
	}
}
