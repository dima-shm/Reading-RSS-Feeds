using System.Web.Http;
using WebApp.Context;

namespace WebApp.Controllers
{
    public class ArticlesController : ApiController
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: api/Articles
        public IHttpActionResult GetArticles()
        {
            return Ok(db.Articles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}