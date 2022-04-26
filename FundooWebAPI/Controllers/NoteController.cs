using Buisness_Layer.Interface;
using Database_Layer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository_Layer.Context;
using Repository_Layer.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FundooWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class NoteController : ControllerBase
    {
        INoteBL noteBL;
        FundooContext fundoo;
        public NoteController(INoteBL noteBL, FundooContext fundoo)
        {
            this.noteBL = noteBL;
            this.fundoo = fundoo;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddNote(NotePostModel notePostModel)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);

              await  this.noteBL.AddNote(notePostModel, userId);
                return this.Ok(new {success=true,message="Note Added Successfully!!"});
            }
            catch (Exception ex)
            {
                throw ex;
            }           

        }
        [Authorize]
        [HttpGet("Get/{noteId}")]
        public async Task<ActionResult> GetNote(int noteId, int userId)
        {
            try
            {
                var result = await this.noteBL.GetNote(noteId,userId);
                return this.Ok(new { success = true, message = $"Below are the Note data",data=result });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
     
        [HttpPut("Update")]
        public async Task<ActionResult> UpdateNote(NotePostModel notePostModel, int noteId, int userId)
        {
            try
            {
                var result = await this.noteBL.UpdateNote(notePostModel,noteId, userId);
                return this.Ok(new { success = true, message = $"Note updated successfully!!!", data = result });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteNote(int noteId, int userId)
        {
            try
            {
                await this.noteBL.DeleteNote(noteId, userId);
                return this.Ok(new { success = true, message = "Note deleted successfully!!!"});
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
