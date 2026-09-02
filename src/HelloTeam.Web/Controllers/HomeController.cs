using HelloTeam.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelloTeam.Web.Controllers;

public class HomeController : Controller
{
    private readonly HelloApiClient _helloApiClient;

    public HomeController(HelloApiClient helloApiClient)
    {
        _helloApiClient = helloApiClient;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _helloApiClient.GetHelloAsync();

        ViewBag.Message = response?.Message ?? "Unable to contact API.";

        return View();
    }
}
