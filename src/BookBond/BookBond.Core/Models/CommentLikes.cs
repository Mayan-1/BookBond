using BookBond.Core.Common;

namespace BookBond.Core.Models;

public class CommentLikes : BaseModel
{
    public Guid CommentId { get; set; }
    public Guid UserId { get; set; }
}
