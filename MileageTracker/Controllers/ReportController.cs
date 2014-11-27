using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MileageTracker.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index(string employeeId = null)
        {
            
            if (employeeId != null)
            {
                string reportServerUrl = ConfigurationManager.AppSettings["ReportServerUrl"];
                string reportUrl = reportServerUrl + "&employeeId=" + employeeId;

                return Redirect(reportUrl);
                //ViewBag.ReportUrl = reportUrl;
            }
            
           // string userName = System.Web.Configuration.WebConfigurationManager.AppSettings["ApiUserName"];

            return View();
        }
    }
}