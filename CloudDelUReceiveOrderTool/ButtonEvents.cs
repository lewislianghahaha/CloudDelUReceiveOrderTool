using System;
using fcydata;
using Kingdee.BOS.Core.Bill.PlugIn;
using Kingdee.BOS.Core.DynamicForm.PlugIn.Args;

namespace CloudDelUReceiveOrderTool
{
    public class ButtonEvents : AbstractBillPlugIn
    {
        public override void BarItemClick(BarItemClickEventArgs e)
        {
            //订单退回操作
            base.BarItemClick(e);

            var resultMessage = string.Empty;

            //删除U订货收款单
            if (e.BarItemKey == "tbDelUOrderB")
            {
                //定义获取表头信息对像
                var docScddIds1 = View.Model.DataObject;
                //获取表头中单据编号信息(注:这里的BillNo为单据编号中"绑定实体属性"项中获得)
                var dhstr = docScddIds1["BillNo"].ToString();

                fcy.Service.CnnStr = "http://172.16.4.252/websys/service.asmx";
                fcy.Service.userdmstr = "feng";
                fcy.Service.passwordstr = "";

                //将获取的单据名称进行截取,取前两位
                var orderno = dhstr.Substring(0, 2);

                //根据获取的标记分别进行单据删除
                switch (orderno)
                {
                    //其他应收单
                    case "QT":
                        resultMessage = DelReturnOrder(dhstr);
                        break;
                    //收款退款单
                    case "SK":
                        resultMessage = DelReturnOrder(dhstr);
                        break;
                    //应收单
                    case "AR":
                        resultMessage = DelReturnOrder(dhstr);
                        break;
                }
                //输出结果
                View.ShowMessage(resultMessage);
            }
        }

        /// <summary>
        /// 删除收款退款单
        /// </summary>
        /// <param name="orderno"></param>
        /// <returns></returns>
        private string DelReturnOrder(string orderno)
        {
            var result = string.Empty;

            try
            {
                result = FcyUdhPosts.Zfddel(orderno);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

    }
}
