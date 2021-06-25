using System.Collections.Generic;
using System.Linq;

namespace Xamarin_GitHub.Data.Entity.Mapper
{
    public abstract class BaseMapper<TModel, TEntity>
    {
        protected abstract TModel Transform(TEntity entity);

        public List<TModel> TransformList(IEnumerable<TEntity> list)
        {
            return list.Select(Transform).ToList();
        }
    }
}