using System;

namespace Trabajo_Practico
{
	public class Encargado : Empleado
	{
		private double plus;
		
		public Encargado()
		{
		}
		
		public Encargado(string nom, string apel, int dn, int ln, double suel, string tar, double p)
			: base(nom, apel, dn, ln, suel, tar)
		{
			this.plus = p;
		}
		
		public double Plus {
			set { plus = value; }
			get { return plus; }
		}
	}
}