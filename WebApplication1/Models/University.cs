using System.ComponentModel.DataAnnotations;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Models;
public class University 
{
    public int Id { get; set; }
    public string ShortName { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    // public List<Student> Students { get; set; }
    public decimal Longitute { get; set; }
    public decimal Latitude { get; set; }
    public bool IsActive { get; set; } = true;

    public void GetModels(UniStatContext db, out List<University> universities) 
    {
        try
        {
            universities = db.Universities.ToList();
        }
        catch 
        {
            universities = null;
        }
    }

    public List<StatisticModel> Stat(UniStatContext db)
    {
        List<Student> students = db.Students.Where(b => b.Uni_Id == this.ShortName).ToList();

        if (students.Count != 0)
        {
            List<StatisticModel> stat = new List<StatisticModel>();
            StatisticModel fac = new StatisticModel();
            StatisticModel cor = new StatisticModel();
            fac.Faculty(db, this);
            cor.Course(db, this);
            stat.Add(fac);
            stat.Add(cor);
            return stat;
        }

        return null;
    }
}