
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
        char gen = char.ToUpper(employee.Gender);
        employee.Gender = char.ToUpper(employee.Gender);

        if(employee != null){

            if(employee.Balance > 1000 && !String.IsNullOrWhiteSpace(employee.Name) && ((gen == 'F') || (gen == 'M')))
            {
                employee.Id = 0;
                _context.Recepcionists.Add((Recepcionist)employee);
                _context.SaveChanges();
            }
        }
    }
    public override Employee? PutEmployee(int Id, Employee employee)
    {
        char gen = char.ToUpper(employee.Gender);
        employee.Gender = char.ToUpper(employee.Gender);

        if(employee == null){
            return null;
        }

        Recepcionist? rec = _context.Recepcionists.SingleOrDefault(A => A.Id == Id);

        if(rec != null){
            
            if(employee.Balance < 1000 && String.IsNullOrWhiteSpace(employee.Name) && (gen != 'F') && (gen != 'M'))
            {
                return null;
            }

            rec.Balance = employee.Balance;
            rec.Name = employee.Name;
            rec.Gender = char.ToUpper(employee.Gender);

            _context.SaveChanges();
        }

        return rec;
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
    public override Employee? DeleteEmployee(int Id)
    {
        throw new NotImplementedException();
    }
}