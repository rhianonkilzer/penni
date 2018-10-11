using keepr.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;


namespace keepr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeepsController : Controller
    {

        KeepsRepository _repo;
        public KeepsController(KeepsRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Keep> Get()
        {
            return _repo.GetAll();
        }
        [Authorize]
        [HttpPost]
        public Keep Post([FromBody] Keep keep)
        {
            if (ModelState.IsValid)
            {
                keep.UserId = HttpContext.User.Identity.Name;
                return _repo.Create(keep);
            }
            throw new Exception("INVALID Keep");
        }
    }
}