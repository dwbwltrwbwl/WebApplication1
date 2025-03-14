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
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;


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
                password = model.Password,
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
        var user = await _context.users.FirstOrDefaultAsync(u => u.login == login && u.password == password);
        if (user != null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.login),
                new Claim(ClaimTypes.Role, user.idRole.ToString())
            };
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
            };
            await HttpContext.SignInAsync(
                "YourAppCookie",
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return RedirectToAction("Index", "Users");
        }
        ModelState.AddModelError("", "Неверный логин или пароль");
        return View();
    }
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("YourAppCookie");
        return RedirectToAction("Index", "Home");
    }
    public IActionResult Layout()
    {
        return View();
    }
}

