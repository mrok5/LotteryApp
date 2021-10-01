using LotteryApp.Data;
using LotteryApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryApp.Controllers
{
    [Route("api/[Controller]")]
    public class DrawsController : Controller
    {
        private readonly IDrawRepository _drawRepository;
        public DrawsController(IDrawRepository drawRepository)
        {
            _drawRepository = drawRepository;
        }

        [HttpGet]
        public DrawHistory Get(int id) => _drawRepository.Get(id);
    }
}
