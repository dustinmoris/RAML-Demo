using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using RAMLDemo.Api.Tests.Api;
using RAMLDemo.Api.Tests.Api.Models;

namespace RAMLDemo.Api.Tests
{
    [TestFixture]
    public class ParcelDeliveryApiTests
    {
        [Test]
        public async Task IntegrationTest1()
        {
            // Arrange test arguments
            const string endpoint = "http://localhost/raml-demo-api/v1/status";
            const string parcelId = "123456";
            const string status = "Parcel is out for delivery.";

            // Initialize auto-generated API client from RAML file
            var parcelDeliveryApiClient = new ParcelDeliveryApiClient(endpoint);

            // Fire PUT request on status endpoint
            var putResult =
                await parcelDeliveryApiClient.StatusParcelId.Put(
                    new StatusParcelIdPutRequestContent
                    {
                        Status = status
                    },
                    parcelId);

            // Validate that response was successful according to the spec
            Assert.AreEqual(HttpStatusCode.Created, putResult.StatusCode);

            // Fire GET request to the same endpoint
            var getResult = await parcelDeliveryApiClient.StatusParcelId.Get(parcelId);

            // Validate that the request was successful and the returned status matches the original string
            Assert.AreEqual(HttpStatusCode.OK, getResult.StatusCode);
            Assert.AreEqual(status, getResult.Content.StatusParcelIdGetOKResponseContent.Status);
        }
    }
}
