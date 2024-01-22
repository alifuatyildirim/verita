namespace Verita.Repository.Mssql
{
    public class Specification<T> : SpecificationBase<T>
        where T : class
    {
        public int? Skip { get; set; }

        public int? Take { get; set; }
    }
}