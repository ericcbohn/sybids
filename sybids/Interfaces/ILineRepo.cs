using sybids.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sybids.Interfaces
{
    public interface ILineRepo 
    {
        Task AddLine(LineModel line);
        Task AddLines(IEnumerable<LineModel> lines);
        Task<LineModel> GetLine(int lineId); 
        Task<IEnumerable<LineModel>> GetLines();
        Task<bool> RemoveLine(int lineId);
        Task<bool> RemoveAllLines();
        Task UpdateLine(LineModel line);
    }
}