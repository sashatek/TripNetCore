using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripCore.DAL;
using TripNetCore.DAL.DbModels;
using TripNetCore.Models;
using TripNetCore.Utils;

namespace TripCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("CorsPolicy")]
    public class RefDataController : ControllerBase
    {
        private readonly DevCodeContext _db;

        public RefDataController(DevCodeContext context)
        {
            _db = context;
        }
        // Refecence Controller
        //
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            ReferenceData referenceData;
            try
            {
                var dao = new ReferenceDataDao(_db);
                referenceData = await dao.getAllAsync();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = ErrorUtils.dbErrorMessage("Can't get reference dataset", e)});
            }
            return Ok(referenceData);
        }
    }
}