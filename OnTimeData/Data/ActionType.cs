using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeServer
{
    public partial class ActionType
    {
        [Key]
        [Column("ActionTypeID")]
        public int ActionTypeId { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
