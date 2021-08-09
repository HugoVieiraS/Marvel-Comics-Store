using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MarvelComicsStore.Domain.Entities.Base
{
    [DataContract]
    public abstract class BaseModel
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
    }
}
