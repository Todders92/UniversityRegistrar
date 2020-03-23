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
    //       ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "Name");
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
    //       var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
    //       ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "Name");
    //       return View(thisStudent);
    //     }

    //     [HttpPost]
    //     public ActionResult Edit(Student student)
    //     {
    //       _db.Entry(student).State = EntityState.Modified;
    //       _db.SaveChanges();
    //       return RedirectToAction("Index");
    //     }

    //     public ActionResult Delete(int id)
    //     {
    //       var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
    //       return View(thisStudent);
    //     }

    //     [HttpPost, ActionName("Delete")]
    //     public ActionResult DeleteConfirmed(int id)
    //     {
    //       var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
    //       _db.Students.Remove(thisStudent);
    //       _db.SaveChanges();
    //       return RedirectToAction("Index");
    //     }
  }
}