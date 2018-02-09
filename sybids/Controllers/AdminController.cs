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
    public class AdminController : Controller 
    {
        private readonly IBidRepo _repo;

        public AdminController(IBidRepo repo) {
            _repo = repo;
        }

        // call an initialization - api/system/init
        [HttpGet("{setting}")]
        public string Get(string setting) {
            if (setting == "init") {
                _repo.RemoveAllLines();
                _repo.AddLine(new LineModel() {

                });
                return "done";
            }
            return "unknown";
        }
    }
}