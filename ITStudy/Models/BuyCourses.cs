﻿namespace ITStudy.Models;

public class BuyCourses
{
    public long Id { get; set; }
    public List<CartItem> List_CartItems { get; set; }
    public Student Student { get; set; }
    public Instructors Teacher { get; set; }
    public DateTime? PurchasedTime { get; set; } = DateTime.UtcNow;
    public string CourseName { get; set; } = string.Empty;
    public long PriceCourse { get; set; } = 0;
    public long TotalAmount { get; set; } = 0;
    public Status_Buy Status { get; set; } = Status_Buy.pending;

}

public enum Status_Buy
{
    pending,
    completed
}