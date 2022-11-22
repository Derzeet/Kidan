using System.ComponentModel.DataAnnotations;
using System.Web;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication1.Models;

public class Image
{
    [DataType(DataType.Upload)]    
    [Display(Name = "Upload File")]  
    public int Id { get; set; }
    public string Path { get; set; }
}