using sybids.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sybids.Interfaces
{
    public interface IBidRepo {
        Task<IEnumerable<PairingModel>> GetPairings();
        Task<PairingModel> GetPairing(string pairingId); 
        Task AddPairing(PairingModel pairing);
        Task AddLine(LineModel line);
    }
}