using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sybids.Repo;
using sybids.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sybids.Controllers
{
    [Route("api/[controller]")]
    public class BidController : Controller
    {
        private readonly IBidRepo _bidRepo;

        public BidController(IBidRepo repo) {
            _bidRepo = repo;
        }

        [HttpGet]
        public Task<IEnumerable<LineModel>> Get() {
            return GetAllLinesInternal();
        }

        private async Task<IEnumerable<LineModel>> GetAllLinesInternal() {
            return await _bidRepo.GetAllLines();
        }

        [HttpGet("{lineId}")]
        public Task<LineModel> Get(string lineId) {
            return GetLineInternal(lineId);
        }

        private async Task<LineModel> GetLineInternal(string lineId) {
            return await _bidRepo.GetLine(lineId);
        }

        [HttpPost]
        public void Post([FromBody]LineModel line) {
            _bidRepo.AddLine(line);
        }

        [HttpPut("{lineId}")]
        public void Put(string lineId, [FromBody]LineModel line) {
            _bidRepo.UpdateLine(lineId, line);
        }

        public void Delete(string lineId) {
            _bidRepo.RemoveLine(lineId);
        }
    }
}
