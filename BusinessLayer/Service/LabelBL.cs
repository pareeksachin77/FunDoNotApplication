using BusinessLayer.Interface;
using RepoLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class LabelBL: ILabelBL
    {
        LabelRL iLabelRL;
        public LabelBL(LabelRL iLabelRL)
        {
            this.iLabelRL = iLabelRL;
        }
    }
}
