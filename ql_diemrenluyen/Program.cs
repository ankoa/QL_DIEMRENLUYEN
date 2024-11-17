using ql_diemrenluyen.GUI.ADMIN;
using ql_diemrenluyen.GUI.ADMIN.Statistic;
using ql_diemrenluyen.GUI.USER;
namespace ql_diemrenluyen
{
    internal static class Program
    {
        public static string nguoidung_id = "1";
        public static string role = "Cố vấn";
        //public static string nguoidung_id = "1";
        //public static string role = "Sinh Viên";
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new chamdrl());
            //Application.Run(new Thongke()); // or Application.Run(new AdminStudentTest());

        }
    }
}
