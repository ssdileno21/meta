using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testeMeta.lib
{
    public static class util
    {
        #region Messages
            public static bool MetaMessageBtn(string pMens, string pCaption)
            {
                bool vVal = false;
    
                if (pMens != "")
                {
                    if (pCaption == "")
                        pCaption = "Atenção";

                    DialogResult result = 
                        (MessageBox.Show(pMens, pCaption, 
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning));

                    if (result == DialogResult.Yes)
                    {
                        vVal = true;
                    } else
                        vVal = false;                    
                }
                return vVal;
            }
        #endregion

        #region TextBox
            public static void CurrencyFormat(ref TextBox txt)
            {
                string n = string.Empty;
                double v = 0.00;
                try
                {
                    n = txt.Text.Replace(",", "").Replace(".", "");
                    if (n.Equals(""))
                        n = "";
                    n = n.PadLeft(3, '0');
                    if (n.Length > 3 & n.Substring(0,1) == "0")
                        n = n.Substring(1, n.Length - 1);
                    v = Convert.ToDouble(n) / 100;
                    txt.Text = string.Format("{0:N}", v);
                    txt.SelectionStart = txt.Text.Length;

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }        
            }
        #endregion

        #region Controll
            public static void ClearAll(Control.ControlCollection pcontroll)
            {
                foreach (Control ctrl in pcontroll)
                {
                    if (ctrl is TextBox)
                    {
                        ((TextBox)(ctrl)).Text = String.Empty;
                    }
                }
            }
        #endregion
    }
}
