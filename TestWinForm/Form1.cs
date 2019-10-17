using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuralNetwork.Infrastructure;

namespace TestWinForm
{
   public partial class Form1 : Form
   {
      private readonly IAsync _async;
      public Form1()
      {
         InitializeComponent();
         _async = new Async(Log);
      }

      private void WrapButton_Click(object sender, System.EventArgs e)
      {
         lstLogs.Items.Clear();

         _async.Wrap(TestAsyncWrap);

         Invoke(() =>
         {
            lstLogs.Items.Add("OK Wrap...");
         });
      }

      private void RunActionButton_Click(object sender, System.EventArgs e)
      {
         lstLogs.Items.Clear();

         _async.Run(TestAsyncRunAction);

         Invoke(() =>
         {
            lstLogs.Items.Add("OK Run Action...");
         });
      }

      private async void RunAFunctionButton_Click(object sender, System.EventArgs e)
      {
         lstLogs.Items.Clear();

         var value = await _async.Run(TestAsyncRunFunction);

         Invoke(() =>
         {
            lstLogs.Items.Add($"OK Run Function = {value}");
         });
      }

      private async Task TestAsyncWrap()
      {
         Invoke(() =>
         {
            lstLogs.Items.Add("Begin Delay Wrap...");
         });

         await Task.Delay(2000);

         Invoke(() =>
         {
            lstLogs.Items.Add("End Delay Wrap...");
         });
      }
      private void TestAsyncRunAction()
      {
         Invoke(() =>
         {
            lstLogs.Items.Add("Begin Delay Run Action...");
         });

         Thread.Sleep(2000);

         Invoke(() =>
         {
            lstLogs.Items.Add("End Delay Run Action...");
         });
      }

      private int TestAsyncRunFunction()
      {
         Invoke(() =>
         {
            lstLogs.Items.Add("Begin Delay Run Function...");
         });

         Thread.Sleep(2000);

         Invoke(() =>
         {
            lstLogs.Items.Add("End Delay Run Function...");
         });

         return 100;
      }

      private void Log(string msg)
      {
         Invoke(() =>
         {
            lstLogs.Items.Add(msg);
         });
      }
      private void Invoke(Action action)
      {
         this.Invoke((Delegate)action);
      }
   }
}
