using System.Web.Http;
using WebApp.Context;

namespace WebApp.Controllers
{
    public class ChannelsController : ApiController
    {
        private ApplicationContext context = new ApplicationContext();

        public IHttpActionResult GetChannels()
        {
            return Ok(context.Channels);
        }
    }
}