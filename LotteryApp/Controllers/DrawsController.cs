using LotteryApp.Data;
using LotteryApp.Data.Entities;
using LotteryApp.Models;
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
        public IActionResult GetDraw(int id)
        {
            var result = _drawRepository.Get(id);

            if(result == null)
            {
                return NotFound("The draw not found");
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet]
        [Route("GetDrawHistory")]
        public IActionResult GetDrawHistory()
        {
            var result = _drawRepository.GetDrawHistory();

            if (result == null)
            {
                return NotFound("Draw history not found");
            }
            else
            {
                return Ok(result);
            }
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
        public IActionResult SaveDraw([FromBody] DrawHistory drawHistory)
        {

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
