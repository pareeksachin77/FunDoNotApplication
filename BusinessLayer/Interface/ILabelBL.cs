using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ILabelBL
    {
        //ok
        public bool CreateLabel(long notesId, long userId, string labelName);
    }
}
