﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Events;
public record ProjectCreated(Guid ProjectId, Guid UserId) : INotification;