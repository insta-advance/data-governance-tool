using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataGovernanceTool.Data.Access.IRepositories;
using DataGovernanceTool.Data.Models.Metadata.Relationships;
using DataGovernanceTool.Data.Access.IRepositories;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool.Data.Models.Metadata;
using DataGovernanceTool.Data.Models.Exceptions;
using Microsoft.EntityFrameworkCore;


namespace DataGovernanceTool.Data.Access.Repositories
{
    public class AnnotationBasesRepository : Repository<AnnotationBase>, IAnnotationBasesRepository
    {
        public AnnotationBasesRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}
