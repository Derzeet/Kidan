using System.Diagnostics;
using System.Dynamic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{

    private UniStatContext db = new UniStatContext();
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var Students = db.Students.ToList(); 
        return View("Index", Students);
        
    }
    public IActionResult Register()
    {
        var universities = db.Universities.ToList();
        return View("Register", universities);
    }
    [HttpPost]
    public IActionResult Register(string Name, string Surname, string Date_Of_Birth, int Course, string Degree, string Uni_Id, string Login, string Password)
    {
        Student student = new Student();
        student.SetModel(Name, Surname, Course, Degree, Date_Of_Birth, Uni_Id, Login, Password);
        db.Students.Add(student); 
        db.SaveChanges();
        
        return RedirectToAction("Index");
    }

    public IActionResult Map()
    {
        University uni = new University();
        List<University> universities = new List<University>();
        uni.GetModels(db, out universities);
        return View("Map", universities);
    }

    public IActionResult Details(int? id)
    {
        Student student = db.Students.Find(id);
        if (student == null)
        {
            return View();
        }
        return View(student);
    }

    public IActionResult UniReg()
    {
        return View();
    }
    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult UniReg(University university)
    {
        db.Universities.Add(university); 
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult UniDetails(string? Uni_Id)
    {
        ViewModel viewModel = new ViewModel();
        University university = db.Universities.Where(b => b.ShortName == Uni_Id).FirstOrDefault();
        List<StatisticModel> stat =  university.Stat(db);
        viewModel.University = university;
        viewModel.Statistic = stat;
        if (university == null)
        {
            return Index();
        }
        return View(viewModel);
    }

    public IActionResult DropModel(int? id)
    {
        
        Student student = db.Students.SingleOrDefault(b => b.Id == id);
        if (student != null)
        {
            student.DropModel(); 
            db.SaveChanges();
        }

        return RedirectToAction("Index");
    }
    
    
    
    
    
    
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}