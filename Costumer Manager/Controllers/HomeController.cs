using Costumer_Manager.Data.DataModels;
using Costumer_Manager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Costumer_Manager.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<CustomerModel> list = new();
        CustomerModel customer = new CustomerModel() 
        { 
            Name = "Giovanni",
            Email = "teste@teste.com",
            Password = "password"
        };
        list.Add(customer);

        HomeViewModel homeViewModel = new HomeViewModel();
        homeViewModel.CustomerList = list;

        return View(homeViewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
