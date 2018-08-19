using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SessionNetCore.Models;
using SessionNetCore.Services;
using System.Web.Http.Cors;



namespace SessionNetCore.Controllers
{
    [Route("api/[controller]/[action]")]
   // [ApiController]

    public class BookmarkController : Controller
    {

        [HttpPost]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public IActionResult AddBookmark([FromBody] Bookmark bookmark)
        {
            if (bookmark == null)
            {
                return BadRequest();
            }
            try
            {
                SessionService sessionService = new SessionService();
                sessionService.Set(HttpContext.Session, "bookmarks", bookmark);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public IActionResult GetBookmarks()
        {
            SessionService sessionService = new SessionService();
            sessionService.Get(HttpContext.Session, "bookmarks");
            return Ok();
        }
    }
}