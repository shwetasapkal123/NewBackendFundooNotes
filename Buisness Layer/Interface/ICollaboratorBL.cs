using Database_Layer;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer.Interface
{
    public interface ICollaboratorBL
    {
        Task<Collaborator> AddCollaborator(int userId, int NoteId, CollaboratorValidation collab);
        Task<bool> RemoveCollaborator(int userId, int NoteId, int collaboratorId);
        Task<List<Collaborator>> GetCollaboratorByUserId(int userId);
        Task<List<Collaborator>> GetCollaboratorByNoteId(int userId, int NoteId);
    }
}
