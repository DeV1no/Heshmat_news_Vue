namespace dadachMovie.DTOs.Category
{
    public class CategoryViewModelDTO
    {
        public int Id { get; set; }
        public string CateGoryName { get; set; }
        public int? ParentId { get; set; }
    }
}