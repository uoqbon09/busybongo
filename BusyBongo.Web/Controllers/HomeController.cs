using System.Configuration;
using System.Diagnostics;
using System.Web.Configuration;
using System.Web.Mvc;

namespace BusyBongo.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var mksSection = ConfigurationManager.GetSection("system.web/machineKey") as MachineKeySection;
            Trace.TraceInformation("Decryption: " + mksSection.Decryption);
            Trace.TraceInformation("DecryptionKey: " + mksSection.DecryptionKey);
            Trace.TraceInformation("Validation: " + mksSection.ValidationAlgorithm);
            Trace.TraceInformation("ValidationKey: " + mksSection.ValidationKey);

            return View();
        }
    }
}