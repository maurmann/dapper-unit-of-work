namespace DapperUnitOfWork.Models
{
    public class PedidoItem
    {
        public int IdPedido { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
    }
}
