using SoftOne.Interfaces;
using SoftOne.Models;
using SoftOne.ViewModels;

namespace SoftOne.Services
{
    public class StudentService : Istudent
    {
        private readonly SoftOneContext _context;
        public StudentService(SoftOneContext context)
        {
            _context = context;
        }
        public bool SaveStudent(StudentRequestResponse student)
        {
            try
            {
                var studentRecord = new Student
                {
                    FirstName = student.FirstName,

                    LastName = student.LastName,

                    ContactNo = student.ContactNo,

                    Email = student.Email,

                    Ssn = student.Ssn,

                    Dob = student.Dob,

                    Title = student.Title,

                    StartDate = student.StartDate,

                    ContactPersonName = student.ContactPersonName,

                    ContactPersonNumber = student.ContactPersonNumber,

                    PrimaryAdressLine = student.PrimaryAdressLine,

                    Street = student.Street,

                    City = student.City,

                    Country = student.Country,

                };
                _context.Students.Add(studentRecord);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                 
                return false;
            }
            
        }
    }
}
