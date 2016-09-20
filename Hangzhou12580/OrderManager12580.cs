using HospitalRegisterSoftware.Register.Model;

namespace Hangzhou12580
{
    public class OrderManager12580 : OrderManager
    {
        public OrderManager12580()
        {
            OrderAuthCodeFormat = "hospitalId={0}&numId={1}&time={2}";
            CheckOrderAuthCodeFormat = "hospitalId={0}&numId={1}&cap={2}&time={3}";
        }

        public override string GetCheckOderPostData()
        {
            OrderInfo orderInfo = OrderInfos[m_nSelectedOrderIndex];
            return string.Format(CheckOrderPostUrlFormat, new object[]
            {
                    orderInfo.OrderId,
                    orderInfo.OrderTime,
                    orderInfo.OrderNum,
                    string.Concat(new string[]
                    {
                        orderInfo.OrderId,
                        ",",
                        orderInfo.OrderTime,
                        ",",
                        orderInfo.OrderNum
                    })
            });
        }

        public override string GetOrderAuthCodeData()
        {
            return string.Format(OrderAuthCodeFormat,
                    Doctor.HospitalId, OrderInfos[m_nSelectedOrderIndex].OrderId, Common.GetLocalTime());
        }

        public override string GetCheckOrderAuthCodeData(string authCode)
        {
            return string.Format(CheckOrderAuthCodeFormat, new object[]
                 {
                    Doctor.HospitalId, OrderInfos[m_nSelectedOrderIndex].OrderId, authCode, Common.GetLocalTime()
                 });
        }   
    }
}
