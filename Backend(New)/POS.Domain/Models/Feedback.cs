namespace POS.Domain.Models;

public class Feedback
{
    public const int MAX_COMMENT_LENGTH = 500;
    public const int MIN_RATING = 0;
    public const int MAX_RATING = 5;

    private Feedback(Guid id, string comment, int rating)
    {
        Id = id;
        Comment = comment;
        Rating = rating;
    }
        
    public Guid Id { get; }
    public string Comment { get; }
    public int Rating { get; } 
        
    public static (Feedback Feedback, string Errors) Create(Guid id, string comment, int rating)
    {
        var errors = new List<string>
            {
                string.IsNullOrWhiteSpace(comment) ? "Comment cannot be empty" : null,
                comment.Length > MAX_COMMENT_LENGTH ? $"Comment length must not exceed {MAX_COMMENT_LENGTH} characters" : null,
                (rating < MIN_RATING || rating > MAX_RATING) ? $"Rating must be between {MIN_RATING} and {MAX_RATING}" : null
            }
            .Where(e => e != null)
            .ToList();

        var feedback = new Feedback(id, comment, rating);
        return (feedback, errors.Count > 0 ? string.Join("\n", errors) : string.Empty);
    }
}