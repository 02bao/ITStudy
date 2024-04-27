using ITStudy.Models;

namespace ITStudy.Interface
{
    public interface INotiRepository
    {
        void SendNotiForPosts(Instructors Teachers, Posts Post);
        void SendNotiForCourses(Instructors Teachers, Courses Course);
        void SendNotiForLectures(Courses Courses, Lectures Lecture);
    }
}
