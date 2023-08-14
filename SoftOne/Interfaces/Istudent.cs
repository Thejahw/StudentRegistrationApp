using SoftOne.Models;
using SoftOne.ViewModels;

namespace SoftOne.Interfaces
{
    public interface Istudent
    {
        bool SaveStudent(StudentRequestResponse student);
        List<StudentDetails> GetStudents(string orderby);
        StudentDetails GetStudentsById(int id);
        List<StudentDetails> SearchStudent( string key);
        StudentRequestResponse Updatetudent(int id, StudentRequestResponse student);
        bool DeleteStudent(int id);
    }
}
