using VideoOnDemand.UI.Models.DTOModels;
using System.Collections.Generic;


namespace VideoOnDemand.UI.Models.MembershipViewModels
{
    public class CourseViewModel
    {
        public CourseDTO Course { get; set; }
        public InstructorDTO Instructor { get; set; }
        public IEnumerable<ModuleDTO> Modules { get; set; }
    }
}
