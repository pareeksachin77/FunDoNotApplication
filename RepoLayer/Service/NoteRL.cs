using RepoLayer.Context;
using RepoLayer.Entities;
using RepoLayer.Interface;
using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RepoLayer.Service
{
    public class NoteRL: INoteRL
    {
        FunDoContext fundoo;
        public NoteRL(FunDoContext fundoo)
        {
            this.fundoo = fundoo;
        }

        public NotesEntity CreateNote(NoteModel noteModel,long userId)
        {
            try
            {
                NotesEntity notesEntity = new NotesEntity();
                notesEntity.Title = noteModel.Title;
                notesEntity.Description = noteModel.Description;
                notesEntity.Reminder = noteModel.Reminder;
                notesEntity.Color = noteModel.Color;
                notesEntity.Image = noteModel.Image;
                notesEntity.Created = DateTime.Now;
                notesEntity.Updated = DateTime.Now;
                notesEntity.Archive = noteModel.Archive;
                notesEntity.Pin = noteModel.Pin;
                notesEntity.Trash = noteModel.Trash;
                notesEntity.UserId = userId;
                fundoo.NotesTable.Add(notesEntity);
                int result = fundoo.SaveChanges();
                if (result != 0)
                {
                    return notesEntity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<NotesEntity> ReadNote(long userId, long notesId)
        {
            try
            {
                var result = fundoo.NotesTable.Where(e => e.UserId == userId);
                return result;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
