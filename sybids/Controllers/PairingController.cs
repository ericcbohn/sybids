using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sybids.Interfaces;
using sybids.Models;

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
        [HttpPut("{pairingid, pairing}")]
        public void Put(string pairingId, [FromBody]PairingModel pairing) {
            _repo.UpdatePairing(pairingId, pairing);
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