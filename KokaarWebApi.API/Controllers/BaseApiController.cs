using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KokaarWebApi.API.Controllers
{    
    public class BaseApiController : ControllerBase
    {
        public string CurrentUser => string.IsNullOrEmpty(User.Identity.Name) ? "armand" : User.Identity.Name;
    }
}