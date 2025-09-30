using System.Text.Json;
using Clientes;

namespace DatosCadeteria 
{
    public class AccesoADatosCadeteria
    {
        Cadeteria Obtener()
        {
            string path = File.ReadAllText("JSON/Cadeteria.json");
            Cadeteria NuevaCad = JsonSerializer.Deserialize<Cadeteria>(path);
            return NuevaCad;
        }
    }
}