using BookBond.Core.Common;

namespace BookBond.Core.Models;

public class Post : BaseModel
{
    public Guid UserId { get; set; }
    public string Content { get; set; } = string.Empty;
    public string Photo { get; set; } = string.Empty;
}
