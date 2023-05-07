using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities
{
    public class Mushteri
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Username { get; set; }
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
    }
}
