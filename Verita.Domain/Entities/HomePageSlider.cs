using Verita.Common.Enums;

namespace Verita.Domain.Entities
{
    public class HomePageSlider : BaseEntity
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int SortOrder { get; set; }
        public HomePageSliderButtonType HomePageSliderType { get; set; } = HomePageSliderButtonType.DahaFazla;
    }
}
