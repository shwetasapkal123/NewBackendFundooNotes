using Database_Layer;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer.Interface
{
    public interface INoteBL
    {
        public  Task AddNote(NotePostModel notePostModel, int userId);
        public Task<Note> GetNote(int noteId, int userId);
        Task<Note> UpdateNote(NotePostModel notePostModel, int noteId, int userId);
        Task DeleteNote(int noteId, int userId);
    }
}
