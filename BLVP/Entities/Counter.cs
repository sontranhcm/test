using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLVP.Entities
{
    [Table("IDCOUNTER", Schema = "TEST_SCHEMA")]
    public class Counter
    {
        [Key]
        [Column("KEY")]
        public string Key { get; set; }
        [Column("NUMBERFORMAT")]
        public string NumberFormat { get; set; }
        [Column("FORMAT")]
        public string Format { get; set; }
        [Column("COUNT")]
        public decimal Count { get; set; }
    }
}
