using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanboxServerManager.Core.Entities
{
    [Table("players")]
    public class Player
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("nickname")]
        [Required]
        [MaxLength(50)]
        public string NickName { get; set; }
        [Column("level")]
        public int Level { get; set; }
        [Column("role_id")]
        public int RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public PlayerRole PlayerRole { get; set; }
        [Column("clan_id")]
        public int ClanId { get; set; }
        [ForeignKey(nameof(ClanId))]

        public Clan Clan { get; set; }

    }
}
