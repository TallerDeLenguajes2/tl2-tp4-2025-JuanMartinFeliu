using system;
using Clientes;

public class AccesoADatosPedidos
{
    List<Pedidos> Obtener()
    {
        string path = File.ReadAllText("D:/Taller de Lenguajes ll/tl2-tp4-2025-JuanMartinFeliu/MiWebAPI/JSON/Pedidos.json");
        List<Pedidos> ListaPedidos = JsonSerializer.Deserialize<List<Pedidos>>(path);
        return ListaPedidos;
    }

    void Guardar(List<Pedidos> ListaPedidos)
    {
        string path = File.ReadAllText("D:/Taller de Lenguajes ll/tl2-tp4-2025-JuanMartinFeliu/MiWebAPI/JSON/Pedidos.json");
        string jsonString = JsonSerializer.Deserialize(ListaPedidos);
        File.WriteAllText(path,jsonString);
    }
}