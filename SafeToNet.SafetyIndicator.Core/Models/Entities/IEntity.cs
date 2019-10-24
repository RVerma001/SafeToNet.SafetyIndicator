using System;

namespace SafeToNet.SafetyIndicator.Core.Models.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
