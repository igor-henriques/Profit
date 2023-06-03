namespace Profit.Domain.Enums;

[Flags]
public enum OrderStatus
{
    Created = 0,
    Paid = 2,
    Sent = 4,
    Delivered = 8,
    Canceled = 16
}
