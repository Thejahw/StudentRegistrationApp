using SoftOne.Models;
using SoftOne.ViewModels;

namespace SoftOne.Interfaces
{
    public interface Istudent
    {
        bool SaveStudent(StudentRequestResponse student);
        List<StudentRequestResponse> GetStudents(string orderby);
    }
}
