using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noggog
{
    /// <summary>
    /// A typeless TaskCompletionSource
    /// </summary>
    public class TaskCompletionSource : TaskCompletionSource<bool>
    {
        /// <summary>
        /// Transitions the underlying Task into the RanToCompletion state.
        /// </summary>
        public void Complete()
        {
            this.SetResult(true);
        }
    }
}
