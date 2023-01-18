using RepoLayer.Context;
using RepoLayer.Entities;
using RepoLayer.Interface;
using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Configuration;

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
        public bool UpdateNotes(long userId, long notesId,NoteModel noteModel)
        {
            try
            {
                var result = fundoo.NotesTable.FirstOrDefault(e => e.UserId == userId && e.NoteID == notesId);
                if(result != null)
                {
                    if(noteModel.Title != null)
                    {
                        result.Title = noteModel.Title;
                    }
                    if(noteModel.Description != null){
                        result.Description = noteModel.Description;
                    }
                    result.Updated = DateTime.Now;
                    fundoo.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool DeleteNotes(long userId, long notesId)
        {
            try
            {
                var result = fundoo.NotesTable.FirstOrDefault(e => e.UserId == userId && e.NoteID == notesId);

                if(result != null)
                {
                    fundoo.NotesTable.Remove(result);
                    fundoo.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool PinNote(long notesId)
        {
            try
            {
                var result = fundoo.NotesTable.FirstOrDefault(e=>e.NoteID == notesId);
                if (result.Pin == true)
                {
                    result.Pin = false;
                    fundoo.SaveChanges();
                    return false;
                }
                else
                {
                    result.Pin = true;
                    fundoo.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
           

        }

    }
}
