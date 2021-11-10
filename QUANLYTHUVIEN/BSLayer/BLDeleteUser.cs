using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

using QUANLYTHUVIEN.DBLayer;
using System.Data;

namespace QUANLYTHUVIEN.BSLayer
{
    class BLDeleteUser
    {
        DBMain db =null;
        public BLDeleteUser()
        {
            db = new DBMain();
        }

        public bool deleteUser(string txtUser, ref string err)
        {
            string sqlString = "delete from UserName where ID ='" +txtUser + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool isExist(String txtUserName, ref String err)
        {

            string sqlString = "select * from UserName where ID = '" + txtUserName + "'";

            DataTable ktra = db.GetDataTable(sqlString, CommandType.Text, ref err);

            if (ktra.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
