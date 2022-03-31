using Newtonsoft.Json;
using StoreDiscountApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StoreDiscountApp.Services
{
    public static class Util
    {
        public static string Source { get; set; }
        private static string GetRoot<T>() where T : IEntity, new()
        {
            return AppDomain.CurrentDomain.BaseDirectory + "DB\\" + new T()?.GetType().Name?.Trim() + ".txt";
        }
        public static List<T> ReadFile<T>() where T : IEntity, new()
        {
            try
            {
                Source = GetRoot<T>();
                if (CheckDirectory(Source))
                    if (File.Exists(Source))
                    {
                        string content = string.Empty;
                        using (FileStream fsRead = new FileStream(Source, FileMode.Open, FileAccess.Read, FileShare.Read))
                        using (StreamReader srRead = new StreamReader(fsRead, Encoding.Default))
                        {
                            content = srRead.ReadToEnd();
                            srRead.Close();
                            fsRead.Close();
                            srRead.Dispose();
                            fsRead.Dispose();
                            return JsonConvert.DeserializeObject<List<T>>(content);
                        }
                    }
            }
            catch
            {
            }
            return null;
        }
        public static bool WriteFile<T>(this IList<T> content) where T : IEntity, new()
        {
            try
            {
                Source = GetRoot<T>();
                if (CheckDirectory(Source))
                    if (!File.Exists(Source))
                        File.Create(Source).Close();
                if (File.Exists(Source))
                {
                    using (FileStream fsWrite = new FileStream(Source, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                    using (StreamWriter srWrite = new StreamWriter(fsWrite, Encoding.Default))
                    {
                        srWrite.Write(JsonConvert.SerializeObject(content));
                        srWrite.Close();
                        fsWrite.Close();
                        srWrite.Dispose();
                        fsWrite.Dispose();
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="user">User</param>
        /// <param name="Round">Default : False</param>
        /// <returns>(Remainin, Discount)</returns>
        public static (decimal, decimal,decimal) CalcDiscount(decimal price, Role rol,User user, bool Round = false)
        {
            decimal discount_ = 0;
            decimal rate = 0;
            if (rol != null && user != null)
            {
                if (!rol.IsCustomer)
                {
                    rate = rol.DiscountRate;
                    discount_ = price * rate / 100;
                }
                else if (DateTime.Now > user.CreatedDate.AddYears(2) && rol.IsCustomer)
                {
                    rate = rol.DiscountRate;
                    discount_ = (Math.Floor(price / 100) * 100) * rate / 100;
                }
            }
            var discount = Round ? Math.Ceiling(discount_) : discount_;
            return (price - discount, discount,rate);
        }
        public static bool CheckDirectory(string source_)
        {
            try
            {
                var source = System.IO.Path.GetDirectoryName(source_);
                if (!Directory.Exists(source))
                {
                    Directory.CreateDirectory(source);
                    return true;
                }
                else if (Directory.Exists(source))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

    }
}
