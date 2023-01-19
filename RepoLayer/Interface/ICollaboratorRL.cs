using RepoLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface ICollaboratorRL
    {
        public CollaboratorEntity CreateCollab(long notesId, string email);
        public IEnumerable<CollaboratorEntity> GetCollab(long notesId);
    }
}
