using RepoLayer.Context;
using RepoLayer.Entities;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace RepoLayer.Service
{
    public class LabelRL : ILabelRL
    {
        FunDoContext fundoo;
        public LabelRL(FunDoContext fundoo)
        {
            this.fundoo = fundoo;
        }

        public bool CreateLabel(long notesId, long userId, string labelName)
        {
            try
            {
                var result = fundoo.LabelTable.Where(e => e.UserId == userId);
                if (result != null)
                {
                    LabelEntity labelEntity = new LabelEntity();
                    labelEntity.LabelName = labelName;
                    labelEntity.NoteID = notesId;
                    labelEntity.UserId = userId;
                    fundoo.LabelTable.Add(labelEntity);
                    int saveResult = fundoo.SaveChanges();
                    if (saveResult > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
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
                var result = fundoo.LabelTable.Where(e => e.LabelID == labelId).ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
