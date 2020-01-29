using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OneDAT.Helper.Enumerations;
using OneDAT.Helper.Exception;
using OneDAT.Helper.Models;
using OneDAT.Menu.Common.ViewModel;
using OneDAT.Menu.Interfaces.IServices;
using OneDAT.Menu.Interfaces.IViewModel;
using Serilog.Core;

namespace OneDAT.Menu.Web.Controllers
{
    /// <summary>
    /// Technology Controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : BaseApiController<TechnologyController, ITechnologyService>
    {
        public TechnologyController(IOptions<AppInformation> appInformation, ILogger<TechnologyController> logger, ITechnologyService technologyService) : base(appInformation, logger, technologyService)
        {
        }

        /// <summary>
        /// Get list of Technologies
        /// </summary>
        /// <remarks>
        /// Get All technology from Database
        /// </remarks>
        /// <returns>Technology list</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                Logger.LogInformation("Hello One DAT");
                var data = await Service.GetAll();
                return Ok(new OneDATApiResponse("Get all records", data));
            }
            catch (OneDATException ex)
            {
                return BadRequest(new OneDATApiResponse(ex.Message, false));
            }
            catch (Exception ex)
            {
                return ServerError("Error Getting Records in technologies", false, ex);
            }
        }
       
        /// <summary>
        /// Get specific Technology by Id
        /// </summary>
        /// <remarks>
        /// Get specific Technology by Id
        /// </remarks>
        /// <returns>Technology list</returns>
        /// <param name="id">Id used to filter the technology</param>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                Logger.LogInformation("Hello One DAT");
                var data = await Service.Get(id);
                return Ok(new OneDATApiResponse("Get all records", data));
            }
            catch (OneDATException ex)
            {
                if (ex.Code == OneDATExceptionCode.NotFound)
                {
                    return NotFound(new OneDATApiResponse("Data not found", false));
                }
                else return BadRequest(new OneDATApiResponse(ex.Message, false));
            }
            catch (Exception ex)
            {
                return ServerError("Error Getting Records in technology", false, ex);
            }
        }

        /// <summary>
        /// Add new Technology
        /// </summary>
        /// <remarks>
        /// Code, ColorCode and Name properties are mandatory
        /// </remarks>
        /// <param name="technology"> Technology Object </param>
        /// <returns>After Add Technology, returns complete technology object </returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ITechnologyViewModel technology)
        {
            try
            {
                var data = await Service.Add(technology);
                return Ok(new OneDATApiResponse("Inserted Successfully", data));
            }
            catch (OneDATException ex)
            {
                if (ex.Code == OneDATExceptionCode.AlreadyExists)
                {
                    return Conflict(new OneDATApiResponse("Data AlreadyExists", false));
                }
                else return BadRequest(new OneDATApiResponse(ex.Message, false));
            }
            catch (Exception ex)
            {
                return ServerError("Error Adding Records in technology", false, ex);
            }
        }

        /// <summary>
        /// Update Technology
        /// </summary>
        /// <remarks>
        /// Update the Technology using Id
        /// </remarks>
        /// <param name="technology">Technology Object</param>
        /// <returns>After Update, returns technology object</returns>
        [HttpPut]
        public async Task<IActionResult> Put(ITechnologyViewModel technology)
        {
            try
            {
                var data = await Service.Update(technology);
                return Ok(new OneDATApiResponse("Updated Successfully", data));
            }
            catch (OneDATException ex)
            {
                return BadRequest(new OneDATApiResponse(ex.Message, false));
            }
            catch (Exception ex)
            {
                return ServerError("Error Updating Records in technology", false, ex);
            }
        }

        /// <summary>
        /// Deletes a specific Technology.
        /// </summary>
        /// <remarks>
        /// Deletes a specific Technology using technology.
        /// </remarks>
        /// <param name="id"> id is used to delete</param>        
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            var data = Service.Delete(id);
            return Ok(new OneDATApiResponse("Deleted Successfully", data));
        }

        /// <summary>
        /// Find the technology By Code,Name,ColorCode
        /// </summary>
        /// <remarks>
        /// Find the Technology using Code,ColorCode,Name
        /// </remarks>
        /// <param name="technology"> </param>
        /// <returns></returns>
        [HttpPost]
        [Route("Find")]
        public async Task<IActionResult> Find([FromBody]TechhnologyFindViewModel technology)
        {
            try
            {
                var data = await Service.Find(technology);
                return Ok(new OneDATApiResponse("Successfull", data));
            }
            catch (OneDATException ex)
            {
                if (ex.Code == OneDATExceptionCode.NotFound)
                {
                    return NotFound(new OneDATApiResponse("Data not found", false));
                }
                else
                    return BadRequest(new OneDATApiResponse(ex.Message, false));
            }
            catch (Exception ex)
            {
                return ServerError("Error Finding Records in technology", false, ex);
            }
        }
    }
}