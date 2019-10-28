using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using SafeToNet.SafetyIndicator.Core.Models.Entities;
using SafeToNet.SafetyIndicator.Core.Repositories;
using Enumerable = System.Linq.Enumerable;

namespace SafeToNet.SafetyIndicator.Core.Services
{
    public class SafetyIndicatorService : ISafetyIndicatorService
    {
        private readonly ISafetyIndicatorRepository _safetyIndicatorRepository;

        public SafetyIndicatorService(ISafetyIndicatorRepository safetyIndicatorRepository)
        {
            _safetyIndicatorRepository = safetyIndicatorRepository;
        }

        public async Task CreateInsights(IEnumerable<Models.Entities.SafetyIndicator> insights)
        {
            var enumerable = insights as Models.Entities.SafetyIndicator[] ?? insights.ToArray();
            if (insights == null || !EnumerableExtensions.Any(enumerable))
                throw new ArgumentException(nameof(insights));

            await _safetyIndicatorRepository.Insert(enumerable);
        }

        public async Task<IEnumerable<InsightGraph>> GetLastOneDayAndDeviceIdBy(Guid deviceId)
        {
            var insights = await _safetyIndicatorRepository.GetLastOneDayAndDeviceIdBy(deviceId);

            return GroupInsightsBy(insights, 15);
        }

        private static IEnumerable<InsightGraph> GroupInsightsBy(IEnumerable<Models.Entities.SafetyIndicator> insights, int groupBy)
        {
            try
            {
                //var list = new List<InsightGraph>();
                //var filteredInsights = insights.Where(t => t.DateGenerated.Minute % groupBy == 0);
                //foreach (var insight in filteredInsights)
                //{
                //    list.Add(new InsightGraph()
                //    {
                //        Value = insight.ProtectionLevel,
                //        DateGenerated = insight.DateGenerated
                //    });
                //}

                //var newList = list.ToAsyncEnumerable();

                //var orderedList = newList.OrderBy(r => r.DateGenerated).ToEnumerable();

                //return orderedList;

                var graphData = (from insight in insights
                                 where insight.DateGenerated.Minute % groupBy == 0
                                 select new InsightGraph
                                 {
                                     Value = insight.ProtectionLevel,
                                     DateGenerated = insight.DateGenerated
                                 }).ToAsyncEnumerable();

                return graphData.OrderBy(r => r.DateGenerated).ToEnumerable();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<InsightGraph>> GetParentAlertInsights(Guid deviceId, double hours, int minutes)
        {
            var insights = await _safetyIndicatorRepository.GetLastHoursInsightsByDeviceId(deviceId, hours);

            return GroupInsightsBy(insights, minutes);
        }
    }
}