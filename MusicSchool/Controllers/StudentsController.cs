﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Contexts;
using DataAccess.Entities;
using Business.Services;
using Business.Models;
using AppCore.Results.Bases;

//Generated by ScaffoldApp.
namespace MusicSchool.Controllers
{
	public class StudentsController : Controller
	{
		// Add service injections here
		private readonly IStudentService _studentService;

		public StudentsController(IStudentService studentService)
		{
			_studentService = studentService;
		}

		// GET: Students
		public IActionResult Index()
		{
			var students = _studentService.Query().ToList();
			return View(students);
		}

		// GET: Students/Details/5
		public IActionResult Details(int id)
		{
			StudentModel student = _studentService.Query().SingleOrDefault(s => s.Id == id);  // TODO: Add get item service logic here
			if (student is null)
			{
				return NotFound();
			}
			return View(student);
		}

		// GET: Students/Create
		public IActionResult Create()
		{
			StudentModel model = new StudentModel();
			
			return View(model);
		}

		// POST: Students/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(StudentModel student)
		{
			if (ModelState.IsValid)
			{
				Result result = _studentService.Add(student);
				if (result.IsSuccessful)
				{
					TempData["Message"] = result.Message;
					return RedirectToAction(nameof(Index));
				}
				ViewData["Message"]=result.Message;
			}
			// Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
			return View(student);
		}

		// GET: Students/Edit/5
		public IActionResult Edit(int id)
		{
			var student = _studentService.Query().SingleOrDefault(s => s.Id == id);
            if (student is null)
            {
                return NotFound();
            }

            return View(student);
        }

		// POST: Students/Edit
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(StudentModel student)
		{
			if (ModelState.IsValid)
			{
                var result=_studentService.Update(student);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message; // success
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.Message); // error
            }
			// Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
			return View(student);
		}

		// GET: Students/Delete/5
		 public IActionResult Delete(int id)
		{

			StudentModel student = _studentService.Query().SingleOrDefault(s => s.Id == id); 
			if (student is null)
			{
				return NotFound();
			}

			return View(student);
		}

		// POST: Students/Delete
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			Result result =_studentService.Delete(id);
			TempData["Message"] = result.Message;
			return RedirectToAction(nameof(Index));
		}
	}
}
