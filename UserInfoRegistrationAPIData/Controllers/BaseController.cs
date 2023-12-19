using ServiceDBAccess;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace RegistrationAPI.Controllers
{
    public class BaseController : ApiController
    {
        public static readonly JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
        public BaseController()
        {
            entity = new SampleDBEntities();
        }

        protected SampleDBEntities entity { get; set; }
























        protected override void Dispose(bool disposing)
        {
            entity.Dispose();
            base.Dispose(disposing);
        }


    }
}
