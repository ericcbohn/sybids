using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;
using sybids.Interfaces;
using sybids.Models;
using sybids.Repo.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace sybids.Repo
{
    public class PairingRepo : IPairingRepo
    {
        private readonly MongoContext _context = null;

        public PairingRepo(IOptions<Settings> settings) {
            _context = new MongoContext(settings);
        }
        
        public async Task AddPairing(PairingModel pairing)
        {
            if(pairing == null) throw new ArgumentNullException(nameof(pairing));
            try
            {
                await _context.Pairings.ReplaceOneAsync(p => p.PairingId.Equals(pairing.PairingId), pairing, new UpdateOptions { IsUpsert = true });
            }
            catch (Exception ex)
            {
                // log or manage
                throw ex;
            }
        }

        public async Task AddPairings(IEnumerable<PairingModel> pairings)
        {
            if (pairings == null) throw new ArgumentNullException(nameof(pairings));
            try
            {
                await _context.Pairings.InsertManyAsync(pairings);
            }
            catch (Exception ex)
            {
                // log or manage
                throw ex;
            }
        }

        public async Task<PairingModel> GetPairing(string pairingId)
        {
            if(string.IsNullOrEmpty(pairingId)) throw new ArgumentNullException(nameof(pairingId));
            var filter = Builders<PairingModel>.Filter.Eq("pairingid", pairingId);
            try { 
                return await _context.Pairings.Find(filter).FirstOrDefaultAsync();
            }
            catch(Exception ex) {
                // log or manage
                throw ex;
            }
        }

        public async Task<IEnumerable<PairingModel>> GetPairings()
        {
            return await _context.Pairings.Find(_ => true).ToListAsync();
        }

        public Task<bool> RemoveAllPairings()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemovePairing(string pairingId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePairing(PairingModel pairing)
        {
            if(pairing == null) throw new ArgumentNullException(nameof(pairing));

            try
            {
                await _context.Pairings.ReplaceOneAsync(p => p.PairingId.Equals(pairing.PairingId), pairing, new UpdateOptions { IsUpsert = true });
            }
            catch (Exception ex)
            {
                // log or manage
                throw ex;
            }
        }
    }
}