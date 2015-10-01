using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Models
{
    public class ProfileModelBinder : DefaultModelBinder
    {
        protected override void OnModelUpdated(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var userProfileBase = bindingContext.Model as Movie;
            if (userProfileBase != null)
            {
                userProfileBase.MovieName = controllerContext.HttpContext.User.Identity.Name;
            }

            base.OnModelUpdated(controllerContext, bindingContext);
        }
    }
}