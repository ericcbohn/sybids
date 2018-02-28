using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sybids.Models;

namespace sybids.Repo {
    public interface IBidRepo {
        Task<IEnumerable<BidModel>> GetBids();
        Task<BidModel> GetBid(DateTime bidDate); 
        Task AddBid(BidModel bid);

        Task<IEnumerable<PairingModel>> GetPairings();
        Task<PairingModel> GetPairing(string pairingId); 
        Task AddPairing(PairingModel pairing);
        // Task<bool> UpdatePairing(int pairingId, PairingModel pairing);
        // Task<bool> RemovePairing(int pairingId);
        // Task<bool> RemoveAllPairings();
    }
}

#region old model

    // Task<IEnumerable<LineModel>> GetAllLines();
    // Task<LineModel> GetLine(int lineId); 
    // Task AddLine(LineModel line);
    // Task<bool> UpdateLine(int lineId, LineModel line);
    // Task<bool> RemoveLine(int lineId);
    // Task<bool> RemoveAllLines();

#endregion