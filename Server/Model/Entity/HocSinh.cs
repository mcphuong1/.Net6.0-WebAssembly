using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tesing2.Server.Model.Entity
{
    public class HocSinh
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Phone { get; set; }
    }
}
