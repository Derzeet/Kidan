using System.ComponentModel.DataAnnotations;
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
}