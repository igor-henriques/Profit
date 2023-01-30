using System;
using System.Collections.Generic;

namespace Profit.Domain.Models.Authentication;

public partial class AspNetUser
{
    public string Id { get; set; }

    public string UserName { get; set; }

    public string PasswordHash { get; set; }

    public string SecurityStamp { get; set; }

    public string Discriminator { get; set; }

    public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; } = new List<AspNetUserClaim>();

    public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; } = new List<AspNetUserLogin>();

    public virtual ICollection<AspNetRole> Roles { get; } = new List<AspNetRole>();
}
