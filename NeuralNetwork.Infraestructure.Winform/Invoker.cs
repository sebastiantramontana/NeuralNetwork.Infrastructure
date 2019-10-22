using System;
using System.Windows.Forms;

namespace NeuralNetwork.Infrastructure.Winform
{
   public class Invoker : IInvoker
   {
      private readonly Control _control;

      public Invoker(Control control)
      {
         _control = control;
      }
      public void SafeInvoke(Action action)
      {
         if (_control.IsHandleCreated && !_control.IsDisposed)
         {
            if (_control.InvokeRequired)
            {
               _control.Invoke(action);
            }
            else
            {
               action();
            }
         }
      }

      public T SafeInvoke<T>(Func<T> action)
      {
         return (_control.InvokeRequired ? (T)_control.Invoke(action) : action());
      }
   }
}
