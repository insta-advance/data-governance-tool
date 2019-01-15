using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool.Data.Models.Metadata;
using DataGovernanceTool.Data.Models.Exceptions;
using DataGovernanceTool.Data.Models.Metadata.Relationships;
using DataGovernanceTool.Data.Access.IRepositories;
using DataGovernanceTool.Data.Access;
using Microsoft.EntityFrameworkCore;


namespace DataGovernanceTool.BusinessLogic.Managers
{
    public class AnnotationBasesManager: RepositoryManager<AnnotationBase>, IAnnotationBasesManager
    {
        public AnnotationBasesManager(IAnnotationBasesRepository repository)
            : base(repository)
        {
        }
    }
}