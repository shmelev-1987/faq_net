using System;
using System.Drawing;
using System.Windows.Forms;

namespace FAQ_Net
{
    public class MainApp
    {
        //public const string DISPLAY_NAME = "FAQ.Net v." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm mainForm = new MainForm();
            object location = null;
            if (args.Length > 0)
            {
               
                if (args[0].StartsWith("prev_instance:"))
                {
                    // User clicked "New". Get location of previous 
                    // instance and open new form slightly lower
                    // and to the right of previous form, unless
                    // previous form's Window State is maximized.
                    Point prevLoc = new Point();
                    try
                    {
                        PointConverter pc = new PointConverter();
                        prevLoc = (Point)(pc.ConvertFromString(args[0].Substring(14)));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //
                    if (prevLoc.X > 0)
                    {
                        // Open new form slightly lower and
                        // to the right of previous form.
                        location = new Point(prevLoc.X + 35, prevLoc.Y + 35);
                        mainForm.StartPosition = FormStartPosition.Manual;
                       // mainForm.GetSettings(new Point(prevLoc.X + 35, prevLoc.Y + 35));
                    }
                }
                else
                {                    
                    mainForm.GetSettings(null);
                    // Windows Explorer selected this application
                    // to open a file. The first argument should
                    // be the path of the file to open.
                    mainForm.OpenFile(args[0]);
                }
            }
            mainForm.GetSettings(location);
            Application.Run(mainForm);
        }
    }
}