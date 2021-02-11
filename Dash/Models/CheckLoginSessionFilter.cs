using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dash.Models
{
    public class CheckLoginSessionFilter:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (HttpContext.Current.Session["User"] == null)
                filterContext.Result = new RedirectResult("/User/Login");
        }
    }
}