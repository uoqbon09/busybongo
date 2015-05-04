using BusyBongo.Web.App_Start;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BusyBongo.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Drop the WebForms view engine
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ResetMachinekey();
        }

        private void ResetMachinekey()
        {
            if (Context.IsDebuggingEnabled)
            {
                return;
            }            

            try
            {
                Trace.TraceInformation("Start ResetMachineKey()");

                var mksType = typeof(MachineKeySection);
                var mksSection = ConfigurationManager.GetSection("system.web/machineKey") as MachineKeySection;
                var resetMethod = mksType.GetMethod("Reset", BindingFlags.NonPublic | BindingFlags.Instance);

                var newConfig = new MachineKeySection();
                newConfig.ApplicationName = mksSection.ApplicationName;
                newConfig.CompatibilityMode = mksSection.CompatibilityMode;
                newConfig.DataProtectorType = mksSection.DataProtectorType;
                newConfig.Validation = mksSection.Validation;

                Trace.TraceInformation("Decryption: " + mksSection.Decryption);
                Trace.TraceInformation("DecryptionKey: " + mksSection.DecryptionKey);
                Trace.TraceInformation("Validation: " + mksSection.Validation);
                Trace.TraceInformation("ValidationKey: " + mksSection.ValidationKey);

                newConfig.ValidationKey = ConfigurationManager.AppSettings["MKEY_VALIDATIONKEY"];
                newConfig.DecryptionKey = ConfigurationManager.AppSettings["MKEY_DECRYPTIONKEY"];
                newConfig.Decryption = ConfigurationManager.AppSettings["MKEY_DECRYPTION"]; // default: AES
                newConfig.ValidationAlgorithm = ConfigurationManager.AppSettings["MKEY_VALIDATION"]; // default: SHA1

                resetMethod.Invoke(mksSection, new object[] { newConfig });

                Trace.TraceInformation("Decryption: " + mksSection.Decryption);
                Trace.TraceInformation("DecryptionKey: " + mksSection.DecryptionKey);
                Trace.TraceInformation("Validation: " + mksSection.ValidationAlgorithm);
                Trace.TraceInformation("ValidationKey: " + mksSection.ValidationKey);
            }
            finally
            {
                Trace.TraceInformation("End ResetMachineKey()");
            }
            
        }
    }
}
