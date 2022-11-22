using WebApplication1.Data;

namespace WebApplication1.Models;

public class StatisticModel
{
    public string Category { get; set; }
    public int Maximum { get; set; }
    public int Minimum { get; set; }
    public double Avarage { get; set; }
    public int Total { get; set; }
    

    public void Faculty(UniStatContext db, University uni)
    {
        this.Category = "Faculty";
        var countes = from p in db.Students
            where p.IsActive == true && p.Uni_Id == uni.ShortName
            group p by p.Degree into g
            select new
            {
                count = g.Count()
            }.count;
        this.Total = countes.Sum();
        this.Maximum = countes.Max();
        this.Minimum = countes.Min();
        this.Avarage = countes.Average(x => x);
    }
    public void Course(UniStatContext db, University uni)
    {
        this.Category = "Course";
        var countes = from p in db.Students
            where p.IsActive == true && p.Uni_Id == uni.ShortName
            group p by p.Course into g
            select new
            {
                count = g.Count()
            }.count;
        this.Total = countes.Sum();
        this.Maximum = countes.Max();
        this.Minimum = countes.Min();
        this.Avarage = countes.Average(x => x);
    }

    public void Age(UniStatContext db, University uni)
    {
        this.Category = "Age";
        var countes = from p in db.Students
            where p.IsActive == true && p.Uni_Id == uni.ShortName 
            select new {date = p.Date_Of_Birth}.date;
        List<Int32> ages = new List<int>();
        foreach (var VARIABLE in countes)
        {
            ages.Add(GetAge(VARIABLE));
        }

        this.Maximum = maxAge(ages);
        this.Minimum = minAge(ages);
        this.Avarage = avarageAge(ages);
        this.Total = sumOfAge(ages);

    }
    
    public static Int32 GetAge(String dt)
    {
        DateTime dateOfBirth;
        DateTime.TryParse(dt, out dateOfBirth);
        var today = DateTime.Today;

        var a = (today.Year * 100 + today.Month) * 100 + today.Day;
        var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

        return (a - b) / 10000;
    }
    
    public int maxAge(List<Int32> ages)
    {
        int max = 0;
        foreach (var VARIABLE in ages)
        {
            if (max < VARIABLE) 
            {
                    max = VARIABLE; 
            }
        }

        return max;
    }
    public int minAge(List<Int32> ages)
    {
        int min = 0;
        int i = 0;
        while (min == 0)
        {
            min = ages[0];
            i++;
        }
        foreach (var VARIABLE in ages)
        {
            if (min > VARIABLE) 
            { 
                min = VARIABLE;
            }
        }

        return min;
    }
    public int avarageAge(List<Int32> ages)
    {
        int avg = 0;
        int number = 0;
        foreach (var VARIABLE in ages)
        {
            avg = avg + VARIABLE; 
            number = number + 1;
        }
        avg = avg / number;
        return avg;
    }
    
    public int sumOfAge(List<Int32> ages)
    {
        int sum = 0;
        foreach (var VARIABLE in ages)
        {
            sum = sum + VARIABLE;
        }
        return sum;
    }
    
    
}