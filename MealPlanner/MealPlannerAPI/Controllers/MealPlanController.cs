using MealPlannerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MealPlannerAPI.Controllers
{
    public class MealPlanController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<MealPlanEvent> Get() {
            List<MealPlanEvent> events = new List<MealPlanEvent>();
            events.Add(new MealPlanEvent {
                title = "All Day Event",
                start = "2017-04-10"
            });
            events.Add(new MealPlanEvent {
                title = "All Day Event 2",
                start = "2017-04-13"
            });

            return events;
        }
    }
}