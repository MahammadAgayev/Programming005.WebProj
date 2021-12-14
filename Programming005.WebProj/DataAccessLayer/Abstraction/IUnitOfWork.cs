namespace Programming005.WebProj.DataAccessLayer.Abstraction
{
    public interface IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }
        IRoleRepository RoleRepository { get; }
        IAccountRoleRepository AccountRoleRepository { get; }

    }
}