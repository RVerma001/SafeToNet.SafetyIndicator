using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafeToNet.SafetyIndicator.Core.Repositories
{
    public interface ISafetyIndicatorRepository
    {
        Task Insert([NotNull]IEnumerable<Models.Entities.SafetyIndicator> enumerable);

        Task<IEnumerable<Models.Entities.SafetyIndicator>> GetLastOneDayAndDeviceIdBy(Guid deviceId);
        Task<IEnumerable<Models.Entities.SafetyIndicator>> GetLastHoursInsightsByDeviceId(Guid deviceId, double hours);
    }
}