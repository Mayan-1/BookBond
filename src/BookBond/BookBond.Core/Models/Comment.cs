using BookBond.Core.Common;

namespace BookBond.Core.Models;

public class Comment : BaseModel
{
    public string Content { get; set; } = string.Empty;
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }


}
