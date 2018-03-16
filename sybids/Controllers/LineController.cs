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
    public class LineController : Controller 
    {
        private readonly ILineRepo _repo;

        public LineController(ILineRepo repo) {
            this._repo = repo;
        }

        // Post single line - api/line/
        [HttpPost]
        public void Post([FromBody]LineModel line) {
            this._repo.AddLine(line);
        }

        [HttpGet]
        public async Task<IEnumerable<LineModel>> Get() {
            return await this._repo.GetLines();
        }
        
        // Get specific line - api/line/{lineid}
        [HttpGet("{lineId}")]
        public async Task<LineModel> Get(int lineId) {
            return await _repo.GetLine(lineId);
        }

        // Put specific line - api/bid/{lineid}
        [HttpPut("{lineid}")]
        public void Put(int lineId, [FromBody]LineModel line) {
            _repo.UpdateLine(lineId, line);
        }

        // Delete specific line - api/bid/{lineid}
        [HttpDelete("{lineid}")]
        public void Delete(int lineId) {
            _repo.RemoveLine(lineId);
        }

        // Delete all lines - api/bid
        [HttpDelete]
        public void Delete() {
            _repo.RemoveAllLines();
        }
    }
}