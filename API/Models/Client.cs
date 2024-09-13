using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    [Index("Email", IsUnique = true)]
    public class Client
    {
        //PrimaryKey
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";
        public string Status { get; set; } = "";
        public DateTime CreateAt { get; set; }

    }
}
