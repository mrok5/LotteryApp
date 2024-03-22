using LotteryApp.Data.Entities;
using LotteryApp.Data.Repository;
using LotteryApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpGet("GetDraw")]
        public IActionResult GetDraw(int id)
        {
            var result = _drawRepository.Get(id);
            return result == null ? NotFound("The draw not found") : Ok(result);
        }

        [HttpGet("DrawHistory")]
        public IActionResult GetDrawHistory()
        {
            var result = _drawRepository.GetDrawHistory();
            return result == null ? NotFound("Draw history not found") : Ok(result);
        }

        [HttpGet("NewDraw")]
        public IActionResult NewDraw()
        {
            try
            {
                return Ok(_drawRepository.DrawMethod());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveDraw")]
        public IActionResult SaveDraw([FromBody] DrawRequest drawRequest)
        {
            var drawHistory = new DrawHistory
            {
                DrawDateTime = DateTime.Now,
                Draw = string.Join(",", drawRequest.Draw)
            };

            return _drawRepository.SaveDraw(drawHistory)
                ? Ok("The draw saved to the database")
                : BadRequest("Failed to save the draw");
        }
    }
}
