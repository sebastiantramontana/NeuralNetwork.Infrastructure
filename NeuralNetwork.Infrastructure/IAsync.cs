using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Infrastructure
{
   public interface IAsync
   {
      void SuspendContext();
      void RestoreContext();
      void Wrap(Func<Task> actionAsync);
      Task Run(Action action);
      Task<T> Run<T>(Func<T> func);
   }
}
