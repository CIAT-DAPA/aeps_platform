using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("aspnetusers", Schema = "aeps_2_0")]
    public partial class Aspnetusers
    {
        public Aspnetusers()
        {
            Aspnetuserclaims = new HashSet<Aspnetuserclaims>();
            Aspnetuserlogins = new HashSet<Aspnetuserlogins>();
            Aspnetuserroles = new HashSet<Aspnetuserroles>();
        }

        [StringLength(128)]
        public string Id { get; set; }
        [StringLength(256)]
        public string Email { get; set; }
        [Column(TypeName = "tinyint(1)")]
        public byte EmailConfirmed { get; set; }
        [Column(TypeName = "longtext")]
        public string PasswordHash { get; set; }
        [Column(TypeName = "longtext")]
        public string SecurityStamp { get; set; }
        [Column(TypeName = "longtext")]
        public string PhoneNumber { get; set; }
        [Column(TypeName = "tinyint(1)")]
        public byte PhoneNumberConfirmed { get; set; }
        [Column(TypeName = "tinyint(1)")]
        public byte TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        [Column(TypeName = "tinyint(1)")]
        public byte LockoutEnabled { get; set; }
        [Column(TypeName = "int(11)")]
        public int AccessFailedCount { get; set; }
        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Aspnetuserclaims> Aspnetuserclaims { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Aspnetuserlogins> Aspnetuserlogins { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Aspnetuserroles> Aspnetuserroles { get; set; }
    }
}
