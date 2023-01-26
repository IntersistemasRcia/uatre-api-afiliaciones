using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class ActividadRepository : RepositoryBase<Actividad>, IActividadRepository
    {
        public ActividadRepository(AfiliacionesDbContext context) : base(context)
        {
        }
    }
}
