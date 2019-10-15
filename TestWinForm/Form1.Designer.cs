namespace TestWinForm
{
   partial class Form1
   {
      /// <summary>
      ///  Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      ///  Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      ///  Required method for Designer support - do not modify
      ///  the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         SuspendLayout();
         wrapButton = new System.Windows.Forms.Button();
         lstLogs = new System.Windows.Forms.ListBox();

         wrapButton.Text = "Wrap";
         wrapButton.Size = new System.Drawing.Size(100, 30);
         wrapButton.Location = new System.Drawing.Point(10, 10);
         wrapButton.Click += WrapButton_Click;

         lstLogs.Size = new System.Drawing.Size(300, 300);
         lstLogs.Location = new System.Drawing.Point(10, 50);

         this.components = new System.ComponentModel.Container();
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Text = "Form1";
         this.Controls.AddRange(new System.Windows.Forms.Control[] { wrapButton, lstLogs });

         ResumeLayout(true);
      }

      private System.Windows.Forms.Button wrapButton;
      private System.Windows.Forms.ListBox lstLogs;
      #endregion
   }
}

