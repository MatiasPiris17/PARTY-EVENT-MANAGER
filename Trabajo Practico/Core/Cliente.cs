using System;

namespace Trabajo_Practico
{
	public class Cliente
	{
		private string nombreCliente;
		private int dniCliente;
		
		public Cliente(){}
		
		public Cliente(string n, int d){
			this.nombreCliente = n;
			this.dniCliente = d;
		}
		
		public string NombreCliente {
			set { nombreCliente = value; }
			get { return nombreCliente; }
		}
		public int DniCliente {
			set { dniCliente = value; }
			get { return dniCliente; }
		}
	}
}
