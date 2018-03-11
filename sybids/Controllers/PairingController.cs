using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sybids.Repo;
using sybids.Models;

namespace sybids.Controllers 
{
    [Route("api/[controller]")]
    public class PairingController : Controller 
    {
        private readonly IBidRepo _repo;

        public PairingController(IBidRepo repo) {
            this._repo = repo;
        }

        [HttpPost]
        public void Post([FromBody]PairingModel pairing) {
            this._repo.AddPairing(pairing);
        }
    }
}