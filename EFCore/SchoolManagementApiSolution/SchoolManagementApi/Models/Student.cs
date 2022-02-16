using SchoolManagementApi.Models.Bases;

namespace SchoolManagementApi.Models
{
    public class Student : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int SchoolId { get; set; }
    }
}
