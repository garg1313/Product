public enum level
{
    Beginner,
    Intermediate,
    Advance

}
public enum Languages
{
    CSharp,
    Cpp,
    Java
}
abstract class Course
{
    private string _Cname;
    private string _Instructor;
    private string _Duration;

    public Course(string Cname, string Instructor, string Duration)
    {
        _Cname = Cname;
        _Instructor = Instructor;
        _Duration = Duration;
    }
    public string Cname
    {
        get
        {
            return _Cname;
        }
    }
    public string Instructor
    {
        get
        {
            return _Instructor;
        }
    }
    public string Duration
    {
        get
        {
            return _Duration;
        }

    }
    public void Details()
    {
        Console.WriteLine($"CourseName :-{_Cname}, Instructor :-{_Instructor}, Duration:- {_Duration}");

    }
    public virtual void Cost(int duration)
    {

    }
}

class ProgrammingCourse : Course
{
    private int cost;
    public Languages Language { get; set; }
    public level Level { get; set; }
    public ProgrammingCourse(string Cname, string Instructor, string Duration, level lev, Languages lan) : base(Cname, Instructor, Duration)
    {
        Language = lan;
        Level = lev;

    }
    public override void Cost(int Duration)
    {
        cost = Duration * 2000;
        if (Language == Languages.CSharp)
        {
            cost += 2700;
        }
        Console.WriteLine("Cost is " + cost);

    }

}
class DesignCourse : Course
{
    private int cost;
    public string Software { get; set; }

    public string Toolset { get; set; }
    public DesignCourse(string Cname, string Instructor, string Duration) : base(Cname, Instructor, Duration) { }
    public override void Cost(int Duration)
    {
        cost = Duration * 1000;
        Console.WriteLine("Cost is " + cost);
    }

}


class BusinessCourse : Course
{
    private int cost;
    BusinessCourse(string Cname, string Instructor, string Duration) : base(Cname, Instructor, Duration) { }
    public string TargetAudience { get; set; }
    public string Outcome { get; set; }
    public override void Cost(int Duration)
    {
        cost = Duration * 5000;
        Console.WriteLine("Cost is " + cost);
    }
}










class Run
{
    /*public static void Main( string[] args )
    {
        ProgrammingCourse programmingCourse=new ProgrammingCourse("CPP by Jatin","Jatin Garg","6Months",level.Advance,Languages.Cpp);
        programmingCourse.Details();
        programmingCourse.Cost(6);
    }*/
}


