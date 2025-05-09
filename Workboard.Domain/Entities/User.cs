﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Workboard.Domain.Entities;

public partial class User
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? EmailAddress { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}