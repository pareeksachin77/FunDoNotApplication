using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Context;
using System.Linq;
using System;
using RepoLayer.Entities;
using System.Collections.Generic;

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

        [HttpGet]
        [Route("Retrive")]
        public IActionResult RetriveLabel(long labelId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                var result = iLabelBL.RetriveLabel(labelId);
                if(result != null)
                {
                    return Ok(new { success = true, mesage = "Label retrieved", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, mesage = "Unable to retrieved Label." });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteLabel(long labelId)
        {
            try
            {
                //long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var result = iLabelBL.DeleteLabel(labelId);

                if (result== true)
                {
                    return Ok(new { success = true, message = "Label Deleted", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Unable to Delete Label." });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
