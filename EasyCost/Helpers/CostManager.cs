﻿using EasyCost.Bases.Login;
using EasyCost.Databases;
using EasyCost.Databases.TableModels;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCost.Helpers
{
    public static class CostManager
    {
        public static List<CostInfo> GetCostInfo(bool aSelectGroupBy = false)
        {
            if (aSelectGroupBy)
            {
                return (from c in DBConnHandler.DbConnection.Table<CostInfo>()
                        where c.UserID == LoginInfo.UserID
                        group c by new { CostDate = c.CostDate.ToString("yyyyMMdd"), c.Category, c.SubCategory, c.CostType }
                        into result
                        orderby result.Key.Category, result.Key.SubCategory, result.Key.CostType
                        select new CostInfo
                        {
                            CostDate = DateTime.ParseExact(result.Key.CostDate, "yyyyMMdd", null),
                            Category = result.Key.Category,
                            SubCategory = result.Key.SubCategory,
                            CostType = result.Key.CostType,
                            Cost = result.Sum(c => c.Cost)
                        }).ToList();
            }
            else
            {
                return (from c in DBConnHandler.DbConnection.Table<CostInfo>()
                        where c.UserID == LoginInfo.UserID
                        orderby c.CostDate descending
                        select c).ToList();
            }
        }

        public static void SaveConstInfo(CostInfo aCostInfo)
        {
            DBConnHandler.DbConnection.Insert(aCostInfo);
        }
        public static void UpdateCostInfo(CostInfo aCostInfo)
        {
            DBConnHandler.DbConnection.Update(aCostInfo);
        }
        public static void DeleteCostInfo(CostInfo aCostInfo)
        {
            DBConnHandler.DbConnection.Delete(aCostInfo);
        }
        public static void DeleteCostInfo(int aID)
        {
            DBConnHandler.DbConnection.Execute(string.Format("DELETE FROM CostInfo WHERE Id = {0}", aID));
        }
    }
}
