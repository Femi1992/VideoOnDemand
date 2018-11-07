using System.Collections.Generic;
using VideoOnDemand.Data.Data.Entities;

namespace VideoOnDemand.Data.Repositories
{
    public interface IReadRepository
    {
        IEnumerable<Course> GetCourses(string userId);
    

    }
}
