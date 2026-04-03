using Shared.DTOs.ResponseDTOs.ClassificationDTOs;
using Shared.DTOs.ResponseDTOs.FilterDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.ResponseDTOs.Snippet
{
    public class SnippetResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }

        public CategoryDto Category { get; set; }
        public LanguageDto Language { get; set; }
        public List<TagDto> Tags { get; set; }
    }
}
