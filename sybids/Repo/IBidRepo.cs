using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sybids.Models;

namespace sybids.Repo {
    public interface IBidRepo {
        Task<IEnumerable<LineModel>> GetAllLines();
        Task<LineModel> GetLine(string lineId); 
        Task AddLine(LineModel line);
        Task<bool> UpdateLine(string lineId, LineModel line);
        Task<bool> RemoveLine(string lineId);
        Task<bool> RemoveAllLines();
    }
}