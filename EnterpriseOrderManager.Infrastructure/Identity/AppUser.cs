using Microsoft.AspNetCore.Identity;

namespace EnterpriseOrderManager.Infrastructure.Identity
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
