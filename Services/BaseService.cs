using AutoMapper;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{

    public class BaseService<TReq, TEntity, TRes> : IBaseService<TReq, TEntity, TRes> 
        where TEntity : BaseEntity
    {
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly IMapper _mapper;
        protected readonly AppDbContext _db;
        public BaseService(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
            _mapper = mapper;
        }

        public virtual TRes Create(TReq model)
        {
            var ent = _mapper.Map<TReq, TEntity>(model);
            ent.CreateDate = DateTime.Now;

            _dbSet.Add(ent);
            _db.SaveChanges();
            var res = _mapper.Map<TEntity, TRes>(ent);
            return res;
        }

        public virtual void Delete(int id)
        {
            var ent = _dbSet.Find(id);

            _dbSet.Remove(ent);
            _db.SaveChanges();
        }

        public virtual TRes Get(int id)
        {
            var ent = _dbSet.Find(id);
            var res = _mapper.Map<TEntity, TRes>(ent);
            return res;
        }

        public virtual IEnumerable<TRes> Get()
        {
            var ents = _dbSet.ToList();

            var res = _mapper.Map<IEnumerable<TEntity>, IEnumerable<TRes>>(ents);
            return res;
        }


        public virtual TRes Update(TReq model)
        {
            var ent = _mapper.Map<TReq, TEntity>(model);
            ent.UpdateDate = DateTime.Now;

            _dbSet.Update(ent);
            _db.SaveChanges();
            var res = _mapper.Map<TEntity, TRes>(ent);
            return res;
        }
    }
}
