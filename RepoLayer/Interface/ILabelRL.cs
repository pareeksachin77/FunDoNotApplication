using RepoLayer.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface ILabelRL
    {
        public bool CreateLabel(long notesId, long userId, string labelName);
    }
}
