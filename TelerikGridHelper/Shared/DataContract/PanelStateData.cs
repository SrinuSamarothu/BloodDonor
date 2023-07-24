using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TelerikGridHelper.Shared.DataContract
{
    [DataContract]
    public class PanelStateData
    {
        [Key]
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order =2)]
        public string Status { get; set; }

        [DataMember(Order = 3)]
        public string PersonId { get; set; }
    }
}
