using HandPass.Business.Abstraction;
using HandPass.Business.Constants;
using HandPass.Core.Utilities.Results;
using HandPass.Entities.Entitiy;
using Microsoft.AspNetCore.Mvc;

namespace HandPass.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetList()
        {
            var result = _categoryService.GetList();
            if (result.Success)
            {

                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("CreateCategory")]
        public IActionResult CreateCategory(Category model)
        {
            _categoryService.Add(model);
            return Ok();
        }
    }
}
