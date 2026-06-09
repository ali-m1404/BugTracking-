using System.ComponentModel;

namespace BugTracker.Api.Enums;

public enum BugPriority
{
    [Description("Low Priority")]
    Low = 1,

    [Description("Medium Priority")]
    Medium = 2,

    [Description("High Priority")]
    High = 3,

    [Description("Critical Priority")]
    Critical = 4
}