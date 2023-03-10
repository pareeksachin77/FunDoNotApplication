using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using RepoLayer.Entities;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface INoteBL
    {
        public NotesEntity CreateNote(NoteModel noteModel, long UserId);
        public IEnumerable<NotesEntity> ReadNotes(long userId, long notesId);
        public IEnumerable<NotesEntity> RetrieveAllNotes(long userId);
        public bool UpdateNotes(long userId, long notesId, NoteModel noteModel);

        public bool DeleteNotes(long userId, long notesId);
        public bool PinNote(long notesId, long userId);
        public bool Trash(long notesId, long userId);
        public bool Archive(long notesId, long userId);
        public bool Color(long notesId, long userId, string color);
        public string Image(IFormFile image, long notesId, long userId);


    }
}
