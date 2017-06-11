using System;
using Voat.Data;
using Voat.Domain.Query;
using Voat.RulesEngine;

namespace Voat.Rules.Voting
{
    [RuleDiscovery("Approved if comment is not older than 700 days", "approved = (comment.Age <= 700 days)")]
    public class DownVoteSubmissionAgeRule : VoatRule
    {
        public DownVoteSubmissionAgeRule() : base("Downvote Submission Age", "2.6", RuleScope.DownVoteSubmission)
        {
        }

        protected override RuleOutcome EvaluateRule(VoatRuleContext context)
        {
            var q = new QuerySubmission(context.SubmissionID.Value);
            var submission = q.Execute();

            // do not execute downvoting if comment is older than 700 days
            var commentPostingDate = submission.CreationDate;
            TimeSpan timeElapsed = Repository.CurrentDate - commentPostingDate;
            if (timeElapsed.TotalDays > 700)
            {
                return CreateOutcome(RuleResult.Denied, "Submission downvotes not registered after 700 days");
            }
            return base.EvaluateRule(context);
        }
    }
}
