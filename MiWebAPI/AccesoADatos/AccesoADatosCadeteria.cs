using System.Text.Json;
using Clientes;

namespace DatosCadeteria 
{
    public class AccesoADatosCadeteria
    {
        Cadeteria Obtener()
        {
            string path = File.ReadAllText("D:/Taller de Lenguajes ll/tl2-tp4-2025-JuanMartinFeliu/MiWebAPI/JSON/Cadeteria.json");
            Cadeteria NuevaCad = JsonSerializer.Deserialize<Cadeteria>(path);
            return NuevaCad;
        }
    }
}