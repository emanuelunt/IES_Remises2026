using System.Data;
using Remis.INFRASTRUCTURE.Contexto;

namespace Remis.TESTS
{
    public class TestConexion
    {
        [Fact]
        public async Task Test1Conexion()
        {
            
            string connectionString = "Server=localhost;Database=bd_remis2026;User Id=root;Password=;Port=3306;";
            MyConexion conexion = new MyConexion(connectionString);
                        
            using var conn = await conexion.obtenerConexionAsync();

            Assert.NotNull(conn);  
            Assert.Equal(ConnectionState.Open, conn.State);
        }
    }
}


