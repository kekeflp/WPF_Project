using System.IO.Ports;

namespace IndustryApp.Communication
{
    public class SerialInfo
    {
        public string PortName { get; set; }
        /// <summary>
        /// 波特率
        /// </summary>
        public int BaudRate { get; set; } = 9600;
        /// <summary>
        /// 比特位
        /// </summary>
        public int DataBit { get; set; } = 8;
        /// <summary>
        /// 奇偶校验检查协议
        /// </summary>
        public Parity Parity { get; set; } = Parity.None;
        /// <summary>
        /// 停止位
        /// </summary>
        public StopBits StopBits { get; set; } = StopBits.One;

    }
}
