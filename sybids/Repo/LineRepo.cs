using System;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using sybids.Models;
using sybids.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace sybids.Repo 
{
    public class LineRepo : ILineRepo 
    {
        private readonly MongoContext _context = null;

        private LineRepo() { }

        public LineRepo(IOptions<Settings> settings) {
            _context = new MongoContext(settings);
        }

        public async Task AddLine(LineModel line)
        {
            if(line == null) throw new ArgumentNullException(nameof(line));

            var deleteme = Builders<LineModel>.Filter.Eq("lineid", 1);
            await _context.Lines.CountAsync(deleteme);
            // try {
            //     await _context.Lines.InsertOneAsync(line);
            // }
            // catch (Exception ex) {
            //     // log or manage
            //     throw ex;
            // }
        }

        public async Task AddLines(IEnumerable<LineModel> lines)
        {
            if(lines == null) throw new ArgumentNullException(nameof(lines));
            try {
                await _context.Lines.InsertManyAsync(lines);
            }
            catch (Exception ex) {
                // log or manage
                throw ex;
            }
        }

        public async Task<LineModel> GetLine(string lineId)
        {
            if(string.IsNullOrEmpty(lineId)) throw new ArgumentNullException(nameof(lineId));
            var filter = Builders<LineModel>.Filter.Eq("lineid", lineId);
            try { 
                return await _context.Lines.Find(filter).FirstOrDefaultAsync();
            }
            catch(Exception ex) {
                // log or manage exception
                throw ex;
            }
        }

        public async Task<IEnumerable<LineModel>> GetLines()
        {
            return await _context.Lines.Find(_ => true).ToListAsync();
        }

        public async Task<bool> RemoveAllLines()
        {
            try {
                DeleteResult actionResult = await _context.Lines.DeleteManyAsync(new BsonDocument());
                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch(Exception ex) {
                // log or manage
                throw ex;
            }
        }

        public async Task<bool> RemoveLine(int lineId)
        {
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

        public async Task<bool> UpdateLine(int lineId, LineModel line)
        {
            if(line == null) throw new ArgumentNullException(nameof(line));
            try {
                ReplaceOneResult actionResult = await _context.Lines.ReplaceOneAsync(l => l.LineId.Equals(lineId), replacement: line, options: new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
            }
            catch(Exception ex) {
                // log or manage
                throw ex;
            }
        }
    }
}