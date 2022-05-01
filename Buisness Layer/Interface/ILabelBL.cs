using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer.Interface
{
    public interface ILabelBL
    {
        Task Addlabel(int userId, int Noteid, string LabelName);
        Task<List<Label>> Getlabel(int userId);
        Task<List<Label>> GetlabelByNoteId(int NoteId);
        Task<Label> UpdateLabel(int userId, int LabelId, string LabelName);
        Task DeleteLabel(int LabelId, int userId);
    }
}
