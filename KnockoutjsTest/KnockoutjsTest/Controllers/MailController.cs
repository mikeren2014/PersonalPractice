using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace KnockoutjsTest.Controllers
{
    public class MailController : ApiController
    {
        // GET: api/Api
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Api/5
        public async Task<HttpResponseMessage> Get(int id)
        {
            var mailData = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                string address = string.Format("http://learn.knockoutjs.com/mail?mailID={0}", id);
                mailData = await client.GetStringAsync(address);
            }
            HttpResponseMessage response = new HttpResponseMessage()
            {
                Content = new StringContent(
                mailData, Encoding.UTF8, "application/json")
            };
            return response;
        }

        // POST: api/Api
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Api/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Api/5
        public void Delete(int id)
        {
        }
    }
}
