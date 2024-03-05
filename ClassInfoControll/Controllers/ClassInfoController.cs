using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TodoApi.Models;

[Route("api/[controller]")]
[ApiController]
public class ClassInfoController : ControllerBase
{
    private static List<ScheduleItems> _classInfoList = new List<ScheduleItems>();

    [HttpGet]
    public IActionResult GetAllClassInfo()
    {
        return Ok(_classInfoList);
    }

    [HttpGet("{id}")]
    public IActionResult GetClassInfoById(int id)
    {
        var classInfo = _classInfoList.Find(c => c.Id == id);
        if (classInfo == null)
        {
            return NotFound();
        }
        return Ok(classInfo);
    }

    [HttpPost]
    public IActionResult CreateClassInfo(ScheduleItems classInfo)
    {
        classInfo.Id = GenerateUniqueId();
        _classInfoList.Add(classInfo);
        return CreatedAtAction(nameof(GetClassInfoById), new { id = classInfo.Id }, classInfo);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateClassInfo(int id, ScheduleItems classInfo)
    {
        var existingClassInfo = _classInfoList.Find(c => c.Id == id);
        if (existingClassInfo == null)
        {
            return NotFound();
        }
        existingClassInfo.FacultyName = classInfo.FacultyName;
        existingClassInfo.ClassTime = classInfo.ClassTime;
        existingClassInfo.GroupNumber = classInfo.GroupNumber;
        existingClassInfo.Subject = classInfo.Subject;
        existingClassInfo.Teacher = classInfo.Teacher;
        existingClassInfo.AlmUsage = classInfo.AlmUsage;
        existingClassInfo.SyllabusAvailability = classInfo.SyllabusAvailability;
        existingClassInfo.StudentAttendance = classInfo.StudentAttendance;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteClassInfo(int id)
    {
        var classInfoToRemove = _classInfoList.Find(c => c.Id == id);
        if (classInfoToRemove == null)
        {
            return NotFound();
        }
        _classInfoList.Remove(classInfoToRemove);
        return NoContent();
    }

    private int GenerateUniqueId()
    {
        
        return new Random().Next(1000, 9999); 
    }
}
