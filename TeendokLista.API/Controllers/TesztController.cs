using BasicAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TeendokLista.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesztController : ControllerBase
    {
        [HttpGet]
        [Route("Publikus")]
        [AllowAnonymous] // Akkor kell, ha Authorize van a controller-en
        public string Public()
        {
            return "Ezt a részt bárki láthatja.";
        }

        [HttpGet]
        [Route("TopSecret")]
        //[Authorize]
        [Authorize(Roles = "Adminisztrátor")]
        public string TopSecret()
        {
            return "Ez egy titkos szöveg.";
        }
    }
}
