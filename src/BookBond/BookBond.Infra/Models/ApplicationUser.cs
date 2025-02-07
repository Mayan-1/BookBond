using Microsoft.AspNetCore.Identity;

namespace BookBond.Infra.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public DateTime BirthDate { get; set; }
    public string Bio { get; set; } = string.Empty;
    public string ProfilePhoto { get; set; } = string.Empty;
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset DateUpdated { get; set; }
    public DateTimeOffset DateDeleted { get; set; }
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime RefreshTokenExpiryTime { get; set; }
}
