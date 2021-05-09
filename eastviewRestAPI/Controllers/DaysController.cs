using EastviewRestAPI.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EastviewRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaysController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<DayItem> GetDaysOfWeek()
        {            
            return GetAllDays();
        }

        [HttpGet("today")]
        public DayItem GetTodayDay()
        {
            var today = DateTime.Now;
           
            return new DayItem((int)today.DayOfWeek, today.DayOfWeek.ToString());
        }

        private IEnumerable<DayItem> GetAllDays() {
            var list = new List<DayItem>();
            list.Add(new DayItem((int)DayOfWeek.Monday, DayOfWeek.Monday.ToString()));
            list.Add(new DayItem((int)DayOfWeek.Tuesday, DayOfWeek.Tuesday.ToString()));
            list.Add(new DayItem((int)DayOfWeek.Wednesday, DayOfWeek.Wednesday.ToString()));
            list.Add(new DayItem((int)DayOfWeek.Thursday, DayOfWeek.Thursday.ToString()));
            list.Add(new DayItem((int)DayOfWeek.Friday, DayOfWeek.Friday.ToString()));
            list.Add(new DayItem((int)DayOfWeek.Saturday, DayOfWeek.Saturday.ToString()));
            list.Add(new DayItem((int)DayOfWeek.Sunday, DayOfWeek.Sunday.ToString()));
            
            return list;
        }
    }
}
