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
    
}