using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Interface
{
    public interface ILabelRL
    {
        Task Addlabel(int userId, int Noteid, string LabelName);
        Task<List<Label>> Getlabel(int userId);
        Task<List<Label>> GetlabelByNoteId(int NoteId);
        Task<Label> UpdateLabel(int userId, int LabelId, string LabelName);
        Task DeleteLabel(int LabelId, int userId);
    }
}
