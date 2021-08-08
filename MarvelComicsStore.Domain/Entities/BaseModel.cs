using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MarvelComicsStore.Domain.Entities
{
    [DataContract]
    public abstract class BaseModel
    {
        [DataMember]
        public int Id { get; set; }
    }
}
