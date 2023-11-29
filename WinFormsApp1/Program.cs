
namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // You can configure Entity Framework and ChatGPT integration here.
            // For simplicity, let's assume you've already configured your context.

            Application.Run(new Form1());
        }
    }
}