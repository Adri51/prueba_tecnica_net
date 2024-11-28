using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba_Adrian.Models
{
    public class DataBank
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
     
        public string Name { get; set; }
        public string Bic { get; set; }
        public string Country { get; set; }
    }
}
