namespace Verita.Domain.Entities
{
    public class HakkimizdaTimeLine : BaseEntity
    {
        public string Year { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
