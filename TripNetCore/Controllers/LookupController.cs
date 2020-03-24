using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripNetCore.DAL;
using TripNetCore.DAL.DbModels;
using TripNetCore.Models;

namespace TripCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly DevCodeContext _db;

        public LookupController(DevCodeContext context)
        {
            _db = context;
        }

        // /api/Lookup/Iata/aa
        //[HttpGet]
        // [EnableCors("MyPolicy")]
        [Route("Iata/{term}")]
        public LookupItem[] Iata(string term)
        {
            var lookupDao = new LookupDao(_db);
            return lookupDao.airportsByIata(term);
        }
    }
}