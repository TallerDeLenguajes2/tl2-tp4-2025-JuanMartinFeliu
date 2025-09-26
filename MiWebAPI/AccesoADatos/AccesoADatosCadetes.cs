using system;
using Clientes;

public class AccesoADatosCadetes
{
    List<Cadete> Obtener()
    {
        string path = File.ReadAllText("D:/Taller de Lenguajes ll/tl2-tp4-2025-JuanMartinFeliu/MiWebAPI/JSON/Cadetes.json");
        List<Cadete> ListaCadetes = JsonSerializer.Deserialize<List<Cadete>>(path);
        return ListaCadetes;
    }
}