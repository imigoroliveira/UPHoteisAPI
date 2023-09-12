using Microsoft.AspNetCore.Mvc;
using UPHoteisAPI.Models;

namespace UPHoteisAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ReservationController : ControllerBase
{
    private readonly ILogger<ReservationController> _logger;
    public ReservationController(ILogger<ReservationController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetReservation")]
    public IEnumerable<Reservation> Get()
    {
        List<Reservation> reservationList = new()
        {
            new Reservation(1, DateTime.Now, DateTime.Now.AddDays(1), 1, 1234.5678M, "Pendente", "Fulano da Silva", "Rua dos Bobos, 0", "1234567890"),
            new Reservation(2, DateTime.Now.AddDays(2), DateTime.Now.AddDays(3), 2, 2345.6789M, "Beltrano de Souza", "Rua dos Santos, 1", "9876543210")
        };
        return reservationList;
    }
}