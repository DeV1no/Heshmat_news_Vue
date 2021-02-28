namespace HeshmastNews.DTOs
{
    public class PaginationDTO
    {
        public int Page { get; set; } = 1;
        private int _recordsPerPage = 10;
        private readonly int _maxRecordsPerPage = 50;

        public int RecordsPerPage
        {
            get
            {
                return _recordsPerPage;
            }
            set
            {
                _recordsPerPage = (value > _maxRecordsPerPage) ? _maxRecordsPerPage : value;
            }
        }
    }
}