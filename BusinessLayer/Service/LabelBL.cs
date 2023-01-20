using BusinessLayer.Interface;
using RepoLayer.Entities;
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
               
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<LabelEntity> RetriveLabel(long labelId)
        {
            try
            {
                return this.iLabelRL.RetriveLabel(labelId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteLabel(long labelId)
        {
            try
            {
                return this.iLabelRL.DeleteLabel(labelId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

  
}
