using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Experimental.System.Messaging;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using RepoLayer.Entities;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using RepoLayer.Context;

namespace FunDoNotApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class NotesController : ControllerBase
    {
        INoteBL noteBL;
        
        private readonly IDistributedCache distributedCache;
        private readonly FunDoContext fundoo;

        public NotesController(INoteBL noteBL)
        {
            this.noteBL = noteBL;
        }

        [Authorize]
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

        [HttpGet]
        [Route("GetNote")]

        public IActionResult ReadNote(long notesId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                var result = noteBL.ReadNotes(userId,notesId);
                if (result != null)
                {
                    return this.Ok(new { success = true, Message = "Get Notes Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Unable to get notes" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("RetrieveAllNote")]
        public IActionResult RetrieveAllNotes()
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                var result = noteBL.RetrieveAllNotes(userId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Note Retrieve Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Note Retrieve Unsuccessfull" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateNotes(long notesId, NoteModel noteModel)
        {

            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                var result = noteBL.UpdateNotes(userId, notesId, noteModel);

                if (result == true)
                {
                    return this.Ok(new { success = true, Message = "Update Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Note Updated" });
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteNotes(long notesId, NoteModel noteModel)
        {

            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                var result = noteBL.DeleteNotes(userId, notesId);

                if (result != false)
                {
                    return this.Ok(new { success = true, Message = "Deleted Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Not Deleted" });
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        [Route("Pin")]
        public IActionResult PinNote(long notesId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                var result = noteBL.PinNote(notesId,userId);
                if(result==true)
                {
                    return  this.Ok(new { success = true, message = "Pinned Successfully", data = result });
                }
                else if (result == false)
                {
                    return Ok(new { success = true, message = "Note Unpinned successfully." });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "UnPinned." });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        [Route("Trash")]
        public IActionResult Trash(long notesId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                var result = noteBL.Trash(notesId,userId);
                
                    if (result == true)
                    {
                        return this.Ok(new { success = true, message = "Note moved to bin." });
                    }
                    else if (result == false)
                    {
                        return Ok(new { success = true, message = "Note moved to home." });
                    }
                    else
                     {
                    return this.BadRequest(new { success = false, message = "something went wrong" });
                     }

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        [Route("Archive")]
        public IActionResult Archive(long notesId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                var result = noteBL.Trash(notesId, userId);

                if (result == true)
                {
                    return this.Ok(new { success = true, message = "Note Archived successfully." });
                }
                else if (result == false)
                {
                    return Ok(new { success = true, message = "Note UnArchived successfully." });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Cannot perform operation" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut]
        [Route("Color")]
        public IActionResult Color(long notesId, string color)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                var result = noteBL.Color(notesId, userId, color);
                if(result == true)
                {
                    return this.Ok(new { success = true, message = "color changed to" + color });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Cannot change color." });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        [Route("Image")]
        public IActionResult Image(IFormFile image, long noteId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                var result = noteBL.Image(image,noteId,userId);
                if (result != null)
                {
                    return Ok(new { success = true, message = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Cannot upload image." });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [HttpGet("redis")]
        public async Task<IActionResult> GetAllCustomersUsingRedisCache()
        {
            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
            var cacheKey = "NotesList";
            string serializedCustomerList;
            var NotesList = new List<NotesEntity>();
            var redisNotesList = await distributedCache.GetAsync(cacheKey);
            if (redisNotesList != null)
            {
                serializedCustomerList = Encoding.UTF8.GetString(redisNotesList);
                NotesList = JsonConvert.DeserializeObject<List<NotesEntity>>(serializedCustomerList);
            }
            else
            {
                NotesList = fundoo.NotesTable.ToList();
                serializedCustomerList = JsonConvert.SerializeObject(NotesList);
                redisNotesList = Encoding.UTF8.GetBytes(serializedCustomerList);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await distributedCache.SetAsync(cacheKey, redisNotesList, options);
            }
            return Ok(NotesList);
        }


    }
}
