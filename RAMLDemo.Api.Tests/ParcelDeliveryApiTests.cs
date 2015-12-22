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
        public async Task SimpleTest()
        {
            const string endpoint = "http://localhost/raml-demo-api/v1/status";
            const string parcelId = "123456";
            const string status = "Parcel is out for delivery.";
            var parcelDeliveryApiClient = new ParcelDeliveryApiClient(endpoint);

            var putResult =
                await parcelDeliveryApiClient.StatusParcelId.Put(
                    new StatusParcelIdPutRequestContent
                    {
                        Status = status
                    },
                    parcelId);

            Assert.AreEqual(HttpStatusCode.Created, putResult.StatusCode);

            var getResult = await parcelDeliveryApiClient.StatusParcelId.Get(parcelId);

            Assert.AreEqual(HttpStatusCode.OK, getResult.StatusCode);
            Assert.AreEqual(status, getResult.Content.StatusParcelIdGetOKResponseContent.Status);
        }
    }
}
