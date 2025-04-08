namespace final_project.Business.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? FullName { get; internal set; }
        public DateTime CreatedDate { get; set; }
    }
}
