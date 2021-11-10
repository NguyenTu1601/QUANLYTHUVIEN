using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

using QUANLYTHUVIEN.DBLayer;

namespace QUANLYTHUVIEN.BSLayer
{
    class BLDeleteUser
    {
        DBMain dbMain =null;
        public BLDeleteUser()
        {
            dbMain = new DBMain();
        }
    }
}
