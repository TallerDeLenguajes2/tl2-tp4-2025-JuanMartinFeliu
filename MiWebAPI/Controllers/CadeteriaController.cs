using System;
using Microsoft.AspNetCore.Mvc;
using Clientes;

[ApiController]
[Route("[controller]")]

public class CadeteriaControler: ControllerBase{
    [HttpGet]
    public List<Pedidos> GetPedidos(){

    }

    [HttpGet]
    public List<Cadete> GetCadetes(){
        
    }

    [HttpGet]
    public Informe GetInforme(){
        
    }

    [HttpPost]
    public void AgregarPedido(Pedidos pedido){
        listadoPedidos.Add(pedido);
    }

    [HttpPut]
    public void AsignarPedido(int idPedido, int idCadete){
        var cadete = listadoCadetes.Find(c => c.Id == idCadete);
        var pedido = listadoPedidos.Find(p => p.Numero == idPedido);

        if (cadete != null && pedido != null)
        {
            pedido.Cadete = cadete;
        } 
    }

    [HttpPut]
    public void CambiarEstadoPedido(int idPedido,int NuevoEstado){
        
    }

    [HttpPut]
    public void CambiarCadetePedido(int idPedido,int idNuevoCadete){
        
    }
}
