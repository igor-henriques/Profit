using System;
using System.Collections.Generic;

namespace Profit.Domain.Models.Authentication;

public partial class AspNetRole
{
    public string Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<AspNetUser> Users { get; } = new List<AspNetUser>();
}
