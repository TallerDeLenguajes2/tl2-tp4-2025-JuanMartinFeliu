using System;

namespace Clientes
{
    public class Cliente
    {
        private string nombre;
        private string direccion;
        private string telefono;
        private string datosReferenciaDireccion;

        public string Nombre { get => nombre; }
        public string Direccion { get => direccion; }
        public string Telefono { get => telefono; }
        public string DatosReferenciaDireccion { get => datosReferenciaDireccion; }

        public Cliente(string nombreCliente, string direccionCliente, string telefonoCliente, string datosReferenciaCliente)
        {
            this.nombre = nombreCliente;
            this.direccion = direccionCliente;
            this.telefono = telefonoCliente;
            this.datosReferenciaDireccion = datosReferenciaCliente;
        }
    }

    public class Pedidos
    {
        private int numero;
        private string obs;
        private Cliente cliente;
        private string estado = "Pendiente";
        private Cadete cadete;

        public int Numero { get => numero; }
        public string Obs { get => obs; }
        public Cliente Cliente { get => cliente; }
        public string Estado { get => estado; }
        public Cadete Cadete { get => cadete; set => cadete = value; }



        public string VerDireccionClientes(Cliente cliente)
        {
            string direc = cliente.Direccion;
            return direc;
        }

        public string VerDatosCliente(Cliente cliente)
        {
            string infoCliente = cliente.Nombre + ";" + cliente.Direccion + ";" +  cliente.Telefono + ";" + cliente.DatosReferenciaDireccion;
            return infoCliente; 
        }

        public Pedidos(int nro, string obs, Cliente clte)
        {
            this.numero = nro;
            this.obs = obs;
            this.cliente = clte;
            this.estado = "Pendiente";
        }

        public void cambiarEstado()
        {
            estado = "Entregado";
        }
    }

    public class Cadete
    {
        private int id;
        private string nombreCadete;
        private string direccionCadete;
        private string telefonoCadete;

        public int Id { get => id; }
        public string NombreCadete { get => nombreCadete; }
        public string DireccionCadete { get => direccionCadete; }
        public string TelefonoCadete { get => telefonoCadete; }

        public Cadete(int id, string nombre, string direccion, string telefono)
        {
            this.id = id;
            this.nombreCadete = nombre;
            this.direccionCadete = direccion;
            this.telefonoCadete = telefono;
        }

    }

    public class Cadeteria
    {
        private string nombreCadeteria;
        private string telefonoCadeteria;
        private List<Cadete> listadoCadetes;
        private List<Pedidos> listadoPedidos;
        public string NombreCadeteria { get => nombreCadeteria; }
        public string TelefonoCadeteria { get => telefonoCadeteria; }
        public List<Cadete> ListadoCadetes { get => listadoCadetes; }
        public List<Pedidos> ListadoPedidos {get => listadoPedidos;}



        public Cadeteria(string nombreCad, string tel)
        {
            nombreCadeteria = nombreCad;
            telefonoCadeteria = tel;
            listadoCadetes = new List<Cadete>();
            listadoPedidos = new List<Pedidos>();
        }

        public void agregarCadete(Cadete cadete)
        {
            listadoCadetes.Add(cadete);
        }

        public void AgregarPedido(Pedidos pedido)
        {
            listadoPedidos.Add(pedido);
        }

        public float JornalACobrar(int idCadete)
        {
            float montoPorPedido = 500;
            int cantidad = 0;

            foreach (var pedido in listadoPedidos)
            {
                if (pedido.Cadete != null && pedido.Cadete.Id == idCadete && pedido.Estado == "Entregado")
                {
                    cantidad++;
                }
            }

            return cantidad * montoPorPedido;
        }

        public void AsignarCadeteAPedido(int idCadete, int idPedido)
        {
            var cadete = listadoCadetes.Find(c => c.Id == idCadete);
            var pedido = listadoPedidos.Find(p => p.Numero == idPedido);

            if (cadete != null && pedido != null)
            {
                pedido.Cadete = cadete;
            } 
        }
    }

    public class Informe{
        
    }
}

