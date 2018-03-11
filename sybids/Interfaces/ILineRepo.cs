using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sybids.Models;

namespace sybids.Interfaces
{
    public interface ILineRepo 
    {
        Task AddLine(LineModel line);
        Task AddLines(IEnumerable<LineModel> lines);
        Task<LineModel> GetLine(string lineId); 
        Task<IEnumerable<LineModel>> GetLines();
        Task<bool> RemoveLine(int lineId);
        Task<bool> RemoveAllLines();
        Task<bool> UpdateLine(int lineId, LineModel line);
    }
}