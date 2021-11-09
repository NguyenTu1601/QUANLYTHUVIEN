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
    }
}
