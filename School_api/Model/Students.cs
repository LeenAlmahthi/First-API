using System.ComponentModel.DataAnnotations;

namespace School_api.Model
{
    public class Students
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
