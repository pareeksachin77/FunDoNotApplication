using BusinessLayer.Interface;
using RepoLayer.Interface;
using RepoLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class LabelBL: ILabelBL
    {
        ILabelRL iLabelRL;
        public LabelBL(ILabelRL iLabelRL)
        {
            this.iLabelRL = iLabelRL;
        }
        public bool CreateLabel(long notesId, long userId, string labelName)
        {
            try
            {
                return this.iLabelRL.CreateLabel(notesId, userId, labelName);
                //ok
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
  
}
