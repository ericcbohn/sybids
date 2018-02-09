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

        // Get all lines - api/bid
        [HttpGet]
        public Task<IEnumerable<LineModel>> Get() {
            return GetAllLinesInternal();
        }

        // Get specific line - api/bid/{lineid}
        [HttpGet("{lineId}")]
        public Task<LineModel> Get(int lineId) {
            return GetLineInternal(lineId);
        }

        // Post line - api/bid
        [HttpPost]
        public void Post([FromBody]LineModel line) {
            _bidRepo.AddLine(line);
        }

        // Put specific line - api/bid/{lineid}
        [HttpPut("{lineid}")]
        public void Put(int lineId, [FromBody]LineModel line) {
            _bidRepo.UpdateLine(lineId, line);
        }

        // Delete specific line - api/bid/{lineid}
        [HttpDelete("{lineid}")]
        public void Delete(int lineId) {
            _bidRepo.RemoveLine(lineId);
        }

        // Delete all lines - api/bid
        [HttpDelete]
        public void Delete() {
            _bidRepo.RemoveAllLines();
        }

        #region private methods

        private async Task<IEnumerable<LineModel>> GetAllLinesInternal() {
            return await _bidRepo.GetAllLines();
        }

        private async Task<LineModel> GetLineInternal(int lineId) {
            return await _bidRepo.GetLine(lineId);
        }

        #endregion
    }
}
