﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Users.Entities;
public class UserProfile
{
    public Guid UserId { get; set; }
    public string UserName { get; set; } = default!;
    public string AvatarUrl { get; set; } = "https://res.cloudinary.com/default-placeholder";
    public string? Bio { get; set; }
    public string Location { get; set; } = string.Empty;
    public int TotalProjects { get; set; }
    public int TotalLikesReceived { get; set; }
}