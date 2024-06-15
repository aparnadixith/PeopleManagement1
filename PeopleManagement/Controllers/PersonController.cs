using Microsoft.AspNetCore.Mvc;

//using MVC_Project.Models.ViewModel;
using PeopleManagement.Models.ViewModel;
using PeopleManagement.Models;

public class PersonController : Controller
{
    private readonly IPeopleService _service;

    public PersonController(IPeopleService service)
    {
        _service = service;
    }

    public IActionResult Index(string searchString)
    {
        var person = string.IsNullOrWhiteSpace(searchString) ? _service.All() : _service.Search(searchString);
        var model = new PeopleViewModel
        {
            Person = person,
            SearchString = searchString
        };
        return View(model);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CreatePersonViewModel model)
    {
        if (ModelState.IsValid)
        {
            _service.Add(model);
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }

    public IActionResult Details(int id)
    {
        var person = _service.FindById(id);
        if (person == null)
        {
            return NotFound();
        }
        return View(person);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        _service.Remove(id);
        return RedirectToAction(nameof(Index));
    }
}