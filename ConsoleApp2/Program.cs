DateTime MyDate = new DateTime(2023, 11, 03, 17, 08, 0, 0);
HomeWorkMethods DateMeth = new HomeWorkMethods();

//вызов с помощью традиционного подхода
Console.WriteLine("Traditional calling methods");
DateMeth.Print(MyDate);
DateMeth.PrintDate(MyDate);
DateMeth.PrintTime(MyDate);
DateMeth.PrintWeekDay(MyDate);
Console.WriteLine(DateMeth.SquareTriangle(new Point(0, 0), new Point(0, 50), new Point(10, 10)).ToString());
Console.WriteLine(DateMeth.SquareRectangle(new Point(0, 0), new Point(50, 50)).ToString());



//работа через встроенные делегаты
Console.WriteLine("\n\nCalling methods by delegates");
Action<DateTime> DateAct;
DateAct = DateMeth.Print;
DateAct(MyDate);

DateAct = DateMeth.PrintDate;  //проверка оператора +=
DateAct += DateMeth.PrintTime;
DateAct += DateMeth.PrintWeekDay;
DateAct(MyDate);

Func<Point, Point, Point, double> TriangleFunc = DateMeth.SquareTriangle;
Console.WriteLine(TriangleFunc(new Point(0, 0), new Point(0, 50), new Point(10, 10)).ToString());

Func<Point, Point,  double> RectFunc = DateMeth.SquareRectangle;
Console.WriteLine(RectFunc(new Point(0, 0), new Point(50, 50)).ToString());



public class Point
{
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    public int X { get; set; }
    public int Y { get; set; }
    static public Point operator + (Point P1, Point P2)
    {
        return new Point(P1.X + P2.X, P1.Y + P2.Y);
    }
}
internal class HomeWorkMethods
{

    public void Print (DateTime D)
    {
        Console.WriteLine(D);
    }


    public void PrintDate (DateTime D)
    {
        Console.WriteLine (D.Day.ToString() + "." + D.Month.ToString() + "." + D.Year.ToString());
    }

    public void PrintTime (DateTime D)
    {
        Console.WriteLine(D.Hour.ToString() + ":" + D.Minute.ToString() + ":" + D.Second.ToString());
    }

    public void PrintWeekDay (DateTime D)
    {
        Console.WriteLine(D.DayOfWeek.ToString());
    }

    public double SquareTriangle (Point P1, Point P2, Point P3)
    {
           return 0.5 * System.Math.Abs((P2.X - P1.X) * (P3.Y - P1.Y) - (P3.X - P1.X) * (P2.Y - P1.Y));
    }

    public double SquareRectangle(Point P1, Point P2)
    {
        return System.Math.Abs((P1.X - P2.X) * (P2.Y - P1.Y));

    }
}


