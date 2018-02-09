using System;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using sybids.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace sybids.Repo {
    public class BidRepo : IBidRepo {
        private readonly BidContext _context = null;

        public BidRepo(IOptions<Settings> settings) {
            _context = new BidContext(settings);
        }

        public async Task<IEnumerable<LineModel>> GetAllLines() {
            var documents = await _context.Lines.Find(_ => true).ToListAsync();
            return documents;
        }

        public async Task<LineModel> GetLine(int lineId) {
            var filter = Builders<LineModel>.Filter.Eq("lineid", lineId);
            try { 
                return await _context.Lines.Find(filter).FirstOrDefaultAsync();
            }
            catch(Exception ex) {
                // log or manage exception
                throw ex;
            }
        }

        public async Task AddLine(LineModel line) {
            try {
                await _context.Lines.InsertOneAsync(line);
            }
            catch(Exception ex) {
                //log or manage exception
                throw ex;
            }
        }

        public async Task<bool> UpdateLine(int lineId, LineModel line) {
            try {
                ReplaceOneResult actionResult = await _context.Lines.ReplaceOneAsync(l => l.LineId.Equals(lineId), line, new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
            }
            catch(Exception ex) {
                // log or manage
                throw ex;
            }
        }

        public async Task<bool> RemoveLine(int lineId) {
            var filter = Builders<LineModel>.Filter.Eq("lineid", lineId);
            try {
                DeleteResult actionResult = await _context.Lines.DeleteOneAsync(filter);
                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch(Exception ex) {
                // log or manage
                throw ex;
            }
        }

        public async Task<bool> RemoveAllLines() {
            try {
                DeleteResult actionResult = await _context.Lines.DeleteManyAsync(new BsonDocument());
                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch(Exception ex) {
                // log or manage
                throw ex;
            }
        }
    }
}