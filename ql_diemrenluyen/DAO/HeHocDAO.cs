using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ql_diemrenluyen.DTO;
using MySql.Data.MySqlClient;

namespace ql_diemrenluyen.DAO
{
    public class HeHocDAO
    {
        public static List<HeHocDTO> getAllHeHoc()
        {
            List<HeHocDTO> list = new List<HeHocDTO>();
            String sql = "SELECT * FROM hehoc";
            List<List<object>> result = DBConnection.ExecuteReader(sql);
            foreach(var row in result)
            {
                HeHocDTO hehoc = new HeHocDTO
                {
                    Id = Convert.ToInt32(row[0]),
                    Name = Convert.ToString(row[1]),
                    status = Convert.ToInt16(row[2])
                };
                list.Add(hehoc);
            }
            return list;
        }
        public static bool AddHeHoc(HeHocDTO hehoc)
        {
            String sql = "INSERT INTO hehoc (id, name, status) VALUES (@id, @name, @status)";
            var cmd=new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", hehoc.Id);
            cmd.Parameters.AddWithValue("@name", hehoc.Name);
            cmd.Parameters.AddWithValue("@status", hehoc.status);
            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
        public static bool UpdateHeHoc(HeHocDTO hehoc)
        {
            String sql = "UPDATE hehoc SET name = @name, status=@status WHERE id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", hehoc.Id);
            cmd.Parameters.AddWithValue("@name", hehoc.Name);
            cmd.Parameters.AddWithValue("@status", hehoc.status);
            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
        public static bool DeleteHeHoc(int id)
        {
            string sql = "UPDATE hehoc SET status=@status WHERE id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@status", 0);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
        public static List<HeHocDTO> GetHeHocById(int id) 
        { 
            List<HeHocDTO> list=new List<HeHocDTO>();
            String sql = "select * from hehoc where hehoc.id LIKE @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", "%" + id + "%");
            List<List<object>> result = DBConnection.ExecuteReader(cmd);
            if(result.Count > 0)
            {
                foreach (var row in result)
                {
                    HeHocDTO heHoc = new HeHocDTO
                    {
                        Id = Convert.ToInt32(row[0]),
                        Name = Convert.ToString(row[1]),
                        status = Convert.ToInt16(row[2])
                    };
                    list.Add(heHoc);
                }
                return list;

            }
            return null;
        }
        public static List<HeHocDTO> findAll(String value)
        {
            List<HeHocDTO> list = new List<HeHocDTO>();
            String sql = "SELECT * FROM hehoc where hehoc.id LIKE @id or hehoc.name LIKE @name";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", "%"+value +"%");
            cmd.Parameters.AddWithValue("@name", "%"+value+"%");
            List<List<object>> result = DBConnection.ExecuteReader(cmd);
            if (result.Count > 0)
            {
                foreach (var row in result)
                {
                    HeHocDTO heHoc = new HeHocDTO
                    {
                        Id = Convert.ToInt32(row[0]),
                        Name = Convert.ToString(row[1]),
                        status = Convert.ToInt16(row[2])
                    };
                    list.Add(heHoc);
                }
                return list;

            }
            return null;
        }
        public static List<HeHocDTO> findName(String value)
        {
            List<HeHocDTO> list = new List<HeHocDTO>();
            String sql = "SELECT * FROM hehoc where hehoc.name LIKE @name";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@name", "%" + value + "%");
            List<List<object>> result = DBConnection.ExecuteReader(cmd);
            if (result.Count > 0)
            {
                foreach (var row in result)
                {
                    HeHocDTO heHoc = new HeHocDTO
                    {
                        Id = Convert.ToInt32(row[0]),
                        Name = Convert.ToString(row[1]),
                        status = Convert.ToInt16(row[2])
                    };
                    list.Add(heHoc);
                }
                return list;

            }
            return null;
        }
        public static HeHocDTO findById(int id)
        {
            String sql = "select * from hehoc where hehoc.id=@id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);
            List<List<object>> result = DBConnection.ExecuteReader(cmd);
            if (result.Count > 0)
            {
                List<object> row = result[0];
                HeHocDTO hehoc = new HeHocDTO
                {
                    Id = Convert.ToInt32(row[0]),
                    Name = Convert.ToString(row[1]),
                    status = Convert.ToInt16(row[2])
                };
                return hehoc;
            }
            return null;
        }
        public static HeHocDTO GetHehocByName(String name) {
            String sql = "select * from hehoc where hehoc.name like @name";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@name", "%"+name+"%");
            List<List<object>> result =DBConnection.ExecuteReader(cmd);
            if (result.Count > 0)
            {
                List<object> row = result[0];
                HeHocDTO hehoc = new HeHocDTO
                {
                    Id = Convert.ToInt32(row[0]),
                    Name = Convert.ToString(row[1]),
                    status = Convert.ToInt16(row[2])
                };
                return hehoc;
            }
            return null;
        }
        public static List<HeHocDTO> GetListBySearch(String value)
        {
            List<HeHocDTO> list = new List<HeHocDTO>();
            String sql = "SELECT * FROM hehoc where"+value;
            var cmd = new MySqlCommand(sql);
            List<List<object>> result = DBConnection.ExecuteReader(cmd);
            if (result.Count > 0)
            {
                foreach (var row in result)
                {
                    HeHocDTO heHoc = new HeHocDTO
                    {
                        Id = Convert.ToInt32(row[0]),
                        Name = Convert.ToString(row[1]),
                        status = Convert.ToInt16(row[2])
                    };
                    list.Add(heHoc);
                }
                return list;

            }
            return null;
        }
    }
}
