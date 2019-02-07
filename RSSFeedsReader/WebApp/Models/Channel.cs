using System.ComponentModel.DataAnnotations;

namespace ConsoleApp.Models
{
    class Channel
    {
        [Key]
        public string Link { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Language { get; set; }
    }
}