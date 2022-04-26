﻿using Database_Layer;
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
      public class NoteRL : INoteRL
      {
            // Created The User Repository Layer Class To Implement IUserRL Methods
            // Reference Object For FundooContext And IConfiguration
            FundooContext fundoo;
            private readonly IConfiguration Toolsettings;

            //Created Constructor To Initialize Fundoocontext For Each Instance
            public NoteRL(FundooContext fundoo, IConfiguration Toolsettings)
            {
                this.fundoo = fundoo;
                this.Toolsettings = Toolsettings;
            }

            public async Task AddNote(NotePostModel notePostModel, int userId)
            {
                // throw new NotImplementedException();
                try
                {
                    var user = fundoo.Users.FirstOrDefault(u => u.UserId == userId);
                    Note note = new Note
                    {
                        User = user
                    };
                    note.Title = notePostModel.Title;
                    note.Description = notePostModel.Description;
                    note.BGColor = notePostModel.BGColor;
                    note.IsArchive = notePostModel.IsArchive;
                    note.IsReminder = notePostModel.IsReminder;
                    note.IsPin = notePostModel.IsPin;
                    note.IsTrash = notePostModel.IsTrash;

                    fundoo.Add(note);
                    await fundoo.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            public async Task<Note> GetNote(int noteId, int userId)
            {
                try
                {
                    return await fundoo.Note.Where(u => u.NoteId == noteId && u.UserId == userId)
                    .Include(u => u.User).FirstOrDefaultAsync();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        public async Task DeleteNote(int noteId, int userId)
        {
            try
            {
                Note res = fundoo.Note.FirstOrDefault(u => u.NoteId == noteId && u.UserId == userId);
                fundoo.Note.Remove(res);
                await fundoo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Note> UpdateNote(NotePostModel notePostModel, int noteId, int userId)
        {
            try
            {
                var res =  fundoo.Note.Where(u => u.NoteId == noteId && u.UserId == userId).FirstOrDefaultAsync();
                if (res != null)
                {
                    Note note = new Note();
                    note.Title = notePostModel.Title;
                    note.Description = notePostModel.Description;
                    note.BGColor = notePostModel.BGColor;
                    note.IsArchive = notePostModel.IsArchive;
                    note.IsReminder = notePostModel.IsReminder;
                    note.IsPin = notePostModel.IsPin;
                    note.IsTrash = notePostModel.IsTrash;
                    await fundoo.SaveChangesAsync();
                    
                    return await fundoo.Note.Where(a => a.NoteId == noteId).FirstOrDefaultAsync();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
