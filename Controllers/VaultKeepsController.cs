

using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
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

    }
}