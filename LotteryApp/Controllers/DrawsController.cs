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
        private const int Min = 1;
        private const int Max = 50;
        private const int DrawNumber = 5;
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
        [Route("GetDrawHistory")]
        public IEnumerable<DrawHistory> GetDrawHistory()
        {
            return _drawRepository.GetDrawHistory();
        }

        [HttpGet]
        [Route("NewDraw")]
        public IActionResult NewDraw()
        {
            return Ok(DrawMethod());
        }

        private static int[] DrawMethod()
        {
            var drawArray = new int[DrawNumber];

            for (var i = 0; i < DrawNumber; i++)
            {
                var draw = new Random().Next(Min, Max);

                while (drawArray.Contains(draw))
                {
                    draw = new Random().Next(Min, Max);
                }

                drawArray[i] = draw;
            }

            return drawArray;
        }

        [HttpPost]
        [Route("SaveDraw")]
        public IActionResult SaveDraw(string draw)
        {
            var drawHistory = new DrawHistory()
            {
                DrawDateTime = DateTime.Now,
                Draw = draw
            };

            if (_drawRepository.SaveDraw(drawHistory))
            {
                return Ok("The draw saved to database");
            }
            else
            {
                return BadRequest("Failed to save new draw");
            }

        }
    }
}
