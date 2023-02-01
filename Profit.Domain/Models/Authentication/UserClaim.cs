using System;
using System.Collections.Generic;

namespace Profit.Domain.Models.Authentication;

public record UserClaim
{
    public Guid Guid { get; init; }
                                                              
    public string ClaimType { get; init; }
                                                              
    public string ClaimValue { get; init; }

    public Guid UserId { get; init; }

    public virtual User User { get; init; }
}
