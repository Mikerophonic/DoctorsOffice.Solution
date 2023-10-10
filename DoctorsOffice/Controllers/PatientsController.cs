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
    List<Patient> model = _db.Patients.Include(patient => patient.Doctors).ToList();
    return View(model);
  }
  
 }
}
