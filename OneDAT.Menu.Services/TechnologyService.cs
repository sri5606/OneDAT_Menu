using Microsoft.Extensions.Logging;
using OneDAT.Menu.Interfaces.IRepository;
using OneDAT.Menu.Interfaces.IServices;
using OneDAT.Menu.Interfaces.IViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using OneDAT.Helper.Models;
using OneDAT.Helper.Enumerations;
using System.Collections.ObjectModel;
using OneDAT.Helper.IModels;
using OneDAT.Helper.Exception;
using System.Linq;

namespace OneDAT.Menu.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class TechnologyService : ITechnologyService
    {
        private readonly ILogger<TechnologyService> _logger;
        private readonly ITechnologyRepository _technologyRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="technologyRepository"></param>
        public TechnologyService(ILogger<TechnologyService> logger, ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
            _logger = logger;
        }

        /// <summary>
        /// Method to Add the New Technology to the DataBase
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ITechnologyViewModel> Add(ITechnologyViewModel model)
        {
            //var conditions = CreateFindCondition(model, FilterOperator.Or);
            var data = await GetAll();
            if (data != null && data.Any(o => o.Code == model.Code || o.ColorCode == model.ColorCode || o.Name == model.Name))
            {
                throw new OneDATException(OneDATExceptionCode.AlreadyExists);
            }
            else
            {
                return await _technologyRepository.Add(model);
            }
        }
        /// <summary>
        ///  Method to Delete a specific Technology From the DataBase.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(string id)
        {
            // var getAllData = await _technologyRepository.GetAll();
            bool returnValue = await _technologyRepository.Delete(id); ;
            if (returnValue)
            {
                return returnValue;
            }
            else
            {
                throw new OneDATException(OneDATExceptionCode.NotFound);
            }
        }

        /// <summary>
        ///  Method to Find Technology using Techonolgy Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ICollection<ITechnologyViewModel>> Find(ITechnologyViewModel model)
        {
            var conditions = CreateFindCondition(model, FilterOperator.Equal);
            if (conditions.Count > 0)
            {
                var tech = await _technologyRepository.Find(conditions);
                if (tech != null)
                {
                    return tech;
                }
                else
                {
                    throw new OneDATException(OneDATExceptionCode.NotFound);
                }
            }
            else
            {
                return default(ICollection<ITechnologyViewModel>);
            }
        }

        /// <summary>
        ///  Method to Get All Technologies From the DataBase
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<ITechnologyViewModel>> GetAll()
        {
            return await _technologyRepository.GetAll();
        }

        /// <summary>
        ///  Method to Get Technology From the DataBase using Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ITechnologyViewModel> Get(string id)
        {
            var data = await _technologyRepository.Get(id);
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ICollection<ITechnologyViewModel>> GetAllById(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to update Technology using Techonolgy Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ITechnologyViewModel> Update(ITechnologyViewModel model)
        {
            return await _technologyRepository.Update(model);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<string> TestCode()
        {
            return await _technologyRepository.TestCode();
        }


        #region private Method
        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <param name="filterOperator"></param>
        /// <returns></returns>
        private static Collection<FilterCondition> CreateFindCondition(ITechnologyViewModel model, FilterOperator filterOperator)
        {
            var conditions = new Collection<FilterCondition>();
            if (!string.IsNullOrEmpty(model.Name))
            {
                conditions.Add(new FilterCondition("Name", filterOperator, model.Name));
            }
            if (!string.IsNullOrEmpty(model.ColorCode))
            {
                conditions.Add(new FilterCondition("ColorCode", filterOperator, model.ColorCode));
            }
            if (!string.IsNullOrEmpty(model.Code))
            {
                conditions.Add(new FilterCondition("Code", filterOperator, model.Code));
            }
            if (!string.IsNullOrEmpty(model.Status))
            {
                conditions.Add(new FilterCondition("Status", filterOperator, model.Status));
            }
            if (!string.IsNullOrEmpty(model.Description))
            {
                conditions.Add(new FilterCondition("Description", filterOperator, model.Description));
            }
            return conditions;
        }
        #endregion
    }
}
