using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace MarvelComicsStore.Domain.Entities
{
    [DataContract]
    public abstract class BaseModel
    {
        [DataMember]
        [Key]
        public int Id { get; set; }
    }
}
