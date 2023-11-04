using Suls.ViewModels.Submissions;
using System.Collections.Generic;

namespace Suls.ViewModels.Problems
{
    public class DetailsProblemViewModel
    {
        public string Name { get; set; }

        public IEnumerable<DetailsSubmissionViewModel> Submissions { get; set; }
    }
}
