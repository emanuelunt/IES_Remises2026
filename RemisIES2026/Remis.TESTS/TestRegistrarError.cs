
using Remis.INFRASTRUCTURE.Contexto;

namespace Remis.TESTS
{
    public class TestRegistrarError
    {
        private readonly string _rutaBase = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Errorlog");

        [Fact]
        public void RegistrarErrores_DeberiaCrearCarpetaYArchivo()
        {
            
            var excepcion = new Exception("Error de prueba");
            var fecha = DateTime.Now;
            var carpetaEsperada = fecha.ToString("yyyy-MM-dd");

            
            ArchivoLog.RegistrarErrores(excepcion);

            // Assert - Verificar
            // verificar que la carpeta se creo
            string rutaCarpeta = Path.Combine(_rutaBase, carpetaEsperada);
            bool carpetaExiste = Directory.Exists(rutaCarpeta);

            // Verificar que el archivo se creo
            var archivos = Directory.GetFiles(rutaCarpeta, "*.txt");
            bool archivoExiste = archivos.Length > 0;

            // Mostrar resultados
            Console.WriteLine($"Carpeta: {rutaCarpeta}");
            Console.WriteLine($"Archivos encontrados: {archivos.Length}");
            if (archivoExiste)
            {
                Console.WriteLine($"Archivo: {archivos[0]}");
            }

            // Assertions
            Assert.True(carpetaExiste, "La carpeta de logs no se creó");
            Assert.True(archivoExiste, "No se creó ningún archivo de log");
        }
    }
}

