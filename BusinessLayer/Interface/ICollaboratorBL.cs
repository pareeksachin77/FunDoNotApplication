using RepoLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ICollaboratorBL
    {
        public CollaboratorEntity CreateCollab(long notesId, string email);
        public IEnumerable<CollaboratorEntity> GetCollab(long notesId);

        public bool RemoveCollab(long CollabID, long userId);
    }
}
