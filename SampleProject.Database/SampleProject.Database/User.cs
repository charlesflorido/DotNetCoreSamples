using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SampleProject.Database
{
    public partial class User
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(256)]
        public string FirstName { get; set; } = null!;
        [StringLength(256)]
        public string LastName { get; set; } = null!;
        [StringLength(256)]
        [Unicode(false)]
        public string Email { get; set; } = null!;
        [StringLength(256)]
        public string? AddressLine { get; set; }
        [StringLength(128)]
        public string? City { get; set; }
        [StringLength(128)]
        public string? State { get; set; }
        [StringLength(16)]
        public string? Zip { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateOfBirth { get; set; }
        public int? CreditScore { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedTimestamp { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedTimestamp { get; set; }
    }
}
