using Moq;
using Moq.AutoMock;
using SafeToNet.SafetyIndicator.Api.Controllers;
using SafeToNet.SafetyIndicator.Core.Models.Entities;
using SafeToNet.SafetyIndicator.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafeToNet.SafetyIndicator.TestHelper
{
    public class MockIoc
    {
        public SafetyIndicatorController Controller { get; private set; }

        public Mock<ISafetyIndicatorService> Service { get; private set; }

        public MockIoc()
        {
            var mocker = new AutoMocker(MockBehavior.Loose);

            var controller = mocker.CreateInstance<SafetyIndicatorController>();
            var service = mocker.GetMock<ISafetyIndicatorService>();
            
            Controller = controller;
            Service = service;
        }
    }
}