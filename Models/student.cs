using System.ComponentModel.DataAnnotations;
namespace TEST1.Models;
public class student
{
    [Key]
    public string studentID {get; set;}
    public string studentName {get; set;}
    public string Address {get; set;}
}