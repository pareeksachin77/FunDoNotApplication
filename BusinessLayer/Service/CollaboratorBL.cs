using BusinessLayer.Interface;
using RepoLayer.Entities;
using RepoLayer.Interface;
using RepoLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class CollaboratorBL: ICollaboratorBL
    {
        ICollaboratorRL iCollabRL;
        public CollaboratorBL(ICollaboratorRL iCollabRL)
        {
            this.iCollabRL = iCollabRL;
        }
        public CollaboratorEntity CreateCollab(long notesId, string email)
        {
            try
            {
                return iCollabRL.CreateCollab(notesId,email);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<CollaboratorEntity> GetCollab(long notesId)
        {
            try
            {
                return this.iCollabRL.GetCollab(notesId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool RemoveCollab(long CollabID, long userId)
        {
            try
            {
                return iCollabRL.RemoveCollab(CollabID, userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
