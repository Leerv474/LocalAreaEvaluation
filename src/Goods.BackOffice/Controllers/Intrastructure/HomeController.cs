using Microsoft.AspNetCore.Mvc;

namespace Goods.BackOffice.Controllers.Infrastructure;

public class HomeController : AppController
{
	[Route("/"), Route("/local_areas")]
	public IActionResult Index() => App();
}
