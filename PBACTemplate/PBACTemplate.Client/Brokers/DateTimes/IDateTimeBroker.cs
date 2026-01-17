// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IDateTimeBroker.cs See LICENSE.txt in the root folder of the solution.


namespace PBACTemplate.Client.Brokers.DateTimes;

public interface IDateTimeBroker
{
    DateTimeOffset GetCurrentDateTimeOffset();
}
