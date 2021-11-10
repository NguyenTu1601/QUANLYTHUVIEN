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

        public bool addNewUser(String txtUserName,String txtRePass,ref String err)
        {
            string sqlString = "Insert Into User(ID,Password,PhanQuyen) Values(" + "'" +
                txtUserName + "','" +
                txtRePass + "','1')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool isExist(String txtUserName, ref String err)
        {

            string sqlString = "selece * from UserName where ID= ' " + txtUserName + "')";
            
            DataTable ktra = db.GetDataTable(sqlString,CommandType.Text, ref err);

            if (ktra.Rows.Count > 0) 
            {
                return true;
            }    
            return false;
        }

    }
}
