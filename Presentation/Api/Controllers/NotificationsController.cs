using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("/api/v1/notification")]
[ApiController]
public class NotificationsController : ControllerBase
{
    private readonly INotificationSender _notificationSender;
    
    public NotificationsController(INotificationSender notificationSender)
    {
        _notificationSender = notificationSender;
    }
    
    // Priority ile ne geliştirebilirsin düşün
    // 1 service down ise başka provider a baksın 

    [HttpPost("send")]
    public async Task<IActionResult> SendNotification(SendNotificationRequest request)
    {
        if (!Enum.IsDefined(typeof(NotificationType), request.Type))
            return BadRequest("Invalid notification : " + request.Type);

        SendNotificationResponse response = await _notificationSender.Send(request);

        if (response.isDelivered)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
}