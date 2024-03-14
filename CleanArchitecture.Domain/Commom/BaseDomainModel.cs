
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Commom
{
    public abstract class BaseDomainModel
    {
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid? Guid { get; set; }
    }
}
