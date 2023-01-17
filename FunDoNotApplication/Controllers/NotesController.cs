using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Experimental.System.Messaging;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace FunDoNotApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class NotesController : ControllerBase
    {
        INoteBL noteBL;
        public NotesController(INoteBL noteBL)
        {
            this.noteBL = noteBL;
        }

        
        [HttpPost]
        [Route("Create")]
        
        public IActionResult CreateNote(NoteModel noteModel)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                var result = noteBL.CreateNote(noteModel, userId);
                if(result != null)
                {
                    return this.Ok(new {success=true, Message="Note Created Successfully", data=result});
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Cannot create note." });
                }


            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
