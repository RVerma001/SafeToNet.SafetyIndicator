using System;
using System.Collections.Generic;

namespace SafeToNet.SafetyIndicator.TestHelper
{
    public static class StaticData
    {
        public static Guid DeviceID = Guid.Parse("01f32b72-c7f6-47f8-a161-7fa1272e0dc6");

        public static List<Core.Models.Entities.SafetyIndicator> NullInsights = null;

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
    }
}
