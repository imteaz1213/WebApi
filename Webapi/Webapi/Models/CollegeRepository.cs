namespace Webapi.Models
{
    public static class CollegeRepository
    {
        public static List<Student> Students { get; set; } = new List<Student>(){
                new Student
                {
                    Id = 1,
                    StudentName = "John Doe",
                    Email = "john@gmail.com",
                    Address = "123 Main St, City, Country"
                },
                new Student
                {
                    Id = 2,
                    StudentName = "Jane Smith",
                    Email = "smith@gmail.com",
                    Address = "456 Elm St, City, Country"
                },
                new Student
                {
                    Id = 3,
                    StudentName = "imteaz",
                    Email = "imteaz@gmail.com",
                    Address = "sylhet"
                }
        };
    }
}
