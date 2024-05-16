using Verita.Common.Enums;

namespace Verita.Domain.Entities
{
    public class MeyveliRehber : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string File { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public MeyveliRehberType MeyveliRehberType { get; set; }
        public DateTime DateOfPublication { get; set; }
        public int SortOrder { get; set; }  
    }
}
