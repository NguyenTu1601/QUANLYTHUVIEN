﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;


namespace QUANLYTHUVIEN.DBLayer
{
    class DBMain
    {
        string ConnStr = @"Data Source=DESKTOP-R5G0N9R\NGUYENTU;Initial Catalog=QuanLyThuVien;Integrated Security=True";
        SqlConnection conn = null;
        SqlCommand comm = null;
        SqlDataAdapter da = null;
        public DBMain()
        {
            conn = new SqlConnection(ConnStr);
            comm = conn.CreateCommand();
        }
        public DataSet ExecuteQueryDataSet(string strSQL, CommandType ct, params SqlParameter[] param)
        {
            comm.Parameters.Clear();
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            foreach (SqlParameter p in param)
                comm.Parameters.Add(p);
            da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        //public bool MyExecuteNonQuery(string strSQL, CommandType ct, ref string error, params SqlParameter[] param)
        //{
        //    bool f = false;
        //    if (conn.State == ConnectionState.Open)
        //        conn.Close();
        //    conn.Open();
        //    comm.CommandText = strSQL;
        //    comm.CommandType = ct;
        //    try
        //    {
        //        comm.ExecuteNonQuery();
        //        f = true;
        //    }
        //    catch (SqlException ex)
        //    {
        //        error = ex.Message;
        //    }
        //    finally
        //    {

        //        conn.Close();
        //    }
        //    return f;
        //}

        /// <summary>
        /// trả vê giá trị bool dòng tác động
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="ct"></param>
        /// <param name="error"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool MyExecuteNonQuery(string strSQL, CommandType ct, ref string error,
           params SqlParameter[] param)
        {
            bool f = false;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.Parameters.Clear();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            foreach (SqlParameter p in param)
                comm.Parameters.Add(p);
            try
            {
                comm.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return f;
        }

        //Hàm lấy thông tin từ bảng
        public DataTable GetDataTable(string strSQL,CommandType ct, ref string err)
        {
            if(conn.State==ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds.Tables[0];

        }

        // Kieu query tra ve mot doi tuong/mot gia tri
        public object ExecuteScalar(string strSQL, CommandType ct, params SqlParameter[] param)
        {
            object data = null;

            conn.Open();
            comm.Parameters.Clear();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            foreach (SqlParameter p in param)
                comm.Parameters.Add(p);
            try
            {
                data = comm.ExecuteScalar();
            }
            catch (SqlException)
            {

            }
            finally
            {
                conn.Close();
            }

            return data;
        }

    }
}