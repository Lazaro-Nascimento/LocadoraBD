
using Locadora.Data;
using Locadora.Models.Abstracts;
using Locadora.Models.EmployeeRecepcionist;
using Locadora.Services.AbstractsServices;

namespace Locadora.Services;

public class RecepcionistServices : EmployeeServices{

    private readonly LocadoraContext _context;
    public RecepcionistServices(LocadoraContext context){
        _context = context;
    }
    public override void CreateEmployee(Employee employee)
    {
        if(employee != null){
            employee.Id = 0;
            _context.Recepcionists.Add((Recepcionist)employee);
            _context.SaveChanges();
        }
    }
    public override Employee? PutEmployee(int Id, Employee employee)
    {
        if(employee == null){
            return null;
        }

        Recepcionist? rec;
        rec = _context.Recepcionists.SingleOrDefault(rec => rec.Id == Id);
        
        if(rec != null){
            rec.Balance = employee.Balance;
            rec.Name = employee.Name;
            rec.Gender = rec.Gender;
        }
        _context.SaveChanges();

        return rec;
    }
    public override Employee? DeleteEmployee(int Id)
    {
        throw new NotImplementedException();
    }
    public override IEnumerable<Employee> GetAllEmployees()
    {
        List<Employee> employees = [];
        foreach(Employee rec in _context.Recepcionists)
            employees.Add(rec);

        foreach(Employee att in _context.Attendants) 
            employees.Add(att);
        
        return employees;
    }
    public override Employee? GetEmployeeById(int Id)
    {
        throw new NotImplementedException();
    }
    public override Employee? GetEmployeeByName(string Name)
    {
        throw new NotImplementedException();
    }
}