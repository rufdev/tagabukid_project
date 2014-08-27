using System.ComponentModel.DataAnnotations.Schema;
using BIPS.Repository.Pattern.Infrastructure;

namespace BIPS.Repository.Pattern.EF
{
    public abstract class Entity : IObjectState
    {
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}