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

        public StudentRequestResponse GetStudentsById(int id)
        {
            var DBStudent = _context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            if (DBStudent == null)
            {
                throw new ArgumentNullException("Invalid student id requested");
            }
            return new StudentRequestResponse
            {
                FirstName = DBStudent.FirstName,
                LastName = DBStudent.LastName,
                ContactNo = DBStudent.ContactNo,
                Email = DBStudent.Email,
                Ssn = DBStudent.Ssn,
                Dob = DBStudent.Dob,
                PrimaryAdressLine = DBStudent.PrimaryAdressLine,
                Street = DBStudent.Street,
                City = DBStudent.City,
                Country = DBStudent.Country,
            };
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
                throw new Exception("Soething went wrong while saving request");
            }            
        }

        public StudentRequestResponse Updatetudent(int id, StudentRequestResponse student)
        {
            var DBStudent = _context.Students.Where(x=>x.StudentId==id).FirstOrDefault();
            if (DBStudent == null)
            {
                throw new ArgumentNullException("Invalid student id requested");
            }
            DBStudent.FirstName = student.FirstName;
            DBStudent.LastName = student.LastName;
            DBStudent.ContactNo = student.ContactNo;
            DBStudent.Email = student.Email;
            DBStudent.Ssn = student.Ssn;
            DBStudent.Dob = student.Dob;
            DBStudent.Title = student.Title;
            DBStudent.StartDate = student.StartDate;
            DBStudent.PrimaryAdressLine = student.PrimaryAdressLine;
            DBStudent.Street = student.Street;
            DBStudent.City = student.City;
            DBStudent.Country = student.Country;

            _context.Students.Update(DBStudent);
            _context.SaveChanges();
            return new StudentRequestResponse
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                ContactNo = student.ContactNo,
                Email = student.Email,
                Ssn = student.Ssn,
                Dob = student.Dob,
                PrimaryAdressLine = student.PrimaryAdressLine,
                Street = student.Street,
                City = student.City,
                Country = student.Country,
            };
        }
    }
}
