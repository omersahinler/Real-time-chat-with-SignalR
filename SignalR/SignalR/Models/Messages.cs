using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Models
{
    public class Messages
    {
        [Key]
        public int MessageId { get; set; }
        [MaxLength(50)]
        public string Username { get; set; }
        [MaxLength(500)]
        public string MessageText { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
