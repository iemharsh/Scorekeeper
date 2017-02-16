using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Data;

namespace WebApplication.Controllers 
{ 
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayerController(ApplicationDbContext context) 
        {
            _context = context;
        }
        public IActionResult Index() 
        {
            var model = _context.Players.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Player player) 
        {
            _context.Players.Add(player);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}