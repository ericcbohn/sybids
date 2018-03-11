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
        Task<bool> RemovePairing(int pairingId);
        Task<bool> RemoveAllPairings();
        Task<bool> UpdatePairing(int pairingId, PairingModel pairing);
    }
}