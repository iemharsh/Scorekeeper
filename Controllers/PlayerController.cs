using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Data;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Details(int id)
        {
            var model = _context.Players.Include(e => e.Scores).FirstOrDefault(e => e.Id == id);
            return View(model);
        }

        public IActionResult AddScore(int id, int value) 
        {
            _context.Players.Include(e => e.Scores).FirstOrDefault(e => e.Id == id).Scores.Add(new Score{ Value = value});
            _context.SaveChanges();
            return RedirectToAction("Details", "Player", new {Id = id});
        }

    }
}