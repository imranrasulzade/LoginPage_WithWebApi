using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(Mushteri mushteri) {
            using(HttpClient client= new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7156/api/");
                HttpResponseMessage response = await client.PostAsJsonAsync("WebApi/CheckLogin", mushteri);
                if(response.IsSuccessStatusCode)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,"ClaimName")
                    };

                    var useridentity = new ClaimsIdentity(claims, "Index");
                    ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);


                    await HttpContext.SignInAsync(principal);

                    return RedirectToAction("Index2");
                }
            }
            return View();
        }

        public IActionResult Index2() {
        return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}
