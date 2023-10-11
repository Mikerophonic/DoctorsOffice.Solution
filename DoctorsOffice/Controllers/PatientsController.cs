using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DoctorsOffice.Models;
using System.Collections.Generic;
using System.Linq;

namespace DoctorsOffice.Controllers
{
 public class PatientsController: Controller
 {
  private readonly DoctorsOfficeContext _db;

  public PatientsController(DoctorsOfficeContext db)
  {
    _db = db;
  }

  public ActionResult Index()
  {
    List<Patient> model = _db.Patients.Include(patient => patient.Doctor).ToList();
    return View(model);
  }
  
  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Patient patient)
  {
    if (!ModelState.IsValid)
    {
      return View(patient);
    }
    else
    {
      _db.Patients.Add(patient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }

    public ActionResult Details(int id)
  {
    Patient thisPatient = _db.Patients.FirstOrDefault(patient => patient.PatientId == id);
    return View(thisPatient);
  }


 }
}
