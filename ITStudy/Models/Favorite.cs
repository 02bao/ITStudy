﻿namespace ITStudy.Models;

public class Favorite
{
    public long Id { get; set; }
    public Student? Student { get; set; }
    public Courses? Course { get; set; }
    public Instructors? Teacher { get; set; }
    public bool IsReal { get; set; } = false; //true la da thic, false la chua
    public DateTime? CreateAt { get; set; } = DateTime.UtcNow;
    public Status_Favorite Status { get; set; } = Status_Favorite.None;
}

public enum Status_Favorite
{
    None,
    Follow,
    Unfollow
}

public class Favorite_Teacher
{
    public bool IsReal { get; set; } = false; //true la da thic, false la chua
    public DateTime? CreateAt { get; set; } = DateTime.UtcNow;
    public Status_Favorite Status { get; set; } = Status_Favorite.None;
}
