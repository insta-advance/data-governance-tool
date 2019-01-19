using DataGovernanceTool.Data.Access.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool.Data.Models.Metadata.Structure;
using DataGovernanceTool.Data.Models.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DataGovernanceTool.BusinessLogic.Managers
{
    public class BasesManager: RepositoryManager<Base>, IBasesManager
    {
        public BasesManager(IBasesRepository repository)
            : base(repository)
        {
        }
        public virtual async Task<String> GetType(int id) {
            return (await Repository.GetAsync(id)).GetType().Name;
        }
    }
}