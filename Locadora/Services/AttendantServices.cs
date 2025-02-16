using Locadora.Data;
using Locadora.Models.Abstracts;
using Locadora.Services.AbstractsServices;
using Locadora.Models.EmployeeAttendant;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Dynamic;
namespace Locadora.Services;

public class AttendantServices : EmployeeServices{

    private readonly LocadoraContext _context;
    public AttendantServices(LocadoraContext context){
        _context = context;
    }

    public override void CreateEmployee(Employee employee)
    {
        char gen = char.ToUpper(employee.Gender);
        employee.Gender = char.ToUpper(employee.Gender);

        if(employee.Balance > 1000 && !String.IsNullOrWhiteSpace(employee.Name) && (gen == 'F') || (gen == 'M'))
        {
            employee.Id = 0;
            _context.Attendants.Add((Attendant)employee);
            _context.SaveChanges();
        }
    }
    public override Employee? PutEmployee(int Id, Employee employee)
    {
        char gen = char.ToUpper(employee.Gender);
        employee.Gender = char.ToUpper(employee.Gender);

        if(employee == null){
            return null;
        }

        Attendant? att = _context.Attendants.SingleOrDefault(A => A.Id == Id);

        if(att != null){
            
            if(employee.Balance < 1000 && String.IsNullOrWhiteSpace(employee.Name) && (gen != 'F') && (gen != 'M'))
            {
                return null;
            }

            att.Balance = employee.Balance;
            att.Name = employee.Name;
            att.Gender = char.ToUpper(employee.Gender);

            _context.SaveChanges();
        }

        return att;
    }
    public override Employee? DeleteEmployee(int Id)
    {
        throw new NotImplementedException();
    }
    public override Employee? GetEmployeeById(int Id)
    {
        throw new NotImplementedException();
    }
    public override Employee? GetEmployeeByName(string Name)
    {
        throw new NotImplementedException();
    }
    public override IEnumerable<Employee> GetAllEmployees()
    {
        throw new NotImplementedException();
    }
}