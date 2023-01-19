using RepoLayer.Context;
using RepoLayer.Entities;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepoLayer.Service
{
    public class CollaboratorRL : ICollaboratorRL
    {
        FunDoContext fundoo;
        public CollaboratorRL(FunDoContext fundoo)
        {
            this.fundoo = fundoo;
        }
        public CollaboratorEntity CreateCollab(long notesId, string email)
        {
            try
            {
                var noteResult = fundoo.NotesTable.Where(x => x.NoteID == notesId).FirstOrDefault();
                var emailResult = fundoo.UserTable.Where(x => x.Email == email).FirstOrDefault();
                if(emailResult != null && noteResult != null)
                {
                    CollaboratorEntity collaboratorEntity = new CollaboratorEntity();
                    collaboratorEntity.NoteID = noteResult.NoteID;
                    collaboratorEntity.Email = emailResult.Email;
                    collaboratorEntity.UserId=emailResult.UserId;
                    fundoo.Add(collaboratorEntity);
                    fundoo.SaveChanges();
                    return collaboratorEntity;

                }
                else
                {
                    return null;
                }
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
                var Result = fundoo.CollabTable.Where(x => x.NoteID ==notesId).ToList();
                if (Result != null)
                {
                    return Result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
            

        }
    }
}
