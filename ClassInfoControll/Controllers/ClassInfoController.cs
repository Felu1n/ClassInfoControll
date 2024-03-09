using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ClassInfoControll.Models;
using ClassInfoControll.Data;

//[Route("")]
[Route("api/[controller]")]
[ApiController]
public class ClassInfoController : ControllerBase
{
    private readonly ScheduleContext _context;

    public ClassInfoController(ScheduleContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAllClassInfo()
    {
        var classInfoList = _context.ScheduleItems.ToList();
        return Ok(classInfoList);
    }

    [HttpGet("{id}")]
    public IActionResult GetClassInfoById(int id)
    {
        var classInfo = _context.ScheduleItems.Find(id);
        if (classInfo == null)
        {
            return NotFound();
        }
        return Ok(classInfo);
    }

    [HttpPost]
    public IActionResult CreateClassInfo(ScheduleItem classInfo)
    {
        _context.ScheduleItems.Add(classInfo);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetClassInfoById), new { id = classInfo.Id }, classInfo);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateClassInfo(int id, ScheduleItem classInfo)
    {
        if (id != classInfo.Id)
        {
            return BadRequest();
        }

        _context.Entry(classInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteClassInfo(int id)
    {
        var classInfoToRemove = _context.ScheduleItems.Find(id);
        if (classInfoToRemove == null)
        {
            return NotFound();
        }
        _context.ScheduleItems.Remove(classInfoToRemove);
        _context.SaveChanges();
        return NoContent();
    }

    private int GenerateUniqueId()
    {
        return new Random().Next(1000, 9999);
    }
}
