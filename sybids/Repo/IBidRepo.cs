using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sybids.Models;

namespace sybids.Repo {
    public interface IBidRepo {
        Task<IEnumerable<LineModel>> GetAllLines();
        Task<LineModel> GetLine(int lineId); 
        Task AddLine(LineModel line);
        Task<bool> UpdateLine(int lineId, LineModel line);
        Task<bool> RemoveLine(int lineId);
        Task<bool> RemoveAllLines();
    }
}