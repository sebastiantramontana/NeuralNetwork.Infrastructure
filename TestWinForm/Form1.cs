using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuralNetwork.Infrastructure;

namespace TestWinForm
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         InitializeComponent();
      }

      private void WrapButton_Click(object sender, System.EventArgs e)
      {
         Async.Wrap(TestAsync);
         MessageBox.Show("listo");
      }

      private bool GetFalse()
      {
         lstLogs.Items.Add("GetFalse...");
         return false;
      }
      private async Task TestAsync()
      {
         Invoke(() => { lstLogs.Items.Clear(); });
         Invoke(() =>
         {
            lstLogs.Items.Add("Begin Delay...");
         });

         await Task.Delay(2000);

         Invoke(() =>
         {
            lstLogs.Items.Add("End Delay...");
         });
      }

      private void Invoke(Action action)
      {
         this.Invoke((Delegate)action);
      }
   }
}
