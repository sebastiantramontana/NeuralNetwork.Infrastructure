using System;
using System.Threading;
using System.Threading.Tasks;

namespace NeuralNetwork.Infrastructure
{
   public class Async : IAsync
   {
      private int _suspendCount = 0;
      private SynchronizationContext _previousContext;

      public Async()
      {
      }

      public void SuspendContext()
      {
         if (_suspendCount > 0)
         {
            if (SynchronizationContext.Current != null)
            {
               SynchronizationContext.SetSynchronizationContext(null);
            }

            _suspendCount++;
            return;
         }

         _suspendCount++;

         _previousContext = SynchronizationContext.Current;
         SynchronizationContext.SetSynchronizationContext(null);
      }

      public void RestoreContext()
      {
         if (_suspendCount < 0)
         {
            return;
         }

         if (_suspendCount > 1)
         {
            _suspendCount--;
            return;
         }

         _suspendCount = 0;
         SynchronizationContext.SetSynchronizationContext(_previousContext);
         _previousContext = null;
      }

      public async void Wrap(Func<Task> actionAsync)
      {
         SuspendContext();
         await actionAsync();
         RestoreContext();
      }

      public async Task Run(Action action)
      {
         SuspendContext();
         await Task.Run(action);
         RestoreContext();
      }

      public async Task<T> Run<T>(Func<T> func)
      {
         SuspendContext();
         T value = await Task.Run(func);
         RestoreContext();

         return value;
      }
   }
}
