namespace MB.Application.Contracts.Article
{
    public class ArticleViewModel
    {
        public long  Id { get; set; }
        public string Title { get; set; }
        public string CategoryName { get; set; }
        public string CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
