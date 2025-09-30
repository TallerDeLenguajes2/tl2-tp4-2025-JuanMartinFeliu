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
        var cadeteria = new Cadeteria("Pedido Ya", "381596486");

        // Si querés, podés cargar los pedidos desde JSON
        var ADPedidos = new AccesoADatosPedidos();
        var pedidos = ADPedidos.Obtener();
        foreach (var pedido in pedidos)
        {
            cadeteria.AgregarPedido(pedido);
        }

        return Ok(cadeteria.GenerarInforme());
    }


    [HttpPost("AgregarPedido")]
    public IActionResult AgregarPedido(Pedidos pedido)
    {
        var cadeteria = new Cadeteria("Pedido Ya", "381596486");
        cadeteria.AgregarPedido(pedido);

        var ADPedidos = new AccesoADatosPedidos();
        ADPedidos.Guardar(cadeteria.ListadoPedidos);

        return Ok("Pedido Agregado");
    }

    [HttpPut]
    public IActionResult AsignarPedido(int idPedido, int idCadete)
    {
        var cadeteria = new Cadeteria("Pedido Ya", "381596486");
        cadeteria.AsignarCadeteAPedido(idCadete, idPedido);

        var ADPedidos = new AccesoADatosPedidos();
        ADPedidos.Guardar(cadeteria.ListadoPedidos);

        return Ok("Pedido Asignado");
    }

    [HttpPut("CambiarEstado")]
    public IActionResult CambiarEstadoPedido(int idPedido, string NuevoEstado)
    {
        var cadeteria = new Cadeteria("Pedido Ya", "381596486");
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
        var cadeteria = new Cadeteria("Pedido Ya", "381596486");
        cadeteria.AsignarCadeteAPedido(idNuevoCadete, idPedido);
        return Ok("Cadete cambiado");
    }
}
