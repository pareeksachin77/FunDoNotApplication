using BusinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Entities;
using RepoLayer.Interface;
using RepoLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class NoteBL: INoteBL
    {
        INoteRL noteRL;

        public NoteBL(INoteRL noteRL)
        {
            this.noteRL = noteRL;
        }

        public NotesEntity CreateNote(NoteModel noteModel, long UserId)
        {
            try
            {
                return noteRL.CreateNote(noteModel, UserId);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<NotesEntity> ReadNotes(long userId, long notesId)
        {

            try
            {
                return noteRL.ReadNote(userId, notesId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool UpdateNotes(long userId, long notesId, NoteModel noteModel)
        {
            try
            {
                return this.noteRL.UpdateNotes(notesId, userId, noteModel);
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
                return this.noteRL.DeleteNotes(userId, notesId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool PinNote(long notesId, long userId)
        {
            try
            {
                return this.noteRL.PinNote(notesId,userId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Trash(long notesId , long userId)
        {
            try
            {
                return this.noteRL.Trash(notesId, userId);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
