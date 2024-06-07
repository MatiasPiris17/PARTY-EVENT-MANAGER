using System;

namespace Trabajo_Practico
{
	public class Empleado
	{
		protected string nombreEmpleado;
		protected string apellidoEmpleado;
		protected int dniEmpleado;
		protected int numeroLegajo;
		protected double sueldo;
		protected string tarea;
		
		public Empleado()
		{
		}
		
		public Empleado(string n, string a, int dn, int nl, double s, string t)
		{
			this.nombreEmpleado = n;
			this.apellidoEmpleado = a;
			this.dniEmpleado = dn;
			this.numeroLegajo = nl;
			this.sueldo = s;
			this.tarea = t;
		}
		
		public string NombreEmpleado {
			set { nombreEmpleado = value; }
			get{ return nombreEmpleado; }
		}
		public string ApellidoEmpleado {
			set { apellidoEmpleado = value; }
			get{ return apellidoEmpleado; }
		}
		public int DniEmpleado {
			set { dniEmpleado = value; }
			get{ return dniEmpleado; }
		}
		public int NumeroLegajo {
			set { numeroLegajo = value; }
			get{ return numeroLegajo; }
		}
		public double Sueldo {
			set { sueldo = value; }
			get{ return sueldo; }
		}
		public string Tarea {
			set { tarea = value; }
			get{ return tarea; }
		}
	}
}
