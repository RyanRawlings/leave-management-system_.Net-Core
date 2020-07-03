using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using investment_management_system.Contracts;
using investment_management_system.Data;
using investment_management_system.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace investment_management_system.Controllers
{
    public class LeaveTypesController : Controller
    {
        //underscore is private variable convention
        private readonly ILeaveTypeRepository _repo;
        private readonly IMapper _mapper;

        public LeaveTypesController(ILeaveTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: LeaveTypes
        public ActionResult Index()
        {
            //Retrieves all objects of type LeaveType
            var leaveTypes = _repo.FindAll().ToList();
            //Represents the mapped version of the data>
            //Maps must be consistent cannot have cross data types
            var model = _mapper.Map<List<LeaveType>, List<LeaveTypeVM>>(leaveTypes);
            //The view will have access to the data available
            return View(model);
        }

        // GET: LeaveTypes/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var leaveType = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeVM>(leaveType);
            return View(model);
        }

        // GET: LeaveTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeVM model)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                //Mapper convert the LeaveTypeVM model in type LeaveType
                var leaveType = _mapper.Map<LeaveType>(model);
                leaveType.DateCreated = DateTime.Now;

                var isSuccessful = _repo.Create(leaveType);
                if (!isSuccessful)
                {
                    //Raiserror if unsuccessful
                    ModelState.AddModelError("", "Something went wrong with the operation...");
                    //Also return the page with the data
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveTypes/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                // will return a 404 error for the user if not found
                return NotFound();
            }
            var leaveType = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeVM>(leaveType);
            return View(model);
        }

        // POST: LeaveTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypeVM model)
        {
            try
            {
                // TODO: Add update logic here

                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var leaveType = _mapper.Map<LeaveType>(model);
                var isSuccessful = _repo.Update(leaveType);
                
                if (!isSuccessful)
                {
                    ModelState.AddModelError("", "Something went wrong in the conversion process...");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong in the conversion process...");
                return View(model);
            }
        }

        // GET: LeaveTypes/Delete/5
        public ActionResult Delete(int id)
        {
            // For now hard delete
            if (!_repo.isExists(id))
            {
                return NotFound();
            }

            var leavetype = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeVM>(leavetype);
            return View(model);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(LeaveTypeVM model, int id)
        {
            try
            {
                // TODO: Add delete logic here
                var leavetype = _repo.FindById(id);

                if (leavetype == null)
                {
                    return NotFound();
                }
                var isSuccessful = _repo.Delete(leavetype);

                if (!isSuccessful)
                {
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}