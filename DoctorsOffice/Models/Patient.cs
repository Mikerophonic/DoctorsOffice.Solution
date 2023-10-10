using System.Collections.Generic;
using System;

namespace DoctorsOffice.Models
{
  public class Patient
  {
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime Birthday { get; set;}
    public Doctor Doctors { get; set; }
    public List<DoctorPatient> JoinEntities { get;}
  }
}