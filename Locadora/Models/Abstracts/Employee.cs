namespace Locadora.Models.Abstracts;

public abstract class Employee{
    public int Id { get; set; } = 100001;
    public string Name { get; set; }
    public double Balance { get; set; }
    public char Gender { get; set; }

    public Employee(string Name, double Balance, char Gender) {
        this.Name = Name;
        this.Balance = Balance;
        this.Gender = Gender;
    }
}