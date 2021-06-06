namespace HeshmastNews.DTOs.User
{
    public class UserListViewModelDTO
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public int? RoleId { get; set; }
        public string RegisterDate { get; set; }
        public bool IsActive { get; set; }
        public string RoleName { get; set; }
    }
}