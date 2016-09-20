using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Utility
{
    class MessageBoxExS
    {
        public static void ShowError(string message)
        {
            MessageBoxEx.Show(message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInfo(string message)
        {
            MessageBoxEx.Show(message, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
