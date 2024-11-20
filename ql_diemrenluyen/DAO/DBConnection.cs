﻿using MySql.Data.MySqlClient;

namespace ql_diemrenluyen.DAO
{
    internal class DBConnection
    {
        private static readonly string server = "localhost";
        private static readonly string database = "ql_diemrenluyen";
        private static readonly string user = "root";
        private static readonly string password = "";
        private static MySqlConnection conn;

        // Mở kết nối
        //mysql://qldiemrenluyen_luckcannot:5b5da6800d9ca2e6965a15512aa00a8d8ff3216c@r3qqk.h.filess.io:3307/qldiemrenluyen_luckcannot
        //private static readonly string uri = "mysql://qldiemrenluyen_luckcannot:5b5da6800d9ca2e6965a15512aa00a8d8ff3216c@r3qqk.h.filess.io:3307/qldiemrenluyen_luckcannot";
        //private static MySqlConnection conn;

        //// Mở kết nối
        //public static bool Open()
        //{
        //    try
        //    {
        //        // Tách chuỗi URI thành các thành phần cấu hình
        //        var builder = new MySqlConnectionStringBuilder
        //        {
        //            Server = "r3qqk.h.filess.io",
        //            Database = "qldiemrenluyen_luckcannot",
        //            UserID = "qldiemrenluyen_luckcannot",
        //            Password = "5b5da6800d9ca2e6965a15512aa00a8d8ff3216c",
        //            Port = 3307,
        //            AllowPublicKeyRetrieval = true, // Cho phép lấy khóa công khai
        //            SslMode = MySqlSslMode.None      // Tùy chọn SSL nếu cần
        //        };

        //        conn = new MySqlConnection(builder.ConnectionString);
        //        conn.Open();
        //        return true;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        Console.WriteLine("Error opening connection: " + ex.Message);
        //        return false;
        //    }
        //}

        //// Đóng kết nối
        //private static void Close()
        //{
        //    try
        //    {
        //        conn?.Close();
        //    }
        //    catch (MySqlException ex)
        //    {
        //        Console.WriteLine("Error closing connection: " + ex.Message);
        //    }
        //}

        public static bool Open()
        {
            try
            {
                string connstring = $"Server={server}; Database={database}; UID={user}; Password={password}; Port=3309; Convert Zero Datetime = true";

                conn = new MySqlConnection(connstring);
                conn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error opening connection: " + ex.Message);
                return false;
            }
        }

        // Đóng kết nối
        private static void Close()
        {
            try
            {
                conn?.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error closing connection: " + ex.Message);
            }
        }

        // Thực thi câu lệnh đọc dữ liệu với string
        public static List<List<object>> ExecuteReader(string sql)
        {
            var table = new List<List<object>>();
            if (Open())
            {
                try
                {
                    var cmd = new MySqlCommand(sql, conn);
                    var rd = cmd.ExecuteReader();
                    int size = rd.FieldCount;
                    while (rd.Read())
                    {
                        var row = new List<object>();
                        for (int i = 0; i < size; i++)
                        {
                            row.Add(rd.GetValue(i));
                        }
                        table.Add(row);
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error executing reader: " + ex.Message);
                    return new List<List<object>>();
                }
                finally
                {
                    Close();
                }
            }
            return table;
        }

        // Thực thi câu lệnh đọc dữ liệu với MySqlCommand
        public static List<List<object>> ExecuteReader(MySqlCommand cmd)
        {
            var table = new List<List<object>>();
            if (Open())
            {
                try
                {
                    cmd.Connection = conn; // Gán kết nối cho lệnh
                    var rd = cmd.ExecuteReader();
                    int size = rd.FieldCount;

                    while (rd.Read())
                    {
                        var row = new List<object>();
                        for (int i = 0; i < size; i++)
                        {
                            row.Add(rd.GetValue(i));
                        }
                        table.Add(row);
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error executing reader: " + ex.Message);
                    return new List<List<object>>();
                }
                finally
                {
                    Close();
                }
            }
            return table;
        }

        // Thực thi câu lệnh không trả về kết quả
        public static int ExecuteNonQuery(MySqlCommand cmd)
        {
            if (Open())
            {
                try
                {
                    cmd.Connection = conn; // Gán kết nối cho lệnh
                    return cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error executing non-query: " + ex.Message);
                    return -1;
                }
                finally
                {
                    Close();
                }
            }
            return -1;
        }

        // Thực thi câu lệnh trả về một giá trị đơn
        public static object ExecuteScalar(string sql)
        {
            if (Open())
            {
                try
                {
                    var cmd = new MySqlCommand(sql, conn);
                    var result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? result : null;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error executing scalar: " + ex.Message);
                    return null;
                }
                finally
                {
                    Close();
                }
            }
            return null;
        }
    }
}