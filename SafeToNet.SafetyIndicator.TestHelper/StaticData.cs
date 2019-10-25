using SafeToNet.SafetyIndicator.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafeToNet.SafetyIndicator.TestHelper
{
    public static class StaticData
    {
        public static Guid DeviceID = Guid.Parse("01f32b72-c7f6-47f8-a161-7fa1272e0dc6");

        public static List<Core.Models.Entities.SafetyIndicator> NullInsights = null;

        public static DateTime TestDate = new DateTime(2019, 09, 01, 15, 0, 0);

        public static List<Core.Models.Entities.SafetyIndicator> InsightsRequests = new List<Core.Models.Entities.SafetyIndicator>
        {
            new Core.Models.Entities.SafetyIndicator
            {
                DeviceId = Guid.Parse("01f32b72-c7f6-47f8-a161-7fa1272e0dc6"),
                ProtectionLevel = 3,
                DateGenerated = DateTime.Now
            },

            new Core.Models.Entities.SafetyIndicator
            {
                DeviceId = Guid.Parse("01f32b72-c7f6-47f8-a161-7fa1272e0dc6"),
                ProtectionLevel = 3,
                DateGenerated = DateTime.Now
            }
        };

        public static List<InsightGraph> InsightGraphs = new List<InsightGraph>()
        {
            new InsightGraph
            {
                DateGenerated = TestDate,
                Value = 50.0M
            },
            new InsightGraph
            {
                DateGenerated = TestDate.AddMinutes(5),
                Value = 52.5M
            },
            new InsightGraph
            {
                DateGenerated = TestDate.AddMinutes(5),
                Value = 55.1M
            },
            new InsightGraph
            {
                DateGenerated = TestDate.AddMinutes(5),
                Value = 60.5M
            },
            new InsightGraph
            {
                DateGenerated = TestDate.AddMinutes(5),
                Value = 70.5M
            },
        };
    }
}