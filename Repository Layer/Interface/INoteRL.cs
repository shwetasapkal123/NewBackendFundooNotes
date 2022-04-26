using Database_Layer;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Interface
{
    public interface INoteRL
    {
        Task AddNote(NotePostModel notePostModel, int userId);
        Task<Note> GetNote(int noteId,int userId);
        Task<Note> UpdateNote(NotePostModel notePostModel, int noteId, int userId);
        Task DeleteNote(int noteId, int userId);
    }
}
