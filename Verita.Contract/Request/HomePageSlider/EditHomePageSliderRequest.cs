﻿using Microsoft.AspNetCore.Http;
using Verita.Common.Enums;

namespace Verita.Contract.Request.Category
{
    public class EditHomePageSliderRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }                   = string.Empty;
        public string Description { get; set; }            = string.Empty;
        public string Link { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public IFormFile? MainImage { get; set; }
        public string MainImageUrl { get; set; } = string.Empty;
        public HomePageSliderButtonType HomePageSliderButtonType { get; set; }
    }
}
