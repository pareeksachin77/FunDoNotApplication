using RepoLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ILabelBL
    {
        
        public bool CreateLabel(long notesId, long userId, string labelName);
        public IEnumerable<LabelEntity> RetriveLabel(long labelId);
        public bool DeleteLabel(long labelId);
        public bool UpdateLabel(string name, long labelId);
    }
}
