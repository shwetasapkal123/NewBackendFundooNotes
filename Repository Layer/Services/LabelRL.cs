using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository_Layer.Context;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Services
{
    public class LabelRL:ILabelRL
    {
        FundooContext fundo;
        public IConfiguration Configuration { get; }

        //Creating constructor for initialization
        public LabelRL(FundooContext fundo, IConfiguration configuration)
        {
            this.fundo = fundo;
            this.Configuration = configuration;
        }

        public async Task Addlabel(int userId, int Noteid, string LabelName)
        {
            try
            {
                var user = fundo.Users.FirstOrDefault(u => u.UserId == userId);
                var note = fundo.Note.FirstOrDefault(b => b.NoteId == Noteid);
                Entity.Label label = new Entity.Label
                {
                    User = user,
                    Note = note
                };
                label.LabelName = LabelName;
                fundo.Labels.Add(label);
                await fundo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<List<Entity.Label>> Getlabel(int userId)
        {
            try
            {
                List<Entity.Label> reuslt = await fundo.Labels.Where(u => u.UserId == userId).Include(u => u.User).Include(u => u.Note).ToListAsync();
                return reuslt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Entity.Label>> GetlabelByNoteId(int NoteId)
        {
            try
            {
                List<Entity.Label> reuslt = await fundo.Labels.Where(u => u.NoteId == NoteId).Include(u => u.User).Include(u => u.Note).ToListAsync();
                return reuslt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Entity.Label> UpdateLabel(int userId, int LabelId, string LabelName)
        {
            try
            {

                Entity.Label reuslt = fundo.Labels.FirstOrDefault(u => u.LabelId == LabelId && u.UserId == userId);

                if (reuslt != null)
                {
                    reuslt.LabelName = LabelName;
                    await fundo.SaveChangesAsync();
                    var result = fundo.Labels.Where(u => u.LabelId == LabelId).FirstOrDefaultAsync();
                    return reuslt;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteLabel(int LabelId, int userId)
        {
            try
            {
                var result = fundo.Labels.FirstOrDefault(u => u.LabelId == LabelId && u.UserId == userId);
                fundo.Labels.Remove(result);
                await fundo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
