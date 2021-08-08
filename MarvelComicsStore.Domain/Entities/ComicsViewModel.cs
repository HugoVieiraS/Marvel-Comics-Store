using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelComicsStore.Domain.Entities
{
    public class ComicsViewModel
    {
        public virtual int Id { get; set; }
        public string Title { get; set; }
        public  int DigitalId { get; set; }
        public double IssueNumber { get; set; }
        public string VariantDescription { get; set; }
        public string Description { get; set; }
        public DateTime Modified { get; set; }
        public string DiamondCode { get; set; }
        public virtual int PageCount { get; set; }
    }
}
