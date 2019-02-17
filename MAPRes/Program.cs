using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MAPRes
{
    class MAPresApplication
    {

        private static MAPResWnd _mainframe;
        private static WorkSpace _workspace;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            using (_workspace = new WorkSpace())
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                using (_mainframe = new MAPResWnd())
                {
                    Application.Run(_mainframe);
                }
            }
        }

        public static Form MainFrame
        {
            get {
                return _mainframe;
            }
        }

        public static WorkSpace Workspace
        {
            get
            {
                return _workspace;
            }
        }
    }
        
}