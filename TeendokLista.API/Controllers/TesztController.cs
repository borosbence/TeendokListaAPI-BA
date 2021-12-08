using BasicAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TeendokLista.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Hitelesítés bekapcsolása a Controller metódusaihoz
    public class TesztController : ControllerBase
    {
        [HttpGet]
        [Route("Publikus")]
        [Route("Public")]
        [AllowAnonymous] // Hitelesítés nélkül is elérhető, akkor kell, ha Authorize van a controller-en
        public string Public()
        {
            return "Ezt a részt bárki láthatja.";
        }

        [HttpGet]
        [Route("TopSecret")]
        //[Authorize]
        [Authorize(Roles = "Adminisztrátor")] // Ezt csak adiminsztátor szerepkörű láthatja
        public string TopSecret()
        {
            return "Ez egy titkos szöveg.";
        }
    }
}
