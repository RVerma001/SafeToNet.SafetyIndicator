using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SafeToNet.SafetyIndicator.Core.Models.Entities;

namespace SafeToNet.SafetyIndicator.Core.Services
{
    public interface ISafetyIndicatorService
    {
        Task CreateInsights(IEnumerable<Models.Entities.SafetyIndicator> enumerable);
        Task<IEnumerable<InsightGraph>> GetLastOneDayAndDeviceIdBy(Guid deviceId);
        Task<IEnumerable<InsightGraph>> GetParentAlertInsights(Guid deviceId, double hours, int minutes);
    }
}