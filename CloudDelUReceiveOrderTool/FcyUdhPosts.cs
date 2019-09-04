using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Xml;

namespace CloudDelUReceiveOrderTool
{
    public class FcyUdhPosts
    {
        /// <summary>
        /// 删除U订货上的"退款单"(K3对应:收款退款单,其他应收单,应收单)
        /// </summary>
        /// <param name="cOutSysKey"></param>
        /// <returns></returns>
        public static string Tkddel(string cOutSysKey)
        {
            string ret = "";
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("outsyskey", cOutSysKey);
            ret = FcyWeb.Post("/ws/Payments/delRefund", param);
            return ret;
        }

        /// <summary>
        /// U订货收款单删除(K3对应:收款退款单,其他应收单,应收单)
        /// </summary>
        /// <param name="cOutSysKey"></param>
        /// <returns></returns>
        public static string Zfddel(string cOutSysKey)
        {
            string ret = "";
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("cOutSysKey", cOutSysKey);
            ret = FcyWeb.Post("/ws/Payments/delPayment", param);
            return ret;
        }
    }
}
