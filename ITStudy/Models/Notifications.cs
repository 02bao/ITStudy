namespace ITStudy.Models;


public class Notifications
{
    public long Id { get; set; }
    public Student? Student { get; set; }
    public Instructors? Teacher { get; set; }
    public Courses? Course { get; set; }
    public Posts? Post { get; set; }
    public Lectures? Lecture { get; set; }
    public Favorite? Favorite { get; set; }
    public string Content { get; set; } = string.Empty;
    public Status_NotifyType? StatusNoti { get; set; }
    public Status_Sent StatusSent { get; set; } = Status_Sent.Sent;
    public DateTime?  SentAt { get; set; } = DateTime.UtcNow;
}
public enum Status_NotifyType
{
    NewPost, 
    NewCourse,
    NewLecture,
}
public enum Status_Sent
{
    Sent,
    Unread,
    Read,
}
