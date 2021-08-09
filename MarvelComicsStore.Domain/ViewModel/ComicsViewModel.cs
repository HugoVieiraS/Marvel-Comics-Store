using MarvelComicsStore.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MarvelComicsStore.Domain.ViewModel
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
        public int PageCount { get; set; }
        public bool Rare { get; set; }
        public List<Price> Prices { get; set; }
        public List<Image> Images { get; set; }
    }
}
