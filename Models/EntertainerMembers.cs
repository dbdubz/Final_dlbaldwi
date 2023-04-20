using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Final_dlbaldwi.Models
{
    public partial class EntertainerMembers
    {

        [Key]
        public long? EntertainerId { get; set; }
        public long? MemberId { get; set; }
        public long? Status { get; set; }
    }
}
