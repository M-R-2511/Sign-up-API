namespace Sign_up_Form.Models
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Type { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedAt { get; }
    }
}
