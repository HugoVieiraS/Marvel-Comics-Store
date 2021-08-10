using MarvelComicsStore.Domain.Interface;
using MarvelComicsStore.Domain.ViewModel;
using MarvelComicsStore.Service.Interface;
using MarvelComicsStore.Service.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarvelComicsStore.Service.Services
{
    public class ComicsService : IComicsService
    {
        #region Constants
        private const string MESSAGE_ERROR = "This action is not allowed.";
        private const string MESSAGE_ERROR_DUPLICATES_RECORDS = "More than one record was found for this Id.";
        #endregion

        #region Propeties
        private readonly IComicsRepository _comicsRepository;
        #endregion

        #region Constructor
        public ComicsService(IComicsRepository comicsRepository)
        {
            _comicsRepository = comicsRepository;
        }
        #endregion

        #region Methods
        public ComicsViewModel Get(int id)
        {
            var comicsToViewModel = (List<ComicsViewModel>)ComicsProfileMap.ComicsToViewModel(_comicsRepository.Get(id));
            if (comicsToViewModel.Count > 1)
                throw new Exception(MESSAGE_ERROR_DUPLICATES_RECORDS);

            return comicsToViewModel.FirstOrDefault();
        }

        public IEnumerable<ComicsViewModel> GetAll()
        {
            return ComicsProfileMap.ComicsToViewModel(_comicsRepository.GetAll());
        }

        public void Insert(ComicsViewModel model)
        {
            throw new NotImplementedException(MESSAGE_ERROR);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException(MESSAGE_ERROR);
        }

        public void Update(ComicsViewModel model)
        {
            throw new NotImplementedException(MESSAGE_ERROR);
        }
        #endregion;

        #region Private Methods
        private static void GetRareComics(IEnumerable<ComicsViewModel> comics)
        {
            var countRareComics = decimal.ToInt16(comics.Count() * 0.1m);
            Random random = new Random();
            var comicsRare = comics.OrderBy(x => random.Next()).Take(countRareComics);
        }
        #endregion
    }
}
