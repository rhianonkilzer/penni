

using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    public class VaultKeepsController : Controller
    {
        VaultKeepsRepository _repo;

        public VaultKeepsController(VaultKeepsRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IEnumerable<VaultKeep> Get()
        {
            return _repo.GetAll();
        }

    }
}