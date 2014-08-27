
using System.ComponentModel.DataAnnotations.Schema;

namespace BIPS.Repository.Pattern.Infrastructure
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState ObjectState { get; set; }
    }
}