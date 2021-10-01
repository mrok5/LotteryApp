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
        [Route("GetDraw")]
        public DrawHistory GetDraw(int id)
        {
           return _drawRepository.Get(id); 
        }

        [HttpGet]
        [Route("NewDraw")]
        public IEnumerable<DrawHistory> NewDraw()
        {
            return new List<DrawHistory>
            {
                new DrawHistory
                {
                    Id = 1,
                    DrawDateTime = DateTime.Now,
                    Draw = new Random().Next(50)
                }
            };
        }
    }
}
