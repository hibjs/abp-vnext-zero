using Microsoft.AspNetCore.Mvc;

namespace AbpZero.Controllers;

public class HomeController : AbpZeroController
{
    public ActionResult Index()
    {
        return Redirect("~/swagger");
    }
}