public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
}

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
}

public class StudentCourse
{
    public int Id{get; set;}
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
}
