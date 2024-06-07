using System;
using System.Collections;


namespace Trabajo_Practico
{
	public class SalonDeFiesta
	{
		private string nombreSalonFiesta;
		private ArrayList empleados;
		private ArrayList eventos;
		private ArrayList servicios;

		public SalonDeFiesta()
		{
		}
		
		public SalonDeFiesta(string nombre)
		{	
			this.nombreSalonFiesta = nombre;
			this.empleados = new ArrayList();
			this.eventos = new ArrayList();
			this.servicios = new ArrayList();
		}
		
		public SalonDeFiesta(string n, ArrayList empleados, ArrayList eventos, ArrayList servicios)
		{
			this.nombreSalonFiesta = n;
			this.empleados = empleados;
			this.eventos = eventos;
			this.servicios = servicios;
		}
		
		public string NombreSalonFiesta {
			get{ return nombreSalonFiesta; }
		}

		//-------------------------- Servicio --------------------------//

		public ArrayList Servicios{
			get { return servicios; }
		}
		
		public Servicio BuscarServicioSalon(string nombre)
		{
			Servicio serv = new Servicio();
			foreach (Servicio elem in servicios) {
				if (elem.NombreServicio == nombre) {
					serv = elem;
				}
			}
			return serv;
		}
		
		public bool ExisteServicioSalon(string nombre)
		{
			bool aux = false;
			foreach (Servicio elem in servicios) {
				if (elem.NombreServicio == nombre) {
					aux = true;
				}
			}
			return aux;
		}
		
		public void AgregarServicioSalon(Servicio servicio)
		{
			this.servicios.Add(servicio);
		}
	
		public bool EliminarServicioSalon(string nombre)
		{
			bool aux = false;
			int index = -1;
			foreach (Servicio elem in servicios) {
				if (elem.NombreServicio == nombre) {
					index = this.servicios.IndexOf(elem);
					aux = true;
				}
			}
			if (aux){
				this.servicios.RemoveAt(index);
			}
			return false;
		}
		
		//-------------------------- Evento --------------------------//
		
		public ArrayList Eventos {
			get { return eventos; }
		}
		
		public Evento BuscarEventoSalon(int dia, int mes, int anio)
		{
			Evento aux = new Evento();
			foreach (Evento evento in eventos){
				DateTime fechaHoraEvento = evento.FechaHora;
				if (fechaHoraEvento.Day == dia && fechaHoraEvento.Month == mes && fechaHoraEvento.Year == anio) {
					aux = evento;
				}
			}
			return aux;
		}
		
		public bool ExisteEventoSalon(int dia, int mes, int anio)
		{
			bool aux = false;
			DateTime fecha = new DateTime(anio, mes, dia);
			foreach (Evento evento in eventos) {
				DateTime eventoFecha = evento.FechaHora;
				if (eventoFecha.Day == fecha.Day && eventoFecha.Month == fecha.Month && eventoFecha.Year == fecha.Year) {
					aux = true;
				}
			}
			return aux;
		}
		
		public void AgregarEventoSalon(Evento evento)
		{
			this.eventos.Add(evento); 
		}
		
		public bool EliminarEventoSalon(DateTime fecha)
		{	
			bool aux = false;
			int index = -1;
			
			for (int i = 0; i < eventos.Count; i++) {
				Evento eventoFecha = (Evento) eventos[i];
				if( eventoFecha.FechaHora.Date == fecha.Date ){
					index = i;
					aux = true;
					break;
				}
			}
			
			if(aux){
				this.eventos.RemoveAt(index);
			}
			
			return aux;
		}
		
		//-------------------------- Empleado --------------------------//
		
		public ArrayList Empleados {
			get { return empleados; }
		}
		
		public Empleado BuscarEmpleadoSalon(int numeroLegajo)
		{
			foreach (Empleado elem in empleados) {
				if (elem.NumeroLegajo == numeroLegajo) {
					return elem;
				}
			}
			return new Empleado();
		}
		
		public bool ExisteEmpleadoSalon(int numeroLegajo)
		{
			bool aux = false;
			foreach (Empleado elem in empleados) {
				if (elem.NumeroLegajo == numeroLegajo) {
					aux = true;
				}
			}
			return aux;
		}
		
		public void AgregarEmpleadoSalon(Empleado empleado)
		{
			
			this.empleados.Add(empleado);
		}
		
		public bool EliminarEmpleadoSalon(int numeroLegajo)
		{	
			bool aux = false;
			int index = 0;
			foreach (Empleado elem in empleados) {
				if (elem.NumeroLegajo == numeroLegajo) {
					index = empleados.IndexOf(elem);
					aux = true;
				}
			}
			if(aux){
				this.empleados.RemoveAt(index);
			}
			return aux;
		}
		
	}
}
