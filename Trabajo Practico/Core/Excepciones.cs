using System;

namespace Trabajo_Practico
{
	public class EventoException : Exception
	{
		private string motivo;
		
		public EventoException(string m)
		{
			this.motivo = m;
		}
		
		public string Motivo {
			get{ return motivo; }
		}
		
		public string a()
		{
			throw new EventoException("sd");
		}
	}
	
	public class EmpleadoException : Exception
	{
		private string motivo;
		
		public EmpleadoException(string m)
		{
			this.motivo = m;
		}
		
		public string Motivo {
			get  { return motivo; }
		}
	}
	
	public class ClienteException : Exception
	{
		private string motivo;
		
		public ClienteException(string m)
		{
			this.motivo = m;
		}
		
		public string Motivo {
			get  { return motivo; }
		}
	}
	
	public class ServicioException : Exception {
		private string motivo;
		
		public ServicioException(string m)
		{
			this.motivo = m;
		}
		
		public string Motivo {
			get  { return motivo; }
		}
	}
}
