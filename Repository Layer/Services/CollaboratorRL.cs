using Database_Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository_Layer.Context;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Services
{
    public class CollaboratorRL:ICollaboratorRL
    {
        FundooContext fundo;
        public IConfiguration Configuration { get; }

        //Creating constructor for initialization
        public CollaboratorRL(FundooContext fundo, IConfiguration configuration)
        {
            this.fundo = fundo;
            this.Configuration = configuration;
        }

        public async Task<Collaborator> AddCollaborator(int userId, int NoteId, CollaboratorValidation collab)
        {
            try
            {
                var user = fundo.Users.FirstOrDefault(u => u.UserId == userId);
                var note = fundo.Note.FirstOrDefault(b => b.NoteId == NoteId);
                Collaborator collaborator = new Collaborator
                {
                    User = user,
                    Note = note
                };
                collaborator.CollabEmail = collab.email;
                fundo.Collaborators.Add(collaborator);
                await fundo.SaveChangesAsync();
                return collaborator;

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
                var result = fundo.Collaborators.FirstOrDefault(u => u.UserId == userId && u.NoteId == NoteId && u.collaboratorId == collaboratorId);
                if (result != null)
                {
                    fundo.Collaborators.Remove(result);
                    await fundo.SaveChangesAsync();
                    return true;
                }
                return false;
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
                List<Collaborator> result = await fundo.Collaborators.Where(u => u.UserId == userId).Include(u => u.User).Include(U => U.Note).ToListAsync();
                return result;
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
                List<Collaborator> result = await fundo.Collaborators.Where(u => u.UserId == userId && u.NoteId == NoteId).Include(u => u.User).Include(U => U.Note).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
