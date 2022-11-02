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
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns>List of categories</returns>
        [HttpGet(Name = "GetCategories")]
        public IActionResult Get()
        {
            return Ok(_unitOfWork.Category.GetAll());
        }

        /// <summary>
        /// Add new category
        /// </summary>
        /// <param>object of category</param>
        /// <returns></returns>
        [HttpPost(Name = "AddCategory")]
        public IActionResult Post(Category obj)
        {
            try
            {
                _unitOfWork.Category.Add(obj);
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
        public IActionResult Put(Category obj)
        {
            try
            {
                //var updatableResource = _db.GetFirstOrDefault(x => x.Id == id);
                //if (updatableResource != null)
                //{
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                //}
                //else
                //    return NotFound();
            }
            catch (Exception ex)
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
        public IActionResult Delete(int? id)
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
            catch (Exception ex)
            { 
                throw;
            }
            return Ok(id);
        }
    }
}