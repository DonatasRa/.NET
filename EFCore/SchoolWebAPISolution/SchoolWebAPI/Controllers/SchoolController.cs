﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolWebAPI.Data;
using SchoolWebAPI.Dtos;
using SchoolWebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace SchoolWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;


        public SchoolController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        [HttpGet]
        public List<SchoolDto> GetAll()
        {
            List<SchoolDto> schools = _mapper.Map<List<SchoolDto>>(_dataContext.Schools.ToList());
            return schools;
        }

        [HttpGet("{id}")]
        public SchoolDto GetById(int id)
        {
            var school = _mapper.Map<SchoolDto>(_dataContext.Schools.Find(id));
            return school;
        }

        [HttpPost]
        public IActionResult Create(SchoolDto school)
        {
            var newSchool = new School()
            {
                Name = school.Name,
                Created = school.Created
            };
            _dataContext.Add(newSchool);
            _dataContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, SchoolDto schoolUpdate)
        {
            var school = _dataContext.Schools.Find(id);

            school.Name = schoolUpdate.Name;
            school.Created = schoolUpdate.Created;

            _dataContext.SaveChanges();
            return Ok("Record updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var school = _dataContext.Schools.Find(id);
            _dataContext.Remove(school);
            _dataContext.SaveChanges();
            return Ok("Record Deleted");
        }
    }

}
