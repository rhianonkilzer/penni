

using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaultKeepsController : Controller
    {
        VaultKeepsRepository _repo;

        public VaultKeepsController(VaultKeepsRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("{vaultId}")]
        public IEnumerable<Keep> Get(string vaultId)
        {

            return _repo.GetAll(vaultId);
        }


        [Authorize]
        [HttpPost]
        public void Create([FromBody]VaultKeep vk)
        {
            vk.UserId = HttpContext.User.Identity.Name;
            if (ModelState.IsValid)
            {
                _repo.Create(vk);
                return;
            }
            throw new Exception("INVALID VaultKeep");
        }


        [HttpPut]
        public void DeleteVaultKeep([FromBody]VaultKeep vk)
        {
            if (ModelState.IsValid)
            {
                _repo.Delete(vk);
            }
        }

    }
}