﻿using Voat.RulesEngine;

//rule discovery set to false, but.... can we delete this?

namespace Voat.Rules.Voting
{
    [RuleDiscovery(false, "Approved if user has more than 20 CCP.", "approved = (user.CCP >= 20)")]
    public class UpVoteRule : BaseCCPVote
    {
        public UpVoteRule() : base("UpVote Submission", "2.1", 20, RuleScope.UpVote)
        {
        }
    }
}
