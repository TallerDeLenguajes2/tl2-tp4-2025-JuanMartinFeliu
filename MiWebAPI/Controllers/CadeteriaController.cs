using System;
using Microsoft.AspNetCore.Mvc;
using Clientes;

[ApiController]
[Route("[controller]")]

public class CadeteriaControler: ControllerBase{

    private static Cadeteria cadeteria = new Cadeteria("Mi Cadetería", "1234-5678");

    [HttpGet("pedidos")]
    public IActionResult<List<Pedidos>> GetPedidos(){
        return Ok(cadeteria.ListadoPedidos);
    }

    [HttpGet("cadetes")]
    public IActionResult<List<Cadete>> GetCadetes()
    {
        return Ok(cadeteria.ListadoCadetes);
        
    }

    [HttpGet("informe")]
    public IActionResult<Informe> GetInforme()
    {
        return Ok(cadeteria.GenerarInforme());    
    }

    [HttpPost("pedido")]
    public IActionResult AgregarPedido(Pedidos pedido)
    {
        cadeteria.AgregarPedido(pedido);
        return CreatedAtAction(nameof(GetPedidos), new { id = pedido.Numero }, pedido);
    }

    [HttpPut]
    public IActionResult AsignarPedido(int idPedido, int idCadete)
    {
        cadeteria.AsignarCadeteAPedido(idCadete, idPedido);
        return Ok("Pedido Asignado");    
    }

    [HttpPut("cambiarestado")]
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

    [HttpPut("cambiarcadete")]
    public IActionResult CambiarCadetePedido(int idPedido, int idNuevoCadete)
    {
        cadeteria.AsignarCadeteAPedido(idNuevoCadete, idPedido);
        return Ok("Cadete cambiado");
    }
}
