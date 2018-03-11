using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sybids.Models;

namespace sybids.Interfaces {
    public interface IBidRepo {
        Task<IEnumerable<PairingModel>> GetPairings();
        Task<PairingModel> GetPairing(string pairingId); 
        Task AddPairing(PairingModel pairing);
        Task AddLine(LineModel line);
    }
}