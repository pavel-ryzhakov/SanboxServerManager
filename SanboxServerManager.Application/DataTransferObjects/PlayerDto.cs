using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanboxServerManager.Application.DataTransferObjects
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public int Level { get; set; }
        public string Clan {  get; set; }
        public string Role { get; set; }
    }
}
