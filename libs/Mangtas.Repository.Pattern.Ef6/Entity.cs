using System.ComponentModel.DataAnnotations.Schema;
using Mangtas.Repository.Pattern.Infrastructure;

namespace Mangtas.Repository.Pattern.EF
{
    public abstract class Entity : IObjectState
    {
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}