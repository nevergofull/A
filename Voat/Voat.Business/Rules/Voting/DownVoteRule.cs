using Voat.RulesEngine;

//oise can we fucking delete this?  any dependencies? oyyy

namespace Voat.Rules.Voting
{
    [RuleDiscovery("Approved if user has 100 CCP or higher.", "approved = (user.CCP >= 100)")]
    public class DownVoteRule : BaseCCPVote
    {
        public DownVoteRule() : base("Downvote", "2.2", 100, RuleScope.DownVote)
        {
        }
    }
}
