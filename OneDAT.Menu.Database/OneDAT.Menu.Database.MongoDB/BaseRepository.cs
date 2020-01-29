using Microsoft.Extensions.Logging;
using OneDAT.Helper.IModels;
using OneDAT.Helper.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneDAT.Menu.Database.MongoDB
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="R"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class  BaseRepository<R, T, V, I> : IBaseRepository<I> where R : class where T : class, IBaseDBModel where V : I where I : IBaseDBModel
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
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<I> Add(V model)
        {
            model.InitAdd();
            return model;
        }

        public Task<I> Add(I model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(string id)
        {
            return  true;
        }

        public Task<I> Find(V model)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<I>> Find( ICollection<FilterCondition> conditions)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<V> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<I>> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<ICollection<I>> GetAllById(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<I> Update(V model)
        {
            throw new NotImplementedException();
        }

        public Task<I> Update(I model)
        {
            throw new NotImplementedException();
        }

        Task<I> IBaseRepository<I>.Get(string id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
