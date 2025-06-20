using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTicManageSystemApp.Data;

namespace UnicomTicManageSystemApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // முதலில் டேபிள் உருவாக்கத்தை செய்கிறோம்
            DatabaseInitializer.CreateTables();

            // அப்புறம் லாக்கின் ஃபார்மை தொடங்குகிறோம்
            Application.Run(new LoginForm());
        }
    }
}
