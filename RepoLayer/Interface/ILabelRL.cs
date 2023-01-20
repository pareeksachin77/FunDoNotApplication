using RepoLayer.Context;
using RepoLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface ILabelRL
    {
        public bool CreateLabel(long notesId, long userId, string labelName);
        public IEnumerable<LabelEntity> RetriveLabel(long labelId);
        public bool DeleteLabel(long labelId);
    }
}
