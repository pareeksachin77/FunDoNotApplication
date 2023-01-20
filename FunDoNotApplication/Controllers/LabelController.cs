using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Context;
using System.Linq;
using System;

namespace FunDoNotApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LabelController : ControllerBase
    {
         ILabelBL iLabelBL;
         FunDoContext fundoo;

        public LabelController(ILabelBL iLabelBL, FunDoContext fundoo)
        {
            this.fundoo = fundoo;
            this.iLabelBL = iLabelBL;
        }
        //ok
        
        [Authorize]
        [HttpPost]
        [Route("Create")]
        public IActionResult CreateLabel(long noteId, string labelname)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);

                var result = iLabelBL.CreateLabel(noteId, userId, labelname);

                if (result)
                {
                    return Ok(new { success = true, mesage = "Label created", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, mesage = "Unable to add Label." });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
