using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

[HttpGet]
public IActionResult GetPedidos(){

}

[HttpGet]
public IActionResult GetCadetes(){
    
}

[HttpGet]
public IActionResult GetInforme(){
    
}

[HttpPost]
public void AgregarPedido(Pedido pedido){

}

[HttpPut]
public void AsignarPedido(int idPedido, int idCadete){
    
}

[HttpPut]
public void CambiarEstadoPedido(int idPedido,int NuevoEstado){
    
}

[HttpPut]
public void CambiarCadetePedido(int idPedido,int idNuevoCadete){
    
}
