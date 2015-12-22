using System;
using System.Collections.Concurrent;
using Nancy;

namespace RAMLDemo.Api
{
    public class StatusModule : NancyModule
    {
        private static readonly ConcurrentDictionary<string, StatusInformation> Statuses =
            new ConcurrentDictionary<string, StatusInformation>(); 

        public StatusModule() : base("/v1/status")
        {
            Get["/{parcelId}"] = ctx => Statuses[ctx.parcelId];

            Put["/{parcelId}"] = ctx =>
            {
                Statuses[ctx.parcelId] = new StatusInformation
                {
                    Status = ctx.Status,
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