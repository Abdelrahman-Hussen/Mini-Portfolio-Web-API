namespace Portfolio.Common.Objects
{
    public class RequestModel
    {
        public string? Search { get; set; }
        public bool ApplyPagination { get; set; } = false;
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
