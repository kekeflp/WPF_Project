using CourseManagement.Models;
using System.Collections.Generic;

namespace CourseManagement.Services
{
    public interface IPlatformService
    {
        List<Platform> GetPlatformsAll();
        Platform GetPlatformById(string id);
    }
}
