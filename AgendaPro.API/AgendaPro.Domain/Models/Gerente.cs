using Microsoft.AspNetCore.Identity;

namespace AgendaPro.Domain.Entities
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; } = string.Empty;
    }
}