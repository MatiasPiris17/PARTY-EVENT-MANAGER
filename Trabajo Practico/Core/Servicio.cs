using System;

namespace Trabajo_Practico
{
	public class Servicio
	{
		private string nombreServicio;
		private string descripcion;
		private int cantidadServicios;
		private double costoUnidad;
		
		public Servicio()
		{
		}
		
		public Servicio(string n, string d, double cos)
		{
			this.nombreServicio = n;
			this.descripcion = d;
			this.costoUnidad = cos;
		}
			
		public Servicio(string n, string d, int cantidad, double cos)
		{
			this.nombreServicio = n;
			this.descripcion = d;
			this.CantidadServicio = cantidad;
			this.costoUnidad = cos;
		}
		
		//---------- Nombre ----------//
		public string NombreServicio {
			set{ nombreServicio = value; }
			get{ return nombreServicio; }
		}
		
		//---------- Descripcion ----------//
		public string Descripcion {
			set{ descripcion = value; }
			get{ return descripcion; }
		}
		
		//---------- Costo unidad ----------//
		public double CostoUnidad {
			set{ costoUnidad = value; }
			get{ return costoUnidad; }
		}
		
		//---------- Cantidad----------//
		public int CantidadServicio {
			set{ cantidadServicios = value; }
			get{ return cantidadServicios; }
		}
		
	}
}
