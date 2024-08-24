using Microsoft.AspNetCore.Mvc;
using TicTacToe.Models;

namespace TicTacToe.Controllers;

public class TicTacToeController : Controller
{
    private static TicTacToeEntity _ticTacToeEntity = new TicTacToeEntity();
    public IActionResult Index()
    {
        return View(_ticTacToeEntity);
    }
    [HttpPost]
    public IActionResult MakeMove(int row, int col)
    {
        _ticTacToeEntity.MakeMove(row, col);
        return RedirectToAction("Index");
    }
    public IActionResult Reset()
    {
        _ticTacToeEntity.ResetGame();
        return RedirectToAction("Index");
    }
}
