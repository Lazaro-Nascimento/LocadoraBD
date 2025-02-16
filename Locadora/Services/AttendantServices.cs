using Locadora.Data;
using Locadora.Models.Abstracts;
using Locadora.Services.AbstractsServices;
using Locadora.Models.EmployeeAttendant;
namespace Locadora.Services;

public class AttendantServices : EmployeeServices{

    private readonly LocadoraContext _context;
    public AttendantServices(LocadoraContext context){
        _context = context;
    }

    public override void CreateEmployee(Employee employee)
    {
        if(employee != null){
            employee.Id = 0;
            _context.Attendants.Add((Attendant)employee);
            _context.SaveChanges();
        }
    }
    public override Employee? PutEmployee(int Id, Employee employee)
    {
        if(employee == null){
            return null;
        }
        Attendant? att = _context.Attendants.SingleOrDefault(A => A.Id == Id);
        if(att != null){
            att.Balance = employee.Balance;
            att.Name = employee.Name;
            att.Gender = employee.Gender;
        }
        _context.SaveChanges();
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