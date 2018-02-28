using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace sybids.Controllers {
    [Route("api/[controller]")]
    public class UploadController : Controller
    {
        // api/upload
        [HttpPost]
        public async void Post(IFormFile file)
        {
            using (var memoryStream = new MemoryStream()) {
                await file.CopyToAsync(memoryStream);
                memoryStream.ToArray(); // can I do something with bytearray?
            }
        }
    }
}