using ControleFluxoCaixa.DOMAIN.BaseModel;
using ControleFluxoCaixa.DOMAIN.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ControleFluxoCaixa.INFRA.Repositories.Base
{
    public class RepositoryBase<TEntidade, TId> : IRepositoryBase<TEntidade, TId>
       where TEntidade : EntityBase
       where TId : struct
    {

        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntidade> ListarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return Listar(includeProperties).Where(where);
        }

        public IQueryable<TEntidade> ListarEOrdenadosPor<TKey>(Expression<Func<TEntidade, bool>> where, Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return ascendente ? ListarPor(where, includeProperties).OrderBy(ordem) : ListarPor(where, includeProperties).OrderByDescending(ordem);
        }

        public TEntidade ObterPor(Func<TEntidade, bool> where, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return Listar(includeProperties).FirstOrDefault(where);
        }

        public TEntidade ObterPorId(TId id, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            if (includeProperties.Any())
            {
                return Listar(includeProperties).FirstOrDefault(x => x.Id.ToString() == id.ToString());
            }

            return _context.Set<TEntidade>().Find(id);
        }

        public IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            IQueryable<TEntidade> query = _context.Set<TEntidade>();

            if (includeProperties.Any())
            {
                return Include(_context.Set<TEntidade>(), includeProperties);
            }

            return query;
        }

        public IQueryable<TEntidade> ListarOrdenadosPor<TKey>(Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return ascendente ? Listar(includeProperties).OrderBy(ordem) : Listar(includeProperties).OrderByDescending(ordem);
        }

        public TEntidade Adicionar(TEntidade entidade)
        {
            var entity = _context.Add<TEntidade>(entidade);
            return entity.Entity;
            //return _context.Set<TEntidade>().Add(entidade);
        }

        public TEntidade Editar(TEntidade entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;

            return entidade;
        }

        public void Remover(TEntidade entidade)
        {
            _context.Set<TEntidade>().Remove(entidade);
        }

        public void Remover(IEnumerable<TEntidade> entidades)
        {
            _context.Set<TEntidade>().RemoveRange(entidades);
        }

        public void AdicionarLista(IEnumerable<TEntidade> entidades)
        {
            _context.AddRange(entidades);
            //return _context.Set<TEntidade>().AddRange(entidades);
        }

        public bool Existe(Func<TEntidade, bool> where)
        {
            return _context.Set<TEntidade>().Any(where);
        }

        private IQueryable<TEntidade> Include(IQueryable<TEntidade> query, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }

            return query;
        }
    }
}
