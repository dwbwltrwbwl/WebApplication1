using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Фамилия обязательна.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Имя обязательно.")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Электронная почта обязательна.")]
        [EmailAddress(ErrorMessage = "Некорректный формат электронной почты.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Логин обязателен.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Пароль обязателен.")]
        public string Password { get; set; }
        public int IdRole { get; set; }
    }
}
