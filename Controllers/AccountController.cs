using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Account/Register
    public IActionResult Register()
    {
        ViewData["idRole"] = new SelectList(_context.roles, "idRole", "role");
        return View();
    }

    // POST: Account/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new User
            {
                lastName = model.LastName,
                firstName = model.FirstName,
                middleName = model.MiddleName,
                email = model.Email,
                login = model.Login,
                password = model.Password, // Не забудьте хешировать пароль!
                idRole = 2
            };

            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Users");
        }

        ViewData["idRole"] = new SelectList(_context.roles, "idRole", "role", model.IdRole);
        return View(model);
    }

    // GET: Account/Login
    public IActionResult Login()
    {
        return View();
    }

    // POST: Account/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(string login, string password)
    {
        var user = await _context.users.FirstOrDefaultAsync(u => u.login == login && u.password == password); // Не забудьте хешировать пароль!

        if (user != null)
        {
            // Здесь вы можете установить куки или сессию для аутентификации
            return RedirectToAction("Index", "Users");
        }

        ModelState.AddModelError("", "Неверный логин или пароль");
        return View();
    }

    // GET: Account/Logout
    public IActionResult Logout()
    {
        // Здесь вы можете удалить куки или сессию
        return RedirectToAction("Index", "Home");
    }
}
