using KnockoutjsTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KnockoutjsTest.Controllers
{
    public class TasksController : ApiController
    {
        List<TaskInfo> taskInfos = new List<TaskInfo>
        {
            new TaskInfo {  Title = "task1",IsDone = false},
            new TaskInfo {  Title = "task2",IsDone = false},
            new TaskInfo {  Title = "task3",IsDone = false},
            new TaskInfo {  Title = "task4",IsDone = false}
        };

        // GET api/<controller>
        public IEnumerable<TaskInfo> GetAllTaskInfos()
        {
            return taskInfos;
        }

        // GET api/<controller>/5
        public IHttpActionResult GetTaskInfo(string id)
        {
            var taskInfo = taskInfos.FirstOrDefault(t => t.Title == id);
            if (taskInfo == null)
            {
                return NotFound();
            }
            return Ok(taskInfo);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}