using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models;

public class Student 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Course { get; set; }
    public string Degree { get; set; }
    public string Date_Of_Birth { get; set; }
    public string Uni_Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; } = true;

    public void SetModel(string name, string surname, int course, string degree, string dateTime, string uni,
        string login, string password)
    {
        this.Name = name;
        this.Surname = surname;
        this.Course = course;
        this.Degree = degree;
        this.Date_Of_Birth = dateTime;
        this.Uni_Id = uni;
        this.Login = login;
        this.Password = password;
    }

    public void DropModel()
    {
        this.IsActive = false;
    }
}