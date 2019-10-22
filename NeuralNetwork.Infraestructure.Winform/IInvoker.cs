using System;

namespace NeuralNetwork.Infrastructure.Winform
{
   public interface IInvoker
   {
      void SafeInvoke(Action action);
      T SafeInvoke<T>(Func<T> action);
   }
}
