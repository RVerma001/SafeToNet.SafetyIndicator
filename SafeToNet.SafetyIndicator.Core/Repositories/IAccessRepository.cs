using OpenTracing;
using SafeToNet.SafetyIndicator.Core.Models.Entities;
using System;
using System.Threading.Tasks;

namespace SafeToNet.SafetyIndicator.Core.Repositories
{
    public interface IAccessRepository
    {
        AuthCredentials Insert(AuthCredentials accessCode, IScope scope);
        Task<AuthCredentials> Update(AuthCredentials accessCode, IScope scope);
        Task<AuthCredentials> GetByAccessCode(string code, IScope scope);
        Task<AuthCredentials> GetByDeviceId(Guid deviceId, IScope scope);
        Task<AuthCredentials> GetById(Guid id, IScope scope);
        Task DeleteByDeviceId(Guid deviceId, IScope scope);
    }
}