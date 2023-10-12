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
    List<Patient> model = _db.Patients.ToList();
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

    public ActionResult Show(int id)
  {
    // Patient thisPatient = _db.Patients.FirstOrDefault(patient => patient.PatientId == id);
    Patient thisPatient = _db.Patients
                             .Include(patient => patient.JoinEntities)
                             .ThenInclude(join => join.Doctor)
                             .FirstOrDefault(patient => patient.PatientId == id);
    return View(thisPatient);
  }

  public ActionResult AddDoctor(int id)
    {
      Patient thisPatient = _db.Patients.FirstOrDefault(patients => patients.PatientId == id);
      ViewBag.DoctorId = new SelectList(_db.Doctors, "DoctorId", "Name");
      return View(thisPatient);
    }

  [HttpPost]
  public ActionResult AddDoctor(Doctor doctor, int patientId)
  {
    #nullable enable
    DoctorPatient? joinEntity = _db.DoctorsPatients.FirstOrDefault(join => (join.DoctorId == doctor.DoctorId && join.PatientId == patientId));
    #nullable disable
    if(joinEntity == null && patientId != 0)
    {
      _db.DoctorsPatients.Add(new DoctorPatient() { DoctorId = doctor.DoctorId, PatientId = patientId });
      _db.SaveChanges();
    }
    return RedirectToAction("Show", new { id = patientId });
  }
 }
}
