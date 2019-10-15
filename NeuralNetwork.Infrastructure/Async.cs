using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NeuralNetwork.Infrastructure
{
   public class Async : IAsync
   {
      private Stack<SynchronizationContext> _previousContexts = new Stack<SynchronizationContext>();

      public void SuspendContext()
      {
         if (_suspendCount > 0)
         {
            _suspendCount++;
            return;
         }

         _previousContext = SynchronizationContext.Current;
         SynchronizationContext.SetSynchronizationContext(null);
         _suspendCount++;
      }

      public void RestoreContext()
      {
         if (_suspendCount != 1)
         {
            
            return;
         }

         SynchronizationContext.SetSynchronizationContext(_previousContext);
         _previousContext = null;
      }

      public async void Wrap(Func<Task> actionAsync)
      {
         SuspendContext();
         await actionAsync();
         RestoreContext();
      }
   }
}
