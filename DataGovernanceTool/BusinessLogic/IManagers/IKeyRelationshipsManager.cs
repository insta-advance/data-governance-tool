using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataGovernanceTool.Data.Models.Metadata.Relationships;

namespace DataGovernanceTool.BusinessLogic.IManagers
{
    public interface IKeyRelationshipsManager: IRepositoryManager<KeyRelationship>
    { 
        // Task<TEntity> GetAsync(int id);
        // Task<TEntity> GetFromAsync(int id);
        // Task<TEntity> GetToAsync(int id);
        // Task<TEntity> GetCompositeAsync(int fromId, int toId);
    }
}