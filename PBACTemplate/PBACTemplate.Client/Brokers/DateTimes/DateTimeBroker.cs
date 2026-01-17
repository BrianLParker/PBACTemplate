// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// DateTimeBroker.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Client.Brokers.DateTimes;

public class DateTimeBroker : IDateTimeBroker
{
    public DateTimeOffset GetCurrentDateTimeOffset() =>
        DateTimeOffset.UtcNow;
}
