using MarvelComicsStore.Domain.Entities;
using MarvelComicsStore.Domain.ViewModel;
using System.Collections.Generic;

namespace MarvelComicsStore.Service.Mapper
{
    public static class ComicsProfileMap
    {
        public static IEnumerable<ComicsViewModel> ComicsToViewModel(Comics comics)
        {
            var comicsViewModel = new List<ComicsViewModel>();
            foreach (var comic in comics.data.results)
            {
                comicsViewModel.Add(
                    new ComicsViewModel
                    {
                        Title = comic.title,
                        Id = comic.id,
                        IssueNumber = comic.issueNumber,
                        VariantDescription = comic.variantDescription,
                        Description = comic.description,
                        DiamondCode = comic.diamondCode,
                        PageCount = comic.pageCount,
                        Prices = comic.prices,
                        Images = comic.images
                    });
            }
            return comicsViewModel;
        }
    }
}
