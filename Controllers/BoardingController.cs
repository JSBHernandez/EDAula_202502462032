using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class BoardingController : Controller
{
    private readonly BoardingService _boardingService;

    public BoardingController(BoardingService boardingService)
    {
        _boardingService = boardingService;
    }

    // GET: /Boarding/Order/{trainId}
    [HttpGet("Boarding/Order/{trainId}")]
    public IActionResult GetBoardingOrder(int trainId)
    {
        var boardingOrder = _boardingService.GetBoardingOrder(trainId);
        if (boardingOrder == null || boardingOrder.Count == 0)
        {
            return NotFound("No se encontraron boletos para este tren.");
        }
        return Ok(boardingOrder);
    }
}