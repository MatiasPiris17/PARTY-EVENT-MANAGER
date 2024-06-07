using System;
using System.Collections;

namespace Trabajo_Practico
{
	class Program
	{
		public static void Main(string[] args)
		{
			SalonDeFiesta salon = new SalonDeFiesta("El Jardin");
				
			Console.WriteLine("¡Bienvenido al salon de fiesta " + salon.NombreSalonFiesta + "!");
			
			// ESTAS LINEAS CARGAN LOS DATOS DEL SALON PARA HACER PRUEBAS
			Tests.CargarEmpleadosTest(ref salon);
			//Tests.CargarServiciosTest(ref salon);
			Tests.CargarEventosTest(ref salon); 
			
			bool reiniciar = true;
			do {
				try {
					Console.WriteLine("-------------");
					Console.WriteLine("Elija una opción: ");
					Console.WriteLine("1) Agregar un servicio");
					Console.WriteLine("2) Eliminar un servicio");
					Console.WriteLine("3) Dar de alta un empleado/encargado");
					Console.WriteLine("4) Dar de baja un empleado/encargado");
					Console.WriteLine("5) Reservar el salón para un evento");
					Console.WriteLine("6) Cancelar un evento");
					Console.WriteLine("7) Ver listado de eventos");
					Console.WriteLine("8) Ver listado de clientes");
					Console.WriteLine("9) Ver listado de empleados");
					Console.WriteLine("10) Ver listado de eventos de un mes determinado");
					Console.WriteLine("11) Para salir del programa");
					Console.Write("Opción: ");
					
					string opcion = Console.ReadLine();
					
					switch (opcion) {
						case "1": 
							Console.WriteLine("-------------");
							AgregarServicio(ref salon);
							break;
						case "2":
							Console.WriteLine("-------------");
							EliminarServicio(ref salon);
							break;
						case "3":
							Console.WriteLine("-------------");
							DarAltaEmpleado(ref salon);
							break;
						case "4":
							Console.WriteLine("-------------");
							DarBajaEmpleado(ref salon);
							break;
						case "5":
							Console.WriteLine("-------------");
							ReservarEvento(ref salon);
							break;
						case "6":
							Console.WriteLine("-------------");
							CancelarEvento(ref salon);
							break;				
						case "7":
							Console.WriteLine("-------------");
							ListadoEventos(salon);
							break;		
						case "8":
							Console.WriteLine("-------------");
							ListadoClientes(salon);
							break;	
						case "9":
							Console.WriteLine("-------------");
							ListadoEmpleados(salon);
							break;
						case "10":
							Console.WriteLine("-------------");
							ListadoEventosMes(salon);
							break;	
						case "11": 
							return;
						default: 
							Console.WriteLine("Opcion incorrecta. Intente nuevamente.");
							break;
					}
				} catch (Exception e) {
					Console.WriteLine(e.Message);
				}
			
			} while (reiniciar);
			
			Console.ReadKey(true);
		}
		
		public static void AgregarServicio(ref SalonDeFiesta salon)
		{
			try {
				Console.WriteLine("Para agregar un servicio ingrese:");
				
				Console.Write("Nombre del servicio: ");
				string nombreSer = Console.ReadLine();
				
				Console.Write("Descripcion del servicio: ");
				string descripSer = Console.ReadLine();
				
				Console.Write("Costo por unidad del servicio (ej: 18.26 ): ");
				double costoUnidadSer = double.Parse(Console.ReadLine());
				
				Servicio servicio = new Servicio(nombreSer, descripSer, costoUnidadSer);
				
				salon.AgregarServicioSalon(servicio);
				
				Console.WriteLine("Servicio agregado con exito!");
				Console.WriteLine("-------------");
				
			} catch (ServicioException err) {
				Console.WriteLine(err.Motivo);
			} catch (FormatException) {
				Console.WriteLine("El dato que ingreso es incorrecto ");
			} 
		}
		
		public static void EliminarServicio(ref SalonDeFiesta salon)
		{
			Console.WriteLine("Para eliminar un servicio ingrese:");
			
			try {
				Console.Write("Nombre del servicio: ");
				string nombreSerElim = Console.ReadLine();
				bool result = salon.ExisteServicioSalon(nombreSerElim);
				if (result) {
					bool elem = salon.EliminarServicioSalon(nombreSerElim);
					Console.WriteLine("Servicio eliminado con exito!");
					Console.WriteLine("-------------");
				} else {
					Console.WriteLine();
					throw new ServicioException("Servicio no encontrado");
				}
			} catch (ServicioException err) {
				Console.WriteLine(err.Motivo);
			} catch (FormatException) {
				Console.WriteLine("El dato que ingreso es incorrecto ");
			} 
		}
		
		public static void DarAltaEmpleado(ref SalonDeFiesta salon)
		{
			try {
				Console.WriteLine("Para dar de alta un empleado ingrese: ");
				
				Console.Write("Nombre empleado: ");
				string nombreEmp = Console.ReadLine();
				
				Console.Write("Apellido empleado: ");
				string apellidoEmp = Console.ReadLine();
							
				Console.Write("D.N.I: ");
				int dniEmp = int.Parse(Console.ReadLine());
							
				Console.Write("Numero de legajo: ");
				int nroLegEmp = int.Parse(Console.ReadLine());
								
				Console.Write("Sueldo: ");
				double sueldoEmp = double.Parse(Console.ReadLine());
							
				Console.Write("Tarea: ");
				string tareaEmp = Console.ReadLine();
				
				Empleado empleado = new Empleado(nombreEmp, apellidoEmp, dniEmp, nroLegEmp, sueldoEmp, tareaEmp);
				
				salon.AgregarEmpleadoSalon(empleado);
				
			} catch (EmpleadoException err) {
				Console.WriteLine(err.Motivo);
			} catch (FormatException) {
				Console.WriteLine("El dato que ingreso es incorrecto ");
			} 
		}
		
		public static void DarBajaEmpleado(ref SalonDeFiesta salon)
		{
			Console.WriteLine("Para dar de baja a un empleado ingrese su numero de legajo:");
			try {
				int nroLegEmp = int.Parse(Console.ReadLine());
				if (salon.Empleados.Count > 0) {
					bool result = salon.ExisteEmpleadoSalon(nroLegEmp);
					if (result) {
						bool elem = salon.EliminarEmpleadoSalon(nroLegEmp);
						Console.WriteLine("Se dio de baja con exito!");
					} else {
						throw new EmpleadoException("No se encontro al empleado con el numero de legajo: " + nroLegEmp);
					}
				} else {
					throw new EmpleadoException("No hay empleados registrados.");
				}
			} catch (EmpleadoException err) {
				Console.WriteLine(err.Motivo);
			} catch (FormatException) {
				Console.WriteLine("El dato que ingreso es incorrecto ");
			} 
		}
		
		public static void ListadoEventos(SalonDeFiesta salon)
		{
			try {
				if (salon.Eventos.Count > 0) {
					foreach (Evento elem in salon.Eventos) {
						Console.WriteLine("-------------");
						Console.WriteLine("Nombre Cliente: " + elem.VerClienteEvento().NombreCliente);
						Console.WriteLine("D.N.I Cliente: " + elem.VerClienteEvento().DniCliente);
						Console.WriteLine("Encargado: " + elem.VerEncargadoEvento().NombreEmpleado);
						Console.WriteLine("Fecha: " + elem.FechaHora.Date.ToString("yyyy-MM-dd"));
						Console.WriteLine("Hora: " + elem.FechaHora.Hour);
					}
				} else {
					throw new EventoException("No hay eventos registrados");
				}
			} catch (EventoException err) {
				Console.WriteLine(err.Motivo);
			}
		}
		
		public static void ListadoClientes(SalonDeFiesta salon)
		{
			try {
				if (salon.Eventos.Count > 0) {
					foreach (Evento elem in salon.Eventos) {
						Console.WriteLine("-------------");
						Console.WriteLine("Nombre: " + elem.VerClienteEvento().NombreCliente);
						Console.WriteLine("D.N.I: " + elem.VerClienteEvento().DniCliente);
					}
				} else {
					throw new ClienteException("No hay clientes registrados.");
				}
			} catch (ClienteException err) {
				Console.WriteLine(err.Motivo);
			}
		}
		 
		public static void ListadoEmpleados(SalonDeFiesta salon)
		{	
			try {
				if (salon.Empleados.Count > 0) {
					Console.WriteLine("Listado de empleados: ");
					foreach (Empleado elem in salon.Empleados) {
						Console.WriteLine("-------------");
						Console.WriteLine("Nombre:" + elem.NombreEmpleado);
						Console.WriteLine("D.N.I: " + elem.DniEmpleado);
						Console.WriteLine("Numero de Legajo: " + elem.NumeroLegajo);
						Console.WriteLine("Tarea: " + elem.Tarea);
						Console.WriteLine("Sueldo: " + elem.Sueldo);
					}
				} else {
					throw new EmpleadoException("No hay empleados registrados.");
				}
			} catch (EmpleadoException err) {
				Console.WriteLine(err.Motivo);
			}
		}
		
		public static void ListadoEventosMes(SalonDeFiesta salon)
		{
			try {
				Console.WriteLine("Ingrese el número del mes (1 para enero, 2 para febrero, etc.):");
				int mes = int.Parse(Console.ReadLine());
			
				if (mes > 0 && mes <= 12) {
					if (salon.Eventos.Count > 0) {
						foreach (Evento elem in salon.Eventos) {
							if (elem.FechaHora.Month == mes) {
								Console.WriteLine("-------------");
								Console.WriteLine("Nombre Cliente: " + elem.VerClienteEvento().NombreCliente);
								Console.WriteLine("D.N.I Cliente: " + elem.VerClienteEvento().DniCliente);
								Console.WriteLine("Encargado: " + elem.VerEncargadoEvento().NombreEmpleado);
								Console.WriteLine("Fecha y Hora: " + elem.FechaHora);
							}
						}
					} else {
						throw new EventoException("No hay eventos registrados.");
					}
				} else {
					throw new EventoException("Solo se permiten numeros del 1 al 12.");
				}
			} catch (EventoException err) {
				Console.WriteLine(err.Motivo);
			} catch (FormatException) {
				Console.WriteLine("El dato que ingreso es incorrecto ");
			} 
		}
		
		public static void ReservarEvento(ref SalonDeFiesta salon)
		{
			try {
				if(salon.Empleados.Count == 0) throw new EventoException("No hay empleados registrados.");
				
				if(salon.Servicios.Count == 0) throw new EventoException("No hay servicios registrados.");
					
				Evento evento = new Evento();
				Console.WriteLine("Para reservar un evento ingrese:");
			
				Console.Write("Día del evento: ");
				int fechaDia = int.Parse(Console.ReadLine());
				Console.Write("Mes del evento: ");
				int fechaMes = int.Parse(Console.ReadLine());
				Console.Write("Año del evento: ");
				int fechaAnio = int.Parse(Console.ReadLine());
				
				Console.Write("Hora del evento (ej: 15 o 20): ");	
				int hora = int.Parse(Console.ReadLine());
				
				bool validarEvento = salon.ExisteEventoSalon(fechaDia, fechaMes, fechaAnio);
				if (validarEvento) {
					throw new EventoException("Ya hay un evento registrado con esa fecha.");
				}
				
				evento.AgregarFechaHoraEvento(fechaDia, fechaMes, fechaAnio, hora);
				
				Console.Write("Nombre del cliente: ");
				string nombreClie = Console.ReadLine();
				Console.Write("D.N.I del cliente: ");
				int dniClie = int.Parse(Console.ReadLine());
				Cliente cliente = new Cliente(nombreClie, dniClie);
				
				evento.AgregarClienteEvento(cliente);
				
				Console.Write("Tipo de evento: ");
				string tipo = Console.ReadLine();
				
				evento.Tipo = tipo;
			
				Console.Write("Ingrese la cantidad de servicios que desea contratar: ");
				int count = int.Parse(Console.ReadLine());
				
				ArrayList serviciosEvento = new ArrayList();
				
				for (int i = 1; i <= count; i++) {
					Console.WriteLine("-------------");
					Console.Write("Ingrese nombre del servicio: ");
					string nombreServ = Console.ReadLine();
					
					bool result = salon.ExisteServicioSalon(nombreServ);
					
					if(result) {
						Console.Write("Cantidad de " + nombreServ + " : ");
						
						int cantidadServicios = int.Parse(Console.ReadLine());
						Servicio servicio = salon.BuscarServicioSalon(nombreServ);
						servicio.CantidadServicio = cantidadServicios;
						
						evento.AgregarServicioEvento(servicio);
						Console.WriteLine("Servicio agregado al evento!");
						
					   } else {
						Console.WriteLine("El servicio no se encuentra registrado.");
						i--;
					} 
				}
				
				double costoTotal = evento.CalcularCostoTotalEvento();
				Console.WriteLine("Costo total del evento: " + costoTotal);
				
				
				Console.Write("Confirmación (si/no) : ");
				string confirmacion = Console.ReadLine();
				
				if (confirmacion.ToLower() == "si") {
					
						evento.CostoTotal = costoTotal;
						
						Console.Write("Ingrese el monto de la seña: ");
						int montoSena = int.Parse(Console.ReadLine());
						evento.MontoSena = montoSena;
						
						evento.AgregarEncargadoEvento(salon.Empleados, 14000);
						salon.AgregarEventoSalon(evento);
						Console.WriteLine("Evento reservado exitosamente!");	
						Console.WriteLine("-------------");
				} else {
					throw new EventoException("El evento no se confirmo.");
				}
				
			} catch (EventoException err) {
				Console.WriteLine("-------------");
				Console.WriteLine(err.Motivo);
			} catch (FormatException) {
				Console.WriteLine("El dato que ingreso es incorrecto ");
			} 
		}
		
		public static void CancelarEvento(ref SalonDeFiesta salon)
		{
			try {
				Console.WriteLine("-------------");
				Console.WriteLine("Para cancelar un evento ingrese los siguiente datos del evento");
				
				Console.Write("Dia del evento: ");
				int dia = int.Parse(Console.ReadLine());
				Console.Write("Mes del evento: ");
				int mes = int.Parse(Console.ReadLine());
				Console.Write("Año del evento: ");
				int anio = int.Parse(Console.ReadLine());
		
				bool eventoExiste = salon.ExisteEventoSalon(dia, mes, anio);
			
				if (eventoExiste) {
					
					DateTime cancelarEventoFecha = new DateTime(anio, mes, dia);
					bool result = salon.EliminarEventoSalon(cancelarEventoFecha);
					
					if (result) {
						Console.WriteLine("Para finalizar ingrese los datos de la fecha actual");
				
						Console.Write("Dia: ");
						int diaActual = int.Parse(Console.ReadLine());
						Console.Write("Mes: ");
						int mesActual = int.Parse(Console.ReadLine());
						Console.Write("Año: ");
						int anioActual = int.Parse(Console.ReadLine());
						
						DateTime fechaActual = new DateTime(anioActual, mesActual, diaActual);
						
						TimeSpan diferencia = (fechaActual.Date ) - (cancelarEventoFecha.Date);
						
						if(Math.Abs(diferencia.Days) <= 31){
							
							Console.WriteLine("Tiene que pagar el total de la reserva.");
						} else {
							Console.WriteLine("No tiene que pagar la reserva. La seña no se reintegra.!");
						}
						
						Console.WriteLine("Evento cancelado con exito!");
						Console.WriteLine("-------------");
					}
					
				} else {
					throw new EventoException("Evento no registrado.");
				}
					
			} catch (EventoException err) {
				Console.WriteLine(err.Motivo);
				Console.WriteLine("-------------");
			} catch (FormatException) {
				Console.WriteLine("El dato que ingreso es incorrecto ");
			} 
		}
	}
}