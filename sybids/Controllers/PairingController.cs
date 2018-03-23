using Microsoft.AspNetCore.Mvc;
using sybids.Interfaces;
using sybids.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sybids.Controllers
{
    [Route("api/[controller]")]
    public class PairingController : Controller
    {
        private readonly IPairingRepo _repo;

        public PairingController(IPairingRepo repo) {
            this._repo = repo;
        }

        [HttpPost]
        public void Post([FromBody]PairingModel pairing) {
            this._repo.AddPairing(pairing);
        }

        [HttpPost("pairings")]
        public void Post([FromBody]List<PairingModel> pairings) {
            this._repo.AddPairings(pairings);
        }

        [HttpGet]
        public async Task<IEnumerable<PairingModel>> Get() {
            return await this._repo.GetPairings();
        }
        
        // Get specific pairing - api/pairing/{pairingid}
        [HttpGet("{pairingId}")]
        public async Task<PairingModel> Get(string pairingId) {
            return await _repo.GetPairing(pairingId);
        }

        // Put specific pairing - api/pairing/{pairing}
        [HttpPut]
        public void Put([FromBody]PairingModel pairing) {
            _repo.UpdatePairing(pairing);
        }

        // Delete specific pairing - api/pairing/{pairingid}
        [HttpDelete("{pairingid}")]
        public void Delete(string pairingId) {
            _repo.RemovePairing(pairingId);
        }

        // Delete all pairing - api/pairing
        [HttpDelete]
        public void Delete() {
            _repo.RemoveAllPairings();
        }
    }
}