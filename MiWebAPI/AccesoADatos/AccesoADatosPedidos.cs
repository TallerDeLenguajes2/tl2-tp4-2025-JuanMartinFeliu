using System.Text.Json;
using Clientes;

public class AccesoADatosPedidos
{
    public List<Pedidos> Obtener()
    {
        string path = File.ReadAllText("JSON/Pedidos.json");
        List<Pedidos> ListaPedidos = JsonSerializer.Deserialize<List<Pedidos>>(path);
        return ListaPedidos;
    }

    public void Guardar(List<Pedidos> ListaPedidos)
    {
        string path = File.ReadAllText("JSON/Pedidos.json");
        string jsonString = JsonSerializer.Serialize(ListaPedidos);
        File.WriteAllText(path,jsonString);
    }
}