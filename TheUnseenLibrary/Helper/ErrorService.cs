using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheUnseenLibrary.Helper
{
    public interface IErrorService
    {
        void ShowErrorDialog(string errorMessage);
    }

    public class ErrorService : IErrorService
    {
        private static ErrorService _instance;

        public static ErrorService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ErrorService();
                }
                return _instance;
            }
        }

        public void ShowErrorDialog(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK);
        }
    }
}
