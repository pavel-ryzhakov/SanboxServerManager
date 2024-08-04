using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanboxServerManager.Core.Entities
{
    [Table("roles")]
    public class PlayerRole
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("role_name")]
        [Required]
        [MaxLength(50)]
        public string RoleName { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
