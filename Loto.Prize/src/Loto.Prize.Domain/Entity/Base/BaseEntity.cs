using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loto.Prize.Domain.Entity.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public List<RetornoEntity> ListaRetorno { get; set; }
    }
}
