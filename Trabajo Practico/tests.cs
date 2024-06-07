using System;

namespace Trabajo_Practico
{
	class Tests
	{
		public static void CargarEmpleadosTest(ref SalonDeFiesta salon){
			
			/*---------- Agregar Empleados de Pruebas ----------*/
			Empleado empleado1 = new Empleado("Juan", "Pérez", 12345678, 1001, 50000.50, "Mozo");
			Empleado empleado2 = new Empleado("María", "Gómez", 23456789, 1002, 55000.75, "Dj");
			Empleado empleado3 = new Empleado("Pedro", "Rodríguez", 34567890, 1003, 60000.00, "Limpieza");
			Empleado empleado4 = new Empleado("Ana", "Martínez", 45678901, 1004, 45000.25, "Cocinero");
			Empleado empleado5 = new Empleado("Luis", "López", 56789012, 1005, 70000.00, "Barman");
			salon.AgregarEmpleadoSalon(empleado1);
			salon.AgregarEmpleadoSalon(empleado2);
			salon.AgregarEmpleadoSalon(empleado3);
			salon.AgregarEmpleadoSalon(empleado4);
			salon.AgregarEmpleadoSalon(empleado5);
		}
		
		public static void CargarServiciosTest(ref SalonDeFiesta salon){
			
			/*---------- Agregar Servicios de Pruebas ----------*/
			Servicio servicio1 = new Servicio("Limpieza", "Servicio de limpieza", 1500.00);
			Servicio servicio2 = new Servicio("Mozos", "Mozos que llevan la comida y levantan la mesa", 2500.50);
			Servicio servicio3 = new Servicio("Dj", "DJ de musica variada", 5000.75);
			Servicio servicio4 = new Servicio("Cocina", "Preparacion de comidas", 8000.00);
			Servicio servicio5 = new Servicio("Bebidas", "Servicio de consumición libre", 3000.25);
			salon.AgregarServicioSalon(servicio1);
			salon.AgregarServicioSalon(servicio2);
			salon.AgregarServicioSalon(servicio3);
			salon.AgregarServicioSalon(servicio4);
			salon.AgregarServicioSalon(servicio5);
			
		}
		
		public static void CargarEventosTest(ref SalonDeFiesta salon){
			
			/*---------- Evento 1 ----------*/
			Evento evento1 = new Evento() ;
			
			Cliente cliente1 = new Cliente("Camila", 43859700);
			evento1.AgregarClienteEvento(cliente1);
			
			//DateTime fechaHora1 = new DateTime(2024,11,18);
			evento1.AgregarFechaHoraEvento(18,11,2024, 23);
			
			evento1.AgregarEncargadoEvento(salon.Empleados, 15000.500);
			
			/*------ Servicios evento ------*/
			Servicio servicio1Evento1 = new Servicio("Mozos", "Mozos que llevan la comida a la mesa", 5400);
			Servicio servicio2Evento1 = new Servicio("Bebidas", "Consumición libre", 2500.50);
			Servicio servicio3Evento1 = new Servicio("DJ", "DJ de musica variada", 3500);
			evento1.AgregarServicioEvento(servicio1Evento1);
			evento1.AgregarServicioEvento(servicio2Evento1);
			evento1.AgregarServicioEvento(servicio3Evento1);
			/*------ Servicios evento ------*/
			
			string tipo1 = "Cumpleaños de quince" ;
			evento1.Tipo = tipo1;
			
			double costoTotal1 = evento1.CalcularCostoTotalEvento();
			evento1.CostoTotal = costoTotal1;
			
			int montoSena1 = 20000;
			evento1.MontoSena = montoSena1;	
			
			salon.AgregarEventoSalon(evento1);
			
			/*---------- Evento 2 ----------*/
			Evento evento2 = new Evento();
			
			Cliente cliente2 = new Cliente("Mariela", 26020818);
			evento2.AgregarClienteEvento(cliente2);
			
			//DateTime fechaHora2 = new DateTime(2024,6,1);
			evento2.AgregarFechaHoraEvento(1,6,2024,15);
			
			evento2.AgregarEncargadoEvento(salon.Empleados, 15000.500);
			
			/*------ Servicios evento ------*/
			Servicio servicio1Evento2 = new Servicio("Mozos", "Mozos que llevan la comida a la mesa", 5400);
			Servicio servicio2Evento2 = new Servicio("Bebidas", "Consumición libre", 2500.50);
			Servicio servicio3Evento2 = new Servicio("DJ", "DJ de musica variada", 3500);
			evento2.AgregarServicioEvento(servicio1Evento2);
			evento2.AgregarServicioEvento(servicio2Evento2);
			evento2.AgregarServicioEvento(servicio3Evento2);
			/*------ Servicios evento ------*/
			
			string tipo2 = "Casamiento" ;
			evento2.Tipo = tipo2;
			
			double costoTotal2 = evento2.CalcularCostoTotalEvento();
			evento2.CostoTotal = costoTotal2;
			
			int montoSena2 = 20000;
			evento2.MontoSena = montoSena2;	
			
			salon.AgregarEventoSalon(evento2);
		}
	}
}
