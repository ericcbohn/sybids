using System;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using sybids.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace sybids.Repo {
    public class BidRepo : IBidRepo {
        private readonly MongoContext _context = null;

        public BidRepo(IOptions<Settings> settings) {
            _context = new MongoContext(settings);
        }

        public async Task<IEnumerable<PairingModel>> GetPairings() {
            var documents = await _context.Pairing.Find(_ => true).ToListAsync();
            return documents;
        }

        public async Task<PairingModel> GetPairing(string pairingId) { 
            var filter = Builders<PairingModel>.Filter.Eq("pairingid", pairingId);
            try { 
                return await _context.Pairing.Find(filter).FirstOrDefaultAsync();
            }
            catch(Exception ex) {
                // log or manage
                throw ex;
            }
        }

        public async Task AddPairing(PairingModel pairing) {
            var deleteme = Builders<PairingModel>.Filter.Eq("pairingid", 1);
            await _context.Pairing.CountAsync(deleteme);
            // try {
            //     await _context.Pairing.InsertOneAsync(pairing);
            // }
            // catch (Exception ex) {
            //     // log or manage
            //     throw ex;
            // }
        }

        public async Task AddLine(LineModel line) {
            var deleteme = Builders<LineModel>.Filter.Eq("lineid", 1);
            await _context.Line.CountAsync(deleteme);
            // try {
            //     await _context.Line.InsertOneAsync(line);
            // }
            // catch (Exception ex) {
            //     // log or manage
            //     throw ex;
            // }
        }

        // public async Task AddPairings(List<PairingModel> pairings) {
        //     var deleteme = Builders<PairingModel>.Filter.Eq("pairingid", 1);
        //     try { await _context.Pairing.CountAsync(deleteme);
        //         //await _context.Pairing.InsertManyAsync(pairings);
        //     }
        //     catch (Exception ex) {
        //         // log or manage
        //         throw ex;
        //     }
        // }

        // public async Task AddLines(List<LineModel> lines) {
        //     var deleteme = Builders<LineModel>.Filter.Eq("lineid", 1);
        //     try { await _context.Line.CountAsync(deleteme);
        //         //await _context.Line.InsertManyAsync(lines);
        //     }
        //     catch (Exception ex) {
        //         // log or manage
        //         throw ex;
        //     }
        // }

        // public Task<bool> UpdatePairing(int pairingId, PairingModel pairing);
        // public Task<bool> RemovePairing(int pairingId);
        // public Task<bool> RemoveAllPairings();
    }
}

#region old model

        // public async Task<IEnumerable<BidModel>> GetBids() {
        //     var documents = await _context.Bid.Find(_ => true).ToListAsync();
        //     return documents;
        // }
        // public async Task<BidModel> GetBid(DateTime bidDate) {
        //     var filter = Builders<BidModel>.Filter.Eq("biddate", bidDate);
        //     try { 
        //         return await _context.Bid.Find(filter).FirstOrDefaultAsync();
        //     }
        //     catch(Exception ex) {
        //         // log or manage
        //         throw ex;
        //     }
        // }
        // public async Task AddBid(BidModel bid) { 
        //     try {
        //         await _context.Bid.InsertOneAsync(bid);
        //     }
        //     catch (Exception ex) {
        //         // log or manage
        //         throw ex;
        //     }
        // }

        // public async Task<IEnumerable<LineModel>> GetAllLines() {
        //     var documents = await _context.Lines.Find(_ => true).ToListAsync();
        //     return documents;
        // }

        // public async Task<LineModel> GetLine(int lineId) {
        //     var filter = Builders<LineModel>.Filter.Eq("lineid", lineId);
        //     try { 
        //         return await _context.Lines.Find(filter).FirstOrDefaultAsync();
        //     }
        //     catch(Exception ex) {
        //         // log or manage exception
        //         throw ex;
        //     }
        // }

        // public async Task AddLine(LineModel line) {
        //     try {
        //         await _context.Lines.InsertOneAsync(line);
        //     }
        //     catch(Exception ex) {
        //         //log or manage exception
        //         throw ex;
        //     }
        // }

        // public async Task<bool> UpdateLine(int lineId, LineModel line) {
        //     try {
        //         ReplaceOneResult actionResult = await _context.Lines.ReplaceOneAsync(l => l.LineId.Equals(lineId), line);//, new UpdateOptions { IsUpsert = true });
        //         return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
        //     }
        //     catch(Exception ex) {
        //         // log or manage
        //         throw ex;
        //     }
        // }

        // public async Task<bool> RemoveLine(int lineId) {
        //     var filter = Builders<LineModel>.Filter.Eq("lineid", lineId);
        //     try {
        //         DeleteResult actionResult = await _context.Lines.DeleteOneAsync(filter);
        //         return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        //     }
        //     catch(Exception ex) {
        //         // log or manage
        //         throw ex;
        //     }
        // }

        // public async Task<bool> RemoveAllLines() {
        //     try {
        //         DeleteResult actionResult = await _context.Lines.DeleteManyAsync(new BsonDocument());
        //         return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        //     }
        //     catch(Exception ex) {
        //         // log or manage
        //         throw ex;
        //     }
        // }

#endregion