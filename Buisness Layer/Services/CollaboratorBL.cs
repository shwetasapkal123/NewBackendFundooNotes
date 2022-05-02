using Buisness_Layer.Interface;
using Database_Layer;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer.Services
{
    public class CollaboratorBL:ICollaboratorBL
    {
        ICollaboratorRL collabRL;
        public CollaboratorBL(ICollaboratorRL collabRL)
        {
            this.collabRL = collabRL;
        }
        public async Task<Collaborator> AddCollaborator(int userId, int Noteid, CollaboratorValidation collab)
        {
            try
            {
                return await this.collabRL.AddCollaborator(userId, Noteid, collab);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RemoveCollaborator(int userId, int NoteId, int collaboratorId)
        {
            try
            {
                return await this.collabRL.RemoveCollaborator(userId, NoteId, collaboratorId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Collaborator>> GetCollaboratorByUserId(int userId)
        {
            try
            {
                return await this.collabRL.GetCollaboratorByUserId(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<Collaborator>> GetCollaboratorByNoteId(int userId, int NoteId)
        {
            try
            {
                return await this.collabRL.GetCollaboratorByNoteId(userId, NoteId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
