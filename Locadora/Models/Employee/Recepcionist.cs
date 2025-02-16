using Locadora.Models.Abstracts;

namespace Locadora.Models.EmployeeRecepcionist;

public class Recepcionist : Employee{
    public Recepcionist(string Name, double Balance, char Gender) : base(Name, Balance, Gender){}
}