using Microsoft.AspNetCore.Identity;
using Programming005.WebProj.DataAccessLayer.Abstraction;
using Programming005.WebProj.DataAccessLayer.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Programming005.WebProj.Identity
{
    public class UserStore : IUserStore<Account>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IdentityResult> CreateAsync(Account user, CancellationToken cancellationToken)
        {
            _unitOfWork.AccountRepository.Add(user);

            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(Account user, CancellationToken cancellationToken)
        {
            _unitOfWork.AccountRepository.Delete(user.Id);

            return Task.FromResult(IdentityResult.Success);
        }

        public void Dispose()
        {
        }

        public Task<Account> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            var account = _unitOfWork.AccountRepository.Get(int.Parse(userId));

            return Task.FromResult(account);
        }

        public Task<Account> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var account = _unitOfWork.AccountRepository.GetByUsername(normalizedUserName);

            return Task.FromResult(account);
        }

        public Task<string> GetNormalizedUserNameAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Username.ToUpperInvariant());
        }

        public Task<string> GetUserIdAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(Account user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Username);
        }

        public Task SetNormalizedUserNameAsync(Account user, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(Account user, string userName, CancellationToken cancellationToken)
        {
            user.Username = userName;

            return Task.CompletedTask;
        }

        public Task<IdentityResult> UpdateAsync(Account user, CancellationToken cancellationToken)
        {
            _unitOfWork.AccountRepository.Update(user);

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
