using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers;

public class HomeController : Controller
{
    public ViewResult Index()
    {
        int hour = DateTime.Now.Hour;
        ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
        return View("MyView");
    }

    [HttpGet]
    public ViewResult RsvpForm() => View();

    [HttpPost]
    public ViewResult RsvpForm(GuestResponse guestResponse)
    {
        if (ModelState.IsValid)
        {
            Repository.AddResponse(guestResponse);
            return View("Thanks", guestResponse);
        }

        return View();

    }

    public ViewResult ListResponses() => View(Repository.Responses.Where(r => r.WillAttend == true));
}
