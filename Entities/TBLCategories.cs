namespace Entities
{
    public class TBLCategories
    {
        public int id { get; set; }
        public string CategoryName { get; set; }
        public IList<TBLBlog> TBLBlog { get; set; }
    }
}
