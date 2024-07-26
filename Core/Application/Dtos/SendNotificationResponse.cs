namespace Application.Dtos;

public record SendNotificationResponse(bool isDelivered, string message);