using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KnockoutjsTest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Introduction()
        {
            return View();
        }

        public ActionResult ListsAndCollections()
        {
            return View();
        }

        public ActionResult SinglePageApplications()
        {
            return View();
        }

        public ActionResult CustomeBindings()
        {
            return View();
        }


        #region Helper Functions

        //Help to Get Cross-Domain Json Data.
        //Utilize ManualResetEvent to hold all thread items in tread pool to get the final result
        private void GetMailData()
        {
            StringBuilder sb = new StringBuilder();
            var events = new List<ManualResetEvent>();
            HttpClient httpClient = new HttpClient();


            for (int i = 1; i < 56; i++)
            {
                var resetEvent = new ManualResetEvent(false);
                events.Add(resetEvent);
                ThreadPool.QueueUserWorkItem((o) =>
                {
                    string address = string.Format("http://learn.knockoutjs.com/mail?mailID={0}", o.ToString());

                    //MARK: Take advantage of GetAsync() to handle any type of returned object
                    //var response = httpClient.GetAsync(address).Result;
                    //sb.Append(response.Content.ReadAsStringAsync().Result);

                    var response = httpClient.GetStringAsync(address).Result;
                    sb.AppendLine(response);
                    resetEvent.Set();
                }, i);
            }


            WaitHandle.WaitAll(events.ToArray());
            httpClient.Dispose();
            System.Diagnostics.Debug.WriteLine(sb.ToString());
        }

        #endregion

    }
}