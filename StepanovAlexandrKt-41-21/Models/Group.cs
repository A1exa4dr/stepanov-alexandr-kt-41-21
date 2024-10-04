using System.Text.RegularExpressions;

namespace StepanovAlexandrKt_41_21.Models
{
    public class Group
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public bool IsValidGroupName()
        {
            return Regex.Match(GroupName, @"\D*-\d*-\d\d").Success;
        }
    }
}
