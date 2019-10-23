using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuralNetwork.Infrastructure;
using NeuralNetwork.Infrastructure.Winform;

namespace TestWinForm
{
   public partial class Form1 : Form
   {
      private readonly IAsync _async;
      private readonly IInvoker _invoker;

      public Form1()
      {
         InitializeComponent();
         _async = new Async();
         _invoker = new Invoker(this);
      }

      private void WrapButton_Click(object sender, System.EventArgs e)
      {
         lstLogs.Items.Clear();

         _async.Wrap(TestAsyncWrap);

         _invoker.SafeInvoke(() =>
         {
            lstLogs.Items.Add("OK Wrap...");
         });
      }

      private void RunActionButton_Click(object sender, System.EventArgs e)
      {
         lstLogs.Items.Clear();

         _async.Run(TestAsyncRunAction);

         _invoker.SafeInvoke(() =>
         {
            lstLogs.Items.Add("OK Run Action...");
         });
      }

      private async void RunAFunctionButton_Click(object sender, System.EventArgs e)
      {
         lstLogs.Items.Clear();

         var value = await _async.Run(TestAsyncRunFunction);

         _invoker.SafeInvoke(() =>
         {
            lstLogs.Items.Add($"OK Run Function = {value}");
         });
      }

      private async Task TestAsyncWrap()
      {
         _invoker.SafeInvoke(() =>
         {
            lstLogs.Items.Add("Begin Delay Wrap...");
         });

         await Task.Delay(2000);

         _invoker.SafeInvoke(() =>
         {
            lstLogs.Items.Add("End Delay Wrap...");
         });
      }
      private void TestAsyncRunAction()
      {
         _invoker.SafeInvoke(() =>
         {
            lstLogs.Items.Add("Begin Delay Run Action...");
         });

         Thread.Sleep(2000);

         _invoker.SafeInvoke(() =>
         {
            lstLogs.Items.Add("End Delay Run Action...");
         });
      }

      private int TestAsyncRunFunction()
      {
         _invoker.SafeInvoke(() =>
         {
            lstLogs.Items.Add("Begin Delay Run Function...");
         });

         Thread.Sleep(2000);

         _invoker.SafeInvoke(() =>
         {
            lstLogs.Items.Add("End Delay Run Function...");
         });

         return 100;
      }
   }
}
