using Dapper;
using DapperUnitOfWork.Models;

namespace DapperUnitOfWork.Repositories
{
    public class PedidoRepository
    {
        private DbSession dbSession;

        public PedidoRepository(DbSession session)
        {
            this.dbSession = session;
        }

        public int Save(Pedido pedido)
        {

            var parameter = new DynamicParameters();
            parameter.Add("@Data", pedido.Data);

            int idPedido = dbSession.Connection.ExecuteScalar<int>("INSERT Pedido(Data) VALUES(@Data);SELECT SCOPE_IDENTITY();", parameter, dbSession.Transaction);
            return idPedido;
        }
    }
}
