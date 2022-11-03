using AutoMapper;
using Houseseeker.DataAccess.Data;
using Houseseeker.DataAccess.Repository.IRepository;
using Houseseekers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Houseseekers.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns>List of categories</returns>
        [HttpGet(Name = "GetCategories")]
        public IActionResult Get()
        {
            var getAllCategory = _unitOfWork.Category.GetAll();
            var allCategoryDTos = mapper.Map<List<Models.DTOs.CategoryDTO>>(getAllCategory);
            return Ok(allCategoryDTos);
        }

        /// <summary>
        /// Add new category
        /// </summary>
        /// <param>object of category</param>
        /// <returns></returns>
        [HttpPost(Name = "AddCategory")]
        public IActionResult Post(Models.DTOs.CategoryDTO obj)
        {
            try
            {
                var addedCategory = mapper.Map<Models.Category>(obj);
                _unitOfWork.Category.Add(addedCategory);
                _unitOfWork.Save();
            }
            catch (Exception)
            {
                
            }
            return Ok(obj);
        }

        /// <summary>
        /// Update category
        /// </summary>
        /// <param>object of category</param>
        /// <returns></returns>
        [HttpPut(Name = "UpdateCategory")]
        public IActionResult Put(Models.DTOs.CategoryDTO obj)
        {
            try
            {
                var updatedCategory = mapper.Map<Models.Category>(obj);
                _unitOfWork.Category.Update(updatedCategory);
                _unitOfWork.Save();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(obj);
        }

        /// <summary>
        /// Delete category
        /// </summary>
        /// <param>id of category</param>
        /// <returns></returns>
        [HttpDelete(Name = "DeleteCategory")]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                var deletableResource = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);
                if (deletableResource != null)
                {
                    _unitOfWork.Category.Remove(deletableResource);
                    _unitOfWork.Save();
                }
                else
                    return NotFound();
            }
            catch (Exception)
            { 
                throw;
            }
            return Ok(id);
        }
    }
}