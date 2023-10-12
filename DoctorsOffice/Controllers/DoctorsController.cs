using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DoctorsOffice.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoctorsOffice.Controllers
{
  public class DoctorsController : Controller 
  {
    private readonly DoctorsOfficeContext _db;
    public DoctorsController(DoctorsOfficeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Doctor> model = _db.Doctors.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Doctor doctor)
    {
      _db.Doctors.Add(doctor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Show(int id)
    {
      Doctor thisDoctor = _db.Doctors
                              .Include(Doctor => Doctor.JoinEntities)
                              .ThenInclude(join => join.Patient)
                              .FirstOrDefault(doctor => doctor.DoctorId == id);
      return View(thisDoctor);
    }

      public ActionResult AddPatient(int id)
    {
      Doctor thisDoctor = _db.Doctors.FirstOrDefault(doctors => doctors.DoctorId == id);
      ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Name");
      return View(thisDoctor);
    }

    [HttpPost]
    public ActionResult AddPatient(Patient patient, int doctorId)
    {
      #nullable enable
      DoctorPatient? joinEntity = _db.DoctorsPatients.FirstOrDefault(join => (join.PatientId == patient.PatientId && join.DoctorId == doctorId));
      #nullable disable
      if(joinEntity == null && doctorId != 0)
      {
        _db.DoctorsPatients.Add(new DoctorPatient() { PatientId = patient.PatientId, DoctorId = doctorId });
        _db.SaveChanges();
      }
      return RedirectToAction("Show", new { id = doctorId });
    }
 }
}


/*

Paul
Chrisitine 
Pisces

Paul
Geraldine
Scorpio



    public ActionResult AddDoctor(int id) (MODELS) DB -(ActionResult)> {model.Patient.Name}
    {
      Patient thisPatient = _db.Patients.FirstOrDefault(patients => patients.PatientId == id);
      ViewBag.DoctorId = new SelectList(_db.Doctors, "DoctorId", "Name");
      return View(thisDoctor);
    }

    [HttpPost]
    public ActionResult AddDoctor(Doctor item, int id)
    {
      #nullable enable
      ItemTag? joinEntity = _db.ItemTags.FirstOrDefault(join => (join.TagId == tagId && join.ItemId == item.ItemId));
      #nullable disable
      if(joinEntity == null && tagId != 0)
      {
        _db.ItemTags.Add(new ItemTag { TagId = tagId, ItemId = item.ItemId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = item.ItemId });
    }




*/