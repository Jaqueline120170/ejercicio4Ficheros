using System.Text;

namespace ejercicio4Ficheros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fecha = DateTime.Today.ToString("ddMMyyyy");
            string rutaArchivo = "C:\\Users\\Profesor\\source\\repos\\ejercicio4Ficheros\\" + fecha + ".txt";



            using (StreamWriter sw = new StreamWriter(rutaArchivo))
            {
                Console.WriteLine("Añada contenido al archivo");
                string contenido = Console.ReadLine();
                sw.Write(contenido);


                Console.WriteLine("Introduce el numero de la linea en la que deseas añadir el texto");
                int numeroLinea = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Introduce la posicion en la cual deseas añadir el nuevo texto");
                int posicion = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Introduce el texto que deseas añadir");
                string textoNuevo = Console.ReadLine();

                try
                {
                    // Leer todas las líneas del archivo
                    string[] lineas = File.ReadAllLines(

        rutaArchivo);

                    // Verificar si el número de línea deseado está dentro del rango del archivo
                    if (numeroLinea >= 1 && numeroLinea <= lineas.Length)
                    {
                        // Obtener la línea específica
                        string linea = lineas[numeroLinea - 1];

                        // Verificar si la posición deseada está dentro del rango de la línea
                        if (posicion >= 0 && posicion <= linea.Length)
                        {
                            // Insertar el nuevo texto en la posición deseada
                            string nuevaLinea = linea.Insert(posicion, textoNuevo);

                            // Reemplazar la línea original con la línea modificada
                            lineas[numeroLinea - 1] = nuevaLinea;

                            // Sobrescribir el archivo con las líneas actualizadas
                            File.WriteAllLines(

        rutaArchivo, lineas);

                            Console.WriteLine("El texto se ha escrito correctamente en la posición especificada de la línea.");
                        }
                        else
                        {
                            Console.WriteLine("La posición especificada está fuera del rango de la línea.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("El número de línea especificado está fuera del rango del archivo.");
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error al leer/escribir el archivo: " + e.Message);
                }
            }
            

            

           

        }
    }
}