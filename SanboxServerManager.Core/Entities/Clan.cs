using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanboxServerManager.Core.Entities
{
    [Table("clans")]
    public class Clan
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("clan_name")]
        [Required]
        [MaxLength(50)]
        public string ClanName { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
