using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sybids.Models;

namespace sybids.Interfaces 
{
    public interface IPairingRepo 
    {
        Task AddPairing(PairingModel pairing);
        Task AddPairings(IEnumerable<PairingModel> pairings);
        Task<PairingModel> GetPairing(string pairingId); 
        Task<IEnumerable<PairingModel>> GetPairings();
        Task<bool> RemovePairing(string pairingId);
        Task<bool> RemoveAllPairings();
        Task<bool> UpdatePairing(string pairingId, PairingModel pairing);
    }
}