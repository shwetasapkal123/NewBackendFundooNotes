using Database_Layer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer.Interface
{
    public interface INoteBL
    {
        public  Task AddNote(NotePostModel notePostModel, int userId);
    }
}
