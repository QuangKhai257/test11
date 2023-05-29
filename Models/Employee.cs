using System.ComponentModel.DataAnnotations;
namespace Test11.Models;
public class Employee 

{
    [Key]
    public string EmployeeID {get; set;}
    public string EmployeeName {get; set;}
    public string Add {get; set;}

}
