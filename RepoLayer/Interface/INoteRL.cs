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
    }
}
