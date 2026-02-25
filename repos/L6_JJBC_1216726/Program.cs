using System;

namespace MyApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//PROBLEMA 1
			// 1. (True) && (0 == 0) -> El residuo de 28%7 es 0 y 5/6 (entero) es 0; True && True resulta en True.
			bool res1 = true && (5 / 6 == 28 % 7);
			Console.WriteLine(res1);

			// 2. (2 == 2) || (48 < 40) -> Como el residuo 14%3 es 2, la primera parte es True y el OR se valida de inmediato.
			bool res2 = (14 % 3 == 2) || (48 < 100 - 60);
			Console.WriteLine(res2);

			// 3. (6 - 20 + 10) == 4 -> Por jerarquía, 5*4=20; la operación da -4, por lo que -4 == 4 es False.
			bool res3 = 6 - 5 * 4 + 10 == 4;
			Console.WriteLine(res3);

			// 4. (50 - 24) == 26 -> Resolvemos paréntesis (26) y comparamos con el lado derecho (26); 26 == 26 es True.
			bool res4 = (250 / 5 - 4 * 6) == 30 - 4;
			Console.WriteLine(res4);
			Console.WriteLine("\nPresione Enter para continuar");
			Console.ReadLine();

			//PROBLEMA 2
			Console.WriteLine("Inserte la cantidad de horas:");
			string entrada = Console.ReadLine();

			// Math.Ceiling sube cualquier decimal al siguiente entero (ej: 2.1 -> 3)
			int tiempo = (int)Math.Ceiling(double.Parse(entrada));

			// Si es 1 hora o menos, paga 5$ por hora
			if (tiempo <= 2)
			{
				// Cambiado a <= 2 para que incluya el número 2 y siempre muestre resultado
				Console.WriteLine("Total a pagar = " + 5 * tiempo + "$");
			}
			// Si son 3 o 4 horas, paga 4$ por hora
			else if (tiempo < 5)
			{
				// Solo validamos < 5 porque el 'else' anterior ya filtró los menores a 2
				Console.WriteLine("Total a pagar = " + 4 * tiempo + "$");
			}
			// Si son 5 horas o más, paga 3$ por hora
			else
			{
				// Cualquier valor de 5 en adelante entra aquí automáticamente
				Console.WriteLine("Total a pagar = " + 3 * tiempo + "$");
			}

			Console.WriteLine("\nPresione Enter para continuar");
			Console.ReadLine();

			//PROBLEMA 3
			bool valorValido = false; // Variable de control para el bucle
			float puntu = 0;

			do
			{
				Console.WriteLine("\n--- MENÚ DE PUNTUACIÓN ---");
				Console.WriteLine("1. Inaceptable (0.0)");
				Console.WriteLine("2. Aceptable (0.4)");
				Console.WriteLine("3. Meritorio (0.6 o más)");
				Console.Write("Seleccione la opción de su nivel: ");

				string option = Console.ReadLine();

				// Evaluamos la opción elegida para asignar el valor de puntuación
				if (option == "1")
				{
					puntu = 0.0f; // Asignamos 0.0 para nivel inaceptable
					valorValido = true; // El valor es correcto, podemos salir del bucle
				}
				else if (option == "2")
				{
					puntu = 0.4f; // Asignamos 0.4 para nivel aceptable
					valorValido = true;
				}
				else if (option == "3")
				{
					Console.Write("Ingrese la puntuación exacta (0.6 o superior): ");
					puntu = float.Parse(Console.ReadLine());
					// Validamos que realmente sea 0.6 o más para aceptar el dato
					if (puntu >= 0.6f) valorValido = true;
					else Console.WriteLine("Error: Para nivel meritorio debe ser >= 0.6");
				}
				else
				{
					// Mensaje de error si el usuario no presiona 1, 2 o 3
					Console.WriteLine("Opción no válida. Intente de nuevo.");
				}

			} while (!valorValido); // El bucle se repite mientras valorValido sea falso

			// LOGICA DE RESULTADOS
			Console.WriteLine("\nLa puntuación final es: " + puntu);

			if (puntu == 0.0f)
			{
				Console.WriteLine("Nivel: Inaceptable"); // Puntuación mínima, no genera bono
			}
			else if (puntu == 0.4f)
			{
				Console.WriteLine("Nivel: Aceptable"); // Puntuación media, genera bono parcial
			}
			else
			{
				Console.WriteLine("Nivel: Meritorio"); // Puntuación alta, genera bono proporcional
			}

			// CÁLCULO DE PAGA
			float bono = puntu * 2400; // El bono es el porcentaje de la puntuación sobre 2400
			float total = 2400 + bono; // Sumamos el sueldo base (2400) más el bono calculado
			Console.WriteLine("Su paga total será de: " + total + " euros");
			Console.WriteLine("\nPresione Enter para continuar");
			Console.ReadLine();

			//PROBLEMA 4
			int opcion;
			bool opcionValida = false;

			// Bucle para validar la opción del menú
			do
			{
				Console.WriteLine("--- MENÚ DE CONVERSIÓN ---");
				Console.WriteLine("1. De Celsius a Fahrenheit");
				Console.WriteLine("2. De Fahrenheit a Celsius");
				Console.WriteLine("3. De Celsius a Kelvin");
				Console.Write("Seleccione una opción: ");

				if (int.TryParse(Console.ReadLine(), out opcion) && (opcion >= 1 && opcion <= 3))
				{
					opcionValida = true; // Opción correcta entre 1 y 3
				}
				else
				{
					Console.WriteLine("Error: Opción no válida. Intente de nuevo.\n");
				}
			} while (!opcionValida);

			double temp;
			// Bucle para validar que la temperatura sea un número (acepta negativos y decimales)
			Console.Write("Ingrese la temperatura a convertir: ");
			while (!double.TryParse(Console.ReadLine(), out temp))
			{
				// Si la conversión falla (ej: escriben letras), pide el dato otra vez
				Console.Write("Error: Debe ingresar un número válido. Intente de nuevo: ");
			}

			double resultado = 0;




			if (opcion == 1)
			{
				// (C * 9/5) + 32 -> Convierte Celsius a Fahrenheit usando división de precisión.
				resultado = (temp * 9 / 5) + 32;
				Console.WriteLine($"{temp}°C equivalen a {resultado}°F");
			}
			else if (opcion == 2)
			{
				// (F - 32) * 5/9 -> Convierte Fahrenheit a Celsius restando el desfase de 32.
				resultado = (temp - 32) * 5 / 9;
				Console.WriteLine($"{temp}°F equivalen a {resultado}°C");
			}
			else if (opcion == 3)
			{
				// C + 273.15 -> Convierte Celsius a Kelvin sumando la constante del cero absoluto.
				resultado = temp + 273.15;
				Console.WriteLine($"{temp}°C equivalen a {resultado} K");
			}

			Console.WriteLine("\nPresione cualquier tecla para salir...");
			Console.ReadKey();
		}
	}
}