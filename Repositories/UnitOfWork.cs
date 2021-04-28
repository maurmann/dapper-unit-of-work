namespace DapperUnitOfWork.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly DbSession session;

        public UnitOfWork(DbSession session)
        {
            this.session = session;
        }

        public void BeginTransaction()
        {
            session.Transaction = session.Connection.BeginTransaction();
        }

        public void Commit()
        {
            session.Transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            session.Transaction.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            session.Transaction?.Dispose();
        }
    }
}
