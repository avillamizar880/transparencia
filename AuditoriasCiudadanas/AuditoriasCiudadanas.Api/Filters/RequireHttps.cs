using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Services.Description;

namespace AuditoriasCiudadanas.Api.Filters
{
    public class RequireHttps : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext?.Request != null && !actionContext.Request.RequestUri.Scheme.Equals(Uri.UriSchemeHttps))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
                actionContext.Response.Content = new StringContent("Requested URI requires HTTPS");
            }
        }
    }
}