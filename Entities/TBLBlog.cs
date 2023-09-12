namespace Entities
{
    public class TBLBlog
    {
        public int id { get; set; }
        public string BlogName { get; set; }
        public string Explanation { get; set; }
        public string Images { get; set; }
        public int CategoriesId { get; set; }
        public TBLCategories TBLCategories { get; set; }
    }
}
