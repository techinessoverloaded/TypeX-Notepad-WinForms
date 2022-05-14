using System;
using System.Windows.Forms;

namespace Typex_Notepad
{
	internal static class Program
	{
		[STAThread]
		private static void Main(string[] Args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
            if (Args.Length == 0)
            {
                Application.Run(new Form1());

            }
            else
            {
                
                for (int i = 0; i < Args.Length; i++)
                {
                    Form1 newform1 = new Form1();
                    try
                    {
                        newform1.TextBox1.Text = System.IO.File.ReadAllText(Args[i]);
                        newform1.filepath = Args[i];
                        newform1.Text = "Typex Notepad - " + Args[i];
                        newform1.autosaveToolStripMenuItem.Checked = false;
                        newform1.TextBox1.Select(0, 0);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Typex Notepad", MessageBoxButtons.OK);
                    }
                    Application.Run(newform1);
                }
            }
		}
	}
}