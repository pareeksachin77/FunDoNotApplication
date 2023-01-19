using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Context;

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
    }
}
