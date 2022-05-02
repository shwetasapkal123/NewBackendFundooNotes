﻿using Buisness_Layer.Interface;
using Database_Layer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository_Layer.Context;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class CollaboratorController : ControllerBase
    {
        //Initializing Class
        FundooContext fundo;
        ICollaboratorBL collabBL;

        //Creating Constructor
        public CollaboratorController(ICollaboratorBL collabBL, FundooContext fundo)
        {
            this.collabBL = collabBL;
            this.fundo = fundo;
        }

        //HTTP method to handle add collaborator request
        [Authorize]
        [HttpPost("Addlabel/{NoteId}/{email}")]
        public async Task<ActionResult> AddCollaborator(int NoteId, CollaboratorValidation collab)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                var Id = fundo.Note.Where(x => x.NoteId == NoteId && x.UserId == userId).FirstOrDefault();
                if (Id == null)
                {
                    return this.BadRequest(new { success = false, message = $"Note doesn't exists" });
                }
                var result = await this.collabBL.AddCollaborator(userId, NoteId, collab);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = $"Collaborator added successfully", data = result });
                }
                return this.BadRequest(new { success = false, message = $"Failed to add collaborator", data = result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //HTTP method to handle delete collaborator request
        [Authorize]
        [HttpDelete("RemoveCollaborator/{NoteId}")]
        public async Task<ActionResult> RemoveCollaborator(int NoteId, int collaboratorId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                var re = fundo.Collaborators.Where(x => x.UserId == userId && x.NoteId == NoteId).FirstOrDefault();
                if (re == null)
                {
                    return this.BadRequest(new { success = false, message = $"Note doesn't exists" });
                }
                bool result = await this.collabBL.RemoveCollaborator(userId, NoteId, collaboratorId);
                if (result == true)
                {
                    return this.Ok(new { success = true, message = $"Collaborator removed successfully" });
                }
                return this.BadRequest(new { success = false, message = $"Failed to remove collaborator" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //HTTP method to handle get collaborator request
        [Authorize]
        [HttpGet("GetCollaboratorByNoteId")]
        public async Task<ActionResult> GetCollaboratorByUserId()
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                var Id = fundo.Collaborators.Where(x => x.UserId == userId).FirstOrDefault();
                if (Id == null)
                {
                    return this.BadRequest(new { success = false, message = $"User doesn't exists" });
                }
                List<Collaborator> result = await this.collabBL.GetCollaboratorByUserId(userId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = $"Collaborator got successfully", data = result });
                }
                return this.BadRequest(new { success = false, message = $"Failed to get collaborator" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //HTTP method to handle get collaborator request
        [Authorize]
        [HttpGet("GetCollaboratorByNoteId/{NoteId}")]
        public async Task<ActionResult> GetCollaboratorByNoteId(int NoteId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                var Id = fundo.Collaborators.FirstOrDefault(x => x.NoteId == NoteId && x.UserId == userId);
                if (Id == null)
                {
                    return this.BadRequest(new { success = false, message = $"Note doesn't exists" });
                }
                List<Collaborator> result = await this.collabBL.GetCollaboratorByUserId(userId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = $"Collaborator got successfully", data = result });
                }
                return this.BadRequest(new { success = false, message = $"Failed to get collaborator" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
