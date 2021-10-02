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
        [Route("GetDrawHistory")]
        public IEnumerable<DrawHistory> GetDrawHistory()
        {
            return _drawRepository.GetDrawHistory();
        }

        [HttpGet]
        [Route("NewDraw")]
        public IActionResult NewDraw()
        {
            try
            {
               return Ok(_drawRepository.DrawMethod());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
