using Microsoft.AspNetCore.Identity;

namespace HeshmastNews.Entities
{
    public class Role:IdentityRole<int>
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}