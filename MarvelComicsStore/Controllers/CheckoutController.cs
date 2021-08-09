using MarvelComicsStore.Domain.ViewModel;
using MarvelComicsStore.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;


namespace MarvelComicsStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        #region Fields
        private ICheckoutService _checkoutService;
        #endregion

        #region Constructor
        public CheckoutController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult Get()
        {
            var checkouts = _checkoutService.GetAll();
            if (checkouts != null)
            {
                return Ok(checkouts);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == default(decimal))
                return NotFound();

            return Ok(_checkoutService.Get(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CheckoutViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _checkoutService.Insert(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] CheckoutViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _checkoutService.Update(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == default(decimal))
                return NotFound();

            _checkoutService.Remove(id);
            return Ok();
        }
        #endregion
    }
}
