using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;


namespace DoctorsOffice.Models
{
  public class Patient
  {
    public int PatientId { get; set; }
    [Required(ErrorMessage="Name cannot be empty")]
    public string Name { get; set; }
    [Required(ErrorMessage="Birthday cannot be empty")]
    public DateTime Birthday { get; set;}
    // public Doctor Doctor { get; set; }
    // public int DoctorId { get; set; }
    public List<DoctorPatient> JoinEntities { get; set;}
  }
}