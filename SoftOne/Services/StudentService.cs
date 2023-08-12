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

        public List<StudentRequestResponse> GetStudents(string orderby)
        {
            IQueryable<Student> DBStudents;
            switch (orderby)
            {
                case "FirstName":
                    DBStudents = _context.Students.OrderBy(x => x.FirstName).Take(10);
                    break;
                case "LastName":
                    DBStudents = _context.Students.OrderBy(x => x.LastName).Take(10);
                    break;
                case "SSN":
                    DBStudents = _context.Students.OrderBy(x => x.Ssn).Take(10);
                    break;
                default:
                    DBStudents = _context.Students.OrderBy(x => x.StudentId).Take(10);
                    break;
            }
             

            var students = new List<StudentRequestResponse>();
            foreach(var student in DBStudents)
            {
                var studentDetails = new StudentRequestResponse
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    ContactNo = student.ContactNo,
                    Email = student.Email,
                    Ssn = student.Ssn
                };
                students.Add(studentDetails);
            }

            return students;
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
