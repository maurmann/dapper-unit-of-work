using Dapper;
using DapperUnitOfWork.Models;
using System.Collections.Generic;

namespace DapperUnitOfWork.Repositories
{
    public class PedidoItemRepository
    {
        public DbSession dbSession { get; set; }

        public PedidoItemRepository(DbSession dbSession)
        {
            this.dbSession = dbSession;
        }

        public void Save(List<PedidoItem> itensPedido, int idPedido)
        {
            foreach (PedidoItem pedidoItem in itensPedido)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IdPedido", idPedido);
                parameters.Add("@Produto", pedidoItem.Produto);
                parameters.Add("@Quantidade", pedidoItem.Quantidade);
                parameters.Add("@Preco", pedidoItem.Preco);
                dbSession.Connection.Execute("INSERT PedidoItem(IdPedido,Produto,Quantidade,Preco) VALUES(@IdPedido,@Produto,@Quantidade,@Preco);SELECT SCOPE_IDENTITY();", parameters, dbSession.Transaction);
            }
        }

    }
}
