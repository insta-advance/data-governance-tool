using System;
using DataGovernanceTool.Data.Access.IRepositories;
using DataGovernanceTool.Data.Models.Metadata.Relationships;
using DataGovernanceTool.Data.Access.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool.Data.Models.Metadata.Structure;
using DataGovernanceTool.Data.Models.Exceptions;
using Microsoft.EntityFrameworkCore;


namespace DataGovernanceTool.Data.Access.Repositories
{
    public class CompositeKeyFieldsRepository : Repository<CompositeKeyField>, ICompositeKeyFieldsRepository
    {
        public CompositeKeyFieldsRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}
