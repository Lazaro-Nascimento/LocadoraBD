using Locadora.Models.Abstracts;
namespace Locadora.Models.EmployeeAttendant;

public class Attendant : Employee{
    public Attendant(string name, double balance, char gender) : base(name, balance, gender){}
}