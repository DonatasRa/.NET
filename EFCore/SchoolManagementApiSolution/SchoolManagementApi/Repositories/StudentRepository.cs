using SchoolManagementApi.Data;
using SchoolManagementApi.Models;

namespace SchoolManagementApi.Repositories
{
    public class StudentRepository : RepositoryBase<Student>
    {
        public StudentRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
