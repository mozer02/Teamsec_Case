using System;
using System.ComponentModel.DataAnnotations;

namespace Teamsec_Case.Core
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
