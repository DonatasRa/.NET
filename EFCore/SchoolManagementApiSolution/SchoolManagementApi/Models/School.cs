using SchoolManagementApi.Models.Bases;

namespace SchoolManagementApi.Models

{
    public class School : NamedEntity
    {
        public List<Student> Students { get; set; }
    }
}
