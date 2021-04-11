

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wage.Core.Entities
{
    public class GroupManager: BaseModel
    {
        public GroupManager()
        {
            GroupManagerDetails = new HashSet<GroupManagerDetails>();
            GroupManagerSchedules = new HashSet<GroupManagerSchedule>();
        }

        public string ProfCode { get; set; }
        public string ProfName { get; set; }
        public string BaseAmount { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string StartAt { get; set; }
        public bool ChkCouncil { get; set; } = false;
        public string CouncilDate{ get; set; }

        public ICollection<GroupManagerDetails> GroupManagerDetails { get; set; }
        public ICollection<GroupManagerSchedule> GroupManagerSchedules { get; set; }
    }
}
