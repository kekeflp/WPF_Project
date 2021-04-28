using IndustryApp.Communication;
using IndustryApp.DAL;
using IndustryApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO.Ports;

namespace IndustryApp.BLL
{
    public class IndustryBLL
    {
        /// <summary>
        /// 从配置文件App.config 获取串口信息
        /// </summary>
        public DataResult<SerialInfo> InitSerialInfo()
        {
            DataResult<SerialInfo> result = new DataResult<SerialInfo>();
            try
            {
                SerialInfo si = new SerialInfo();
                si.PortName = ConfigurationManager.AppSettings["port"].ToString();
                si.BaudRate = int.Parse(ConfigurationManager.AppSettings["baud"].ToString());
                si.DataBit = int.Parse(ConfigurationManager.AppSettings["data_bit"].ToString());
                si.Parity = (Parity)Enum.Parse(typeof(Parity), ConfigurationManager.AppSettings["parity"].ToString(), true);
                si.StopBits = (StopBits)Enum.Parse(typeof(StopBits), ConfigurationManager.AppSettings["stop_bit"].ToString(), true);

                result.State = true;
                result.Data = si;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataResult<List<Storage>> InitStorage()
        {
            DataResult<List<Storage>> result = new DataResult<List<Storage>>();
            try
            {
                DataAccess da = new DataAccess();
                result.State = true;
                result.Data = da.GetAllStorage();
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
