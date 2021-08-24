namespace TestSearch.Models
{
    /// <summary>
    /// Properties for Google search result
    /// </summary>
    public class SearchResultModel
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Snippet { get; set; }
        public string Source { get; set; }
        public string Query { get; set; }
        public int Index { get; set; }
    }
}