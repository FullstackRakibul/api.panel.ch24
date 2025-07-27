using Microsoft.AspNetCore.Identity;

namespace v1.DTOs.AuthDTO
{
    public class RegisterRequestDto
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string EmployeeId { get; set; }
        public string? Region { get; set; }
    }
}
