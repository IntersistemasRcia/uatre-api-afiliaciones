
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Commom
{
    public abstract class BaseDomainModel
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        [StringLength(50)]
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        [StringLength(50)]
        public string? LastModifiedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        [StringLength(50)]
        public string? DeletedBy { get; set; }
        [StringLength(1000)]
        public string? DeletedObs { get; set; }
    }
}
