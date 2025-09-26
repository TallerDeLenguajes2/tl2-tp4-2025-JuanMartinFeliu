using System;
using Microsoft.AspNetCore.Mvc;
using Clientes;
using DatosCadeteria;

[ApiController]
[Route("[controller]")]

public class CadeteriaControler: ControllerBase{

    private AccesoADatosCadeteria AccesoCadeteria;
    private AccesoADatosCadetes AccesoCadetes;
    private AccesoADatosPedidos AccesoPedidos;
    private Cadeteria cadeteria;

    public CadeteriaControler()
    {
        DatosCadeteria = new();
        DatosCadetes = new();
        DatosPedidos = new();

        cadeteria = DatosCadeteria.Obtener();

        cadeteria.ListadoCadetes = DatosCadetes.Obtener();
        cadeteria.ListadoPedidos = DatosPedidos.Obtener();
    }
    

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

    [HttpPost("AgregarPedido")]
    public IActionResult AgregarPedido(Pedidos pedido)
    {
        cadeteria.ListadoPedidos.Add(pedido);
        if(cadeteria.ListadoPedidos.Contains(pedido))
        {
            DatosPedidos.Guardar(cadeteria,ListaPedidos);
            return Ok("Pedido agregado correcatmente");
        }
        else{
            return BadRequest("No se pudo agregar el pedido");
        }
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
