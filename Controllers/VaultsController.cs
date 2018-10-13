

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
    public class VaultsController : Controller
    {
        VaultsRepository _repo;
        public VaultsController(VaultsRepository repo)
        {
            _repo = repo;
        }
        [Authorize]
        [HttpGet]
        public IEnumerable<Vault> Get()
        {
            var userId = HttpContext.User.Identity.Name;
            return _repo.GetAll(userId);
        }
        [Authorize]
        [HttpGet("{vaultId}")]
        public Vault GetById(int vaultId)
        {
            return _repo.GetById(vaultId);
        }
        [Authorize]
        [HttpPost]
        public Vault Post([FromBody] Vault vault)
        {
            vault.UserId = HttpContext.User.Identity.Name;
            if (ModelState.IsValid)
            {
                return _repo.Create(vault);
            }
            throw new Exception("INVALID VAULT");
        }
        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            _repo.Delete(id);
        }
    }
}