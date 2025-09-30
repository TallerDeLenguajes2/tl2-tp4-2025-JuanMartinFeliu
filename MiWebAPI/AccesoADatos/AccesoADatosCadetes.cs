using System.Text.Json;
using Clientes;

public class AccesoADatosCadetes
{
    public List<Cadete> Obtener()
    {
        string path = File.ReadAllText("JSON/Cadetes.json");
        List<Cadete> ListaCadetes = JsonSerializer.Deserialize<List<Cadete>>(path);
        return ListaCadetes;
    }
}