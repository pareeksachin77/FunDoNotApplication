using CommonLayer.Model;
using RepoLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface INoteRL
    {
        public NotesEntity CreateNote(NoteModel noteModel, long UserId);
        public IEnumerable<NotesEntity> ReadNote(long userId, long notesId);

        public bool UpdateNotes(long userId, long notesId, NoteModel noteModel);
        public bool DeleteNotes(long userId, long notesId);
        public bool PinNote(long notesId, long userId);

        public bool Trash(long notesId, long userId);
        public bool Archive(long notesId, long userId);
    }
}
