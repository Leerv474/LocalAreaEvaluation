using Microsoft.AspNetCore.Mvc;

namespace Areas.BackOffice.Controllers;

public class AppController : Controller
{
	public IActionResult App()
	{
		return View("App");
	}
}
