using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using QUANLYTHUVIEN.DBLayer;


namespace QUANLYTHUVIEN.BSLayer
{
    
    class BLThemUser
    {
        DBMain db = null;
        public BLThemUser()
        {
            db = new DBMain();
        }

        public void addNewUser(String txtUserName,String txtRePass,ref string err)
        {
            string sqlString = "Insert Into User(ID,Password,PhanQuyen) Values(" + "'" +
                txtUserName + "','" +
                txtRePass + "','1')";
            db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }


    }
}
