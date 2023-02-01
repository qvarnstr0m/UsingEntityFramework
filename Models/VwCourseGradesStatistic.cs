namespace UsingEntityFramework.Models;

public partial class VwCourseGradesStatistic
{
    public int CourseId { get; set; }

    public string CourseName { get; set; }

    public string Medelbetyg { get; set; }

    public string SämstaBetyg { get; set; }

    public string BästaBetyg { get; set; }
}
