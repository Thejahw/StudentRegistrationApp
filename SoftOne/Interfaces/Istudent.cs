using SoftOne.Models;
using SoftOne.ViewModels;

namespace SoftOne.Interfaces
{
    public interface Istudent
    {
        bool SaveStudent(StudentRequestResponse student);
        List<StudentRequestResponse> GetStudents(string orderby);
        StudentRequestResponse GetStudentsById(int id);
        StudentRequestResponse Updatetudent(int id, StudentRequestResponse student);
        bool DeleteStudent(int id);
    }
}
