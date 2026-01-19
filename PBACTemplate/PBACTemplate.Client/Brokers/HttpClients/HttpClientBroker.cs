// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// HttpClientBroker.cs See LICENSE.txt in the root folder of the solution.


namespace PBACTemplate.Client.Brokers.HttpClients;

public partial class HttpClientBroker(HttpClient httpClient) : IHttpClientBroker
{
    private readonly HttpClient httpClient = httpClient;

}
