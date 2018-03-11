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
    public class LineController : Controller 
    {
        private const string test = @"{'lineid':'1045','base':'MSP','equipment':'738','position':'CA','blockminutes':'88:55','creditminutes':'92:51','days':[{'month':'Mar','day':'02','pairingid':['M0932']},{'month':'Mar','day':'03','pairingid':['==>']},{'month':'Mar','day':'04','pairingid':['M0085']},{'month':'Mar','day':'05','pairingid':['OFF']},{'month':'Mar','day':'06','pairingid':['OFF']},{'month':'Mar','day':'07','pairingid':['OFF']},{'month':'Mar','day':'08','pairingid':['OFF']},{'month':'Mar','day':'09','pairingid':['M0006']},{'month':'Mar','day':'10','pairingid':['M0006']},{'month':'Mar','day':'11','pairingid':['M0191']},{'month':'Mar','day':'12','pairingid':['==>']},{'month':'Mar','day':'13','pairingid':['OFF']},{'month':'Mar','day':'14','pairingid':['OFF']},{'month':'Mar','day':'15','pairingid':['OFF']},{'month':'Mar','day':'16','pairingid':['M0194']},{'month':'Mar','day':'17','pairingid':['==>']},{'month':'Mar','day':'18','pairingid':['M0222']},{'month':'Mar','day':'19','pairingid':['==>']},{'month':'Mar','day':'20','pairingid':['OFF']},{'month':'Mar','day':'21','pairingid':['OFF']},{'month':'Mar','day':'22','pairingid':['M0210']},{'month':'Mar','day':'23','pairingid':['==>']},{'month':'Mar','day':'24','pairingid':['M0105']},{'month':'Mar','day':'25','pairingid':['M0116']},{'month':'Mar','day':'26','pairingid':['OFF']},{'month':'Mar','day':'27','pairingid':['OFF']},{'month':'Mar','day':'28','pairingid':['OFF']},{'month':'Mar','day':'29','pairingid':['OFF']},{'month':'Mar','day':'30','pairingid':['OFF']},{'month':'Mar','day':'31','pairingid':['M0236']}]}";

        private readonly IBidRepo _repo;

        public LineController(IBidRepo repo) {
            this._repo = repo;
        }

        [HttpPost]
        public void Post([FromBody]LineModel line) {
            this._repo.AddLine(line);
        }
    }
}