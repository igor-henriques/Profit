﻿namespace Profit.Application.Commands.User.Put;

public sealed record PutUserCommand : IRequest<Unit>
{
    public Guid Id { get; init; }
    public string Username { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public bool IsDeleted { get; init; }
}
