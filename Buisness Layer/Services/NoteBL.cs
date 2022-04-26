using Buisness_Layer.Interface;
using Database_Layer;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer.Services
{
    public class NoteBL:INoteBL
    {
        INoteRL noteRL;
        public NoteBL(INoteRL userRL)
        {
            this.noteRL = userRL;
        }
        public async Task AddNote(NotePostModel notePostModel, int userId)
        {
            try
            {
              await  this.noteRL.AddNote(notePostModel, userId);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
