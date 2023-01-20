using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Context;

namespace FunDoNotApplication.Controllers
{
    public class LabelController : Controller
    {
         ILabelBL iLabelBL;
         FunDoContext fundoo;

        public LabelController(ILabelBL iLabelBL, FunDoContext fundoo)
        {
            this.fundoo = fundoo;
            this.iLabelBL = iLabelBL;
        }
    }
}
