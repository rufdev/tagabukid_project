
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangtas.Repository.Pattern.Infrastructure
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState ObjectState { get; set; }
    }
}