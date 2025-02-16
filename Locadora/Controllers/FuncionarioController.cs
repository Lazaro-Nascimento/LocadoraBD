using System.Data.Common;
using Locadora.Data;
using Locadora.Models;
using Locadora.Models.Abstracts;
using Locadora.Models.EmployeeAttendant;
using Locadora.Models.EmployeeRecepcionist;
using Locadora.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Controllers;
[ApiController]
[Route("[controller]")]
public class FuncionarioController : ControllerBase{
    private readonly AttendantServices _attendantServices;
    private readonly RecepcionistServices _recepcionistServices;

    public FuncionarioController(AttendantServices attendantServices, RecepcionistServices recepcionistServices)
    {
        _attendantServices = attendantServices;
        _recepcionistServices = recepcionistServices;
    }

    [HttpGet("GetAllEmployees")]
    public ActionResult<List<Employee>> GetAllEmployees()
    {
        var getEmployee = (List<Employee>)_recepcionistServices.GetAllEmployees();

        if(getEmployee != null)
            return Ok(getEmployee);
        
        return BadRequest("Nenhum funcionário cadastrado!");
    }

    [HttpPost("CreateRecepcionist")]
    public IActionResult CreateRecepcionist(Recepcionist recepcionist) 
    {
        _recepcionistServices.CreateEmployee(recepcionist);
        
        return Ok();
    }

    [HttpPost("CreateAttendant")]
    public IActionResult CreateAttendant(Attendant attendant)
    {
        _attendantServices.CreateEmployee(attendant);

        return Ok();
    }

    [HttpPut("PutRecepcionist")]
    public ActionResult<Recepcionist> PutRecepcionist(int id, Recepcionist recUpdate){

        Recepcionist? rec = _recepcionistServices.PutEmployee(id, recUpdate) as Recepcionist;
        
        if(rec != null)
        {
            return Ok(rec);
        }
        else
            return BadRequest("Não existe recepcionista com este Id!");
    }

    [HttpPut("PutAttendant")]
    public ActionResult<Attendant> PutAttendant(int id, Attendant attupdate)
    {
        Attendant? att = _attendantServices.PutEmployee(id, attupdate) as Attendant;

        if(att != null)
        {
            return Ok(att);
        }
        else
            return BadRequest("Não existe atendente com este Id!");
    }
}