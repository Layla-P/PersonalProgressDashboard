using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PersonalProgressDashboard.Web.Controllers
{
  [Route("api/[controller]")]
  public class FormController : Controller
  {
   
    [HttpGet]
    public IActionResult UserDetails()
    {
      return new JsonResult(new {value =  "Welcome"});
    }

    [HttpPost]
    public IActionResult Post([FromBody] Name name)
    {
      if (name.NameText == null)
      {
        return BadRequest();
      }
      return  new JsonResult(new {value= $"My name is {name.NameText.ToUpper()}"});
    }

    public class Name
    {
      public string NameText { get; set; }
    }
  }
}
