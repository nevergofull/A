using System;
using Voat.Data;
using Voat.Domain.Query;
using Voat.RulesEngine;

namespace Voat.Rules.Voting
{
    [RuleDiscovery("Approved if comment is not older than 700 days", "approved = (comment.Age <= 700 days)")]
    public class DownVoteCommentAgeRule : VoatRule
    {
        public DownVoteCommentAgeRule() : base("Downvote Comment Age", "2.5", RuleScope.DownVoteComment)
        {
        }

        protected override RuleOutcome EvaluateRule(VoatRuleContext context)
        {
            var q = new QueryComment(context.CommentID.Value);
            var comment = q.Execute();

            // do not execute downvoting if comment is older than 700 days; suck it sjw puttitout!
            var commentPostingDate = comment.CreationDate;
            TimeSpan timeElapsed = Repository.CurrentDate - commentPostingDate;
            if (timeElapsed.TotalDays > 700)
            {
                return CreateOutcome(RuleResult.Denied, "Comment downvotes not registered after 700 days");
            }
            return base.EvaluateRule(context);
        }
    }
}
