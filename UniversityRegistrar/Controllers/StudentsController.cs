using Microsoft.AspNetCore.Mvc;
using UniversityRegistrar.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniversityRegistrar.Controllers
{
  public class StudentsController : Controller
  {
    private readonly UniversityRegistrarContext _db;

    public StudentsController(UniversityRegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Students.ToList());
    }

    //     public ActionResult Create()
    //     {
    //       ViewBag.CourseId = new SelectList(_db.Categories, "CourseId", "Name");
    //       return View();
    //     }

    //     [HttpPost]
    //     public ActionResult Create(Student student)
    //     {
    //       _db.Students.Add(student);
    //       _db.SaveChanges();
    //       return RedirectToAction("Index");
    //     }

    public ActionResult Details(int id)
    {
      var thisStudent = _db.Students
          .Include(student => student.Courses)
          .ThenInclude(join => join.Course)
          .FirstOrDefault(student => student.StudentId == id);
      return View(thisStudent);
    }

    //     public ActionResult Edit(int id)
    //     {
    //       var thisItem = _db.Students.FirstOrDefault(students => students.ItemId == id);
    //       ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
    //       return View(thisItem);
    //     }

    //     [HttpPost]
    //     public ActionResult Edit(Item item)
    //     {
    //       _db.Entry(item).State = EntityState.Modified;
    //       _db.SaveChanges();
    //       return RedirectToAction("Index");
    //     }

    //     public ActionResult Delete(int id)
    //     {
    //       var thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
    //       return View(thisItem);
    //     }

    //     [HttpPost, ActionName("Delete")]
    //     public ActionResult DeleteConfirmed(int id)
    //     {
    //       var thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
    //       _db.Items.Remove(thisItem);
    //       _db.SaveChanges();
    //       return RedirectToAction("Index");
    //     }
  }
}