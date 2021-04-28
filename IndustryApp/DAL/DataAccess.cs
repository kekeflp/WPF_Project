using IndustryApp.Data;
using IndustryApp.Models;
using System;
using System.Collections.Generic;

namespace IndustryApp.DAL
{
    public class DataAccess
    {
        public List<Storage> GetAllStorage()
        {
            var dr = AccessDbHelper.SelectDataReader("select * from Storage;");
            List<Storage> storages = new List<Storage>();
            while (dr.Read())
            {
                Storage storage = new Storage();
                storage.Id = dr["Id"].ToString();
                storage.SlaveAddress = Convert.ToInt32(dr["Id"].ToString());
                storage.FuncCode = dr["Id"].ToString();
                storage.StartAddress = Convert.ToInt32(dr["Id"].ToString());
                storage.Length = Convert.ToInt32(dr["Id"].ToString());
                storages.Add(storage);
            }
            return storages;
        }
    }
}
