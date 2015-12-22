using System;
using System.Collections.Concurrent;
using Nancy;
using Nancy.Extensions;
using Nancy.Responses;
using Newtonsoft.Json;

namespace RAMLDemo.Api
{
    // Quick and dirty implementatation to satisfy the integration test

    public class StatusModule : NancyModule
    {
        private static readonly ConcurrentDictionary<string, StatusInformation> Statuses =
            new ConcurrentDictionary<string, StatusInformation>(); 

        public StatusModule() : base("/v1/status")
        {
            Get["/{parcelId}"] = ctx =>
            {
                if (!Statuses.ContainsKey(ctx.parcelId))
                    return HttpStatusCode.NotFound;

                return new JsonResponse(
                    Statuses[ctx.parcelId], 
                    new DefaultJsonSerializer());
            };

            Put["/{parcelId}"] = ctx =>
            {
                dynamic obj = JsonConvert.DeserializeObject(Request.Body.AsString());

                Statuses[ctx.parcelId] = new StatusInformation
                {
                    Status = obj.status.Value,
                    Updated = DateTime.UtcNow.ToString("o")
                };

                return HttpStatusCode.Created;
            };
        }
    }

    public class StatusInformation
    {
        public string Status { get; set; }
        public string Updated { get; set; }
    }
}