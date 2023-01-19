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
    public class CollabsController : Controller
    {
        
        ICollaboratorBL icollabBL;
        FunDoContext fundoo;
        public CollabsController(ICollaboratorBL icollabBL, FunDoContext fundoo)
        {
            this.icollabBL = icollabBL;
            this.fundoo = fundoo;
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult CreateCollab(long notesId, string email)
        {
            try
            {
                var result = icollabBL.CreateCollab(notesId, email);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Collaborator Created successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Cannot create collaborator." });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("Get")]
        public IActionResult GetCollab(long notesId)
        {
            try
            {
                //long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                var result = icollabBL.GetCollab(notesId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Collabrator feched", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "data not found" });
                }

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult RemoveCollab(long CollabID)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                var result = icollabBL.RemoveCollab(CollabID, userId);
                if (result)
                {
                    return Ok(new { success = true, message = "Removed Collaborator.", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Cannot remove collaborator." });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
