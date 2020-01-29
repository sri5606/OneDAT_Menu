using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Microsoft.Extensions.Logging;
using OneDAT.Menu.Database.DynamoDB.Repository;
using OneDAT.Helper.Constants;
using OneDAT.Helper.IModels;
using OneDAT.Helper.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace OneDAT.Menu.Database.DynamoDB
{   /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="R">Table Respository </typeparam>
    /// <typeparam name="T">Table Class </typeparam>
    /// <typeparam name="V">Table View Model</typeparam>
    /// <typeparam name="I">Table View Model Interface</typeparam>
    public abstract class BaseRepository<R, T, V, I> : IBaseRepository<I> where R : class where T : class, IBaseDBModel where V : I where I : IBaseDBModel
    {
        #region Class Members
        protected internal readonly ILogger<R> Logger;
        protected internal readonly DBContext DBContext;
        protected internal readonly ModelMapper ModelMapper;
        protected internal readonly T TableModel;
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="modelMapper"></param>
        protected BaseRepository(ILogger<R> logger, DBContext dbContext, ModelMapper modelMapper)
        {
            Logger = logger;
            DBContext = dbContext;
            ModelMapper = modelMapper;
        }
        #endregion

        #region Database operations
        /// <summary>
        /// 
        /// </summary>
        /// <param name = "model" ></ param >
        /// < returns ></ returns >
        public async Task<I> Add(I model)
        {
            model.InitAdd();
            T item = ModelMapper.Mapper.Map<I, T>(model);
            await DBContext.Instance.SaveAsync<T>(item);
            return model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(string id)
        {
            await DBContext.Instance.DeleteAsync<T>(id);
            return true;
        }

        public async Task<ICollection<I>> Find(I model, ICollection<FilterCondition> conditions)
        {
            var scanConditions = new List<ScanCondition>();
            foreach (var condition in conditions)
            {
                scanConditions.Add(new ScanCondition(condition.Key, (ScanOperator)condition.Operator, condition.Value));
            }
            return await GetAllByCondition(scanConditions);
        }

        public async Task<ICollection<I>> Find(ICollection<FilterCondition> conditions)
        {
            var scanConditions = new List<ScanCondition>();
            foreach (var condition in conditions)
            {
                scanConditions.Add(new ScanCondition(condition.Key, (ScanOperator)condition.Operator, condition.Value));
            }
            return await GetAllByCondition(scanConditions);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<I> Get(string id)
        {
            var conditions = new List<ScanCondition>();
            conditions.Add(new ScanCondition(ServiceConstants.DbPrimaryColumn, ScanOperator.Equal, id));
            try
            {
                var data = await DBContext.Instance.ScanAsync<T>(conditions).GetRemainingAsync();
                if (data != null && data.Count > 0)
                {
                    var mapData = ModelMapper.Mapper.Map<T, V>(data.First());
                    return mapData;
                }
                else
                {
                    return default(I);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<I>> GetAll()
        {
            var conditions = new List<ScanCondition>();
            return await GetAllByCondition(conditions);
        }

      

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ICollection<I>> GetAllById(string id)
        {
            throw new Exception();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<I> Update(I model)
        {
            model.InitUpdate();
            T item = ModelMapper.Mapper.Map<I, T>(model);
            await DBContext.Instance.SaveAsync<T>(item);
            return model;
        }
        #endregion

        #region Private Methods
        private async Task<ICollection<I>> GetAllByCondition(List<ScanCondition> conditions)
        {
            var list = await DBContext.Instance.ScanAsync<T>(conditions).GetRemainingAsync();
            if (list != null && list.Count > 0)
            {
                var mapData = ModelMapper.Mapper.Map<List<T>, ICollection<V>>(list).Cast<I>().ToList();
                return mapData;
            }
            else return new Collection<I>();
        }
        #endregion


    }
}
