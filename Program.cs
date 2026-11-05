
using System;
using System.Windows.Forms;

namespace Lab2
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            new LoginForm().Show();
            Application.Run(); // runs until Application.Exit() is called
        }
    }
}