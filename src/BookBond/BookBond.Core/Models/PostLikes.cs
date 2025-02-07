using BookBond.Core.Common;

namespace BookBond.Core.Models;

public class PostLikes : BaseModel
{
    public Guid UserId { get; set; }
    public Guid PostId { get; set; }
}
