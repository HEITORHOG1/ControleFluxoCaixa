using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFluxoCaixa.DOMAIN.BaseModel
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid? Id { get; set; }
    }
}
