using System;
using Microsoft.AspNetCore.Mvc;
using Clientes;
using DatosCadeteria;

[ApiController]
[Route("[controller]")]

public class CadeteriaControler: ControllerBase{
    public CadeteriaControler()
    {
    }
    

    [HttpGet("pedidos")]
    public IActionResult GetPedidos(){
        var datosPedidos = new AccesoADatosPedidos();
        var pediditos = datosPedidos.Obtener();
        return Ok(pediditos);
    }

    [HttpGet("cadetes")]
    public IActionResult GetCadetes()
    {
        var datosCadetes = new AccesoADatosCadetes();
        var cadetitos = datosCadetes.Obtener();
        return Ok(cadetitos);
        
    }

    [HttpGet("informe")]
    public IActionResult GetInforme()
    {
        return Ok(cadeteria.GenerarInforme());    
    }

    [HttpPost("AgregarPedido")]
    public IActionResult AgregarPedido(Pedidos pedido)
    {
        var accesoPedidos = new AccesoADatosPedidos();
        var PedidoCreado = accesoPedidos.Guardar(pedido);
    }

    [HttpPut]
    public IActionResult AsignarPedido(int idPedido, int idCadete)
    {
        cadeteria.AsignarCadeteAPedido(idCadete, idPedido);
        return Ok("Pedido Asignado");    
    }

    [HttpPut("CambiarEstado")]
    public IActionResult CambiarEstadoPedido(int idPedido, string NuevoEstado)
    {
        var pedido = cadeteria.ListadoPedidos.FirstOrDefault(p => p.Numero == idPedido);
        if (pedido == null)
        {
            return NotFound("Pedido no encontrado");
        }
        pedido.cambiarEstado(NuevoEstado);
        return Ok("Estado Actualizado");
    }

    [HttpPut("CambiarCadete")]
    public IActionResult CambiarCadetePedido(int idPedido, int idNuevoCadete)
    {
        cadeteria.AsignarCadeteAPedido(idNuevoCadete, idPedido);
        return Ok("Cadete cambiado");
    }
}
