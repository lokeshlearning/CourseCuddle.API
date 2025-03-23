

namespace CourseCuddle.Application.DTOs
{


    public class InstructorDTO
    {
        public int InstructorId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Bio { get; set; }

        public int UserId { get; set; }
    }
    public class CourseDetailDTO : CourseDTO
    {
        public List<UserReviewDTO>? Reviews { get; set; } = new List<UserReviewDTO>();
        public required List<SessionDetailDTO> SessionDetails { get; set; }
    }
    public class CourseDTO
    {
        public int CourseId { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string CourseType { get; set; } = null!;

        public int? SeatsAvailable { get; set; }

        public decimal Duration { get; set; }

        public int CategoryId { get; set; }

        public int InstructorId { get; set; }
        public int InstructorUserId { get; set; }
        public string? Thumbnail { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public CourseCategoryDTO? Category { get; set; } = null!;
        public UserRatingDTO? UserRating { get; set; } = null!;

    }

    public class UserReviewDTO
    {
        public int ReviewId { get; set; }
        public int CourseId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;

        public int Rating { get; set; }

        public string? Comments { get; set; }

        public DateTime ReviewDate { get; set; }
    }

    public class SessionDetailDTO
    {
        public int SessionId { get; set; }

        public int CourseId { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public string? VideoUrl { get; set; }

        public int VideoOrder { get; set; }

    }
    public class UserRatingDTO
    {
        public int CourseId { get; set; }

        public decimal AverageRating { get; set; }

        public int TotalRating { get; set; }
    }
}
