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

        /// <summary>
        /// Listar entidades baseado em uma condição.
        /// </summary>
        public IQueryable<TEntidade> ListarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return Listar(includeProperties).Where(where);
        }

        /// <summary>
        /// Listar entidades ordenadas baseado em uma condição.
        /// </summary>
        public IQueryable<TEntidade> ListarEOrdenadosPor<TKey>(Expression<Func<TEntidade, bool>> where, Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return ascendente ? ListarPor(where, includeProperties).OrderBy(ordem) : ListarPor(where, includeProperties).OrderByDescending(ordem);
        }

        /// <summary>
        /// Obter uma entidade baseado em uma condição.
        /// </summary>
        public TEntidade ObterPor(Func<TEntidade, bool> where, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return Listar(includeProperties).FirstOrDefault(where);
        }

        /// <summary>
        /// Obter uma entidade pelo seu ID.
        /// </summary>
        public TEntidade ObterPorId(TId id, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            if (includeProperties.Any())
            {
                return Listar(includeProperties).FirstOrDefault(x => x.Id.ToString() == id.ToString());
            }

            return _context.Set<TEntidade>().Find(id);
        }

        /// <summary>
        /// Listar todas as entidades.
        /// </summary>
        public IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            IQueryable<TEntidade> query = _context.Set<TEntidade>();

            if (includeProperties.Any())
            {
                return Include(_context.Set<TEntidade>(), includeProperties);
            }

            return query;
        }

        /// <summary>
        /// Listar todas as entidades ordenadas.
        /// </summary>
        public IQueryable<TEntidade> ListarOrdenadosPor<TKey>(Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return ascendente ? Listar(includeProperties).OrderBy(ordem) : Listar(includeProperties).OrderByDescending(ordem);
        }

        /// <summary>
        /// Adicionar uma nova entidade.
        /// </summary>
        public TEntidade Adicionar(TEntidade entidade)
        {
            var entity = _context.Add<TEntidade>(entidade);
            return entity.Entity;
        }

        /// <summary>
        /// Atualizar uma entidade.
        /// </summary>
        public TEntidade Editar(TEntidade entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;

            return entidade;
        }

        /// <summary>
        /// Remover uma entidade.
        /// </summary>
        public void Remover(TEntidade entidade)
        {
            _context.Set<TEntidade>().Remove(entidade);
        }

        /// <summary>
        /// Remover um conjunto de entidades.
        /// </summary>
        public void Remover(IEnumerable<TEntidade> entidades)
        {
            _context.Set<TEntidade>().RemoveRange(entidades);
        }

        /// <summary>
        /// Adicionar um conjunto de entidades.
        /// </summary>
        public void AdicionarLista(IEnumerable<TEntidade> entidades)
        {
            _context.AddRange(entidades);
        }

        /// <summary>
        /// Verificar a existência de uma entidade baseado em uma condição.
        /// </summary>
        public bool Existe(Func<TEntidade, bool> where)
        {
            return _context.Set<TEntidade>().Any(where);
        }

        /// <summary>
        /// Incluir propriedades na query.
        /// </summary>
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
