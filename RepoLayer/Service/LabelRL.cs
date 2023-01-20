using RepoLayer.Context;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Service
{
    public class LabelRL : ILabelRL
    {
        FunDoContext fundoo;
        public LabelRL(FunDoContext fundoo)
        {
            this.fundoo = fundoo;
        }
    }
}
