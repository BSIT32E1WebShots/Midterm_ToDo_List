using Microsoft.AspNetCore.Mvc;
using ToDo.Services;
using ToDo.Repository;
using ToDo.Domain;

public class ToDoController : Controller
{
    private readonly ToDoService _toDoService;

    public ToDoController(ToDoService toDoService)
    {
        _toDoService = toDoService;
    }

    public ActionResult Index()
    {
        var todos = _toDoService.GetAll();

        // Add numbering to the todos
        var numberedTodos = todos.Select((todo, index) =>
            new Tuple<int, ToDo.Domain.ToDo>(index + 1, todo)).ToList();

        return View(numberedTodos);
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(ToDo.Domain.ToDo todo)
    {
        if (string.IsNullOrWhiteSpace(todo.Task) || string.IsNullOrWhiteSpace(todo.Date))
        {
            ModelState.AddModelError("", "Fields must not be empty");
            return View(todo);
        }
        _toDoService.Create(todo);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
        var todo = _toDoService.GetById(id);
        return View(todo);
    }

    [HttpPost]
    public ActionResult Edit(ToDo.Domain.ToDo todo)
    {
        if (string.IsNullOrWhiteSpace(todo.Task) || string.IsNullOrWhiteSpace(todo.Date))
        {
            ModelState.AddModelError("", "Fields must not be empty");
            return View(todo);
        }
        _toDoService.Update(todo);
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        _toDoService.Delete(id);
        return RedirectToAction("Index");
    }
}