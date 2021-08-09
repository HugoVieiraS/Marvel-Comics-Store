using MarvelComicsStore.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;


namespace MarvelComicsStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicsController : ControllerBase
    {
        #region Fields
        private IComicsService _comicsService;
        #endregion

        #region Constructor
        public ComicsController(IComicsService comicsService)
        {
            _comicsService = comicsService;
        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_comicsService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id == default(int))
                    return NotFound();

                return Ok(_comicsService.Get(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
