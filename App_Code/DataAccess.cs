using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

/// <summary>
/// DataAccess 的摘要说明
/// </summary>
public class DataAccess
{
    public SqlConnection conn;
    SqlDataAdapter da;
    string strConn;

    public DataAccess()
    {
       try
        {
            strConn = System.Configuration.ConfigurationManager.AppSettings["strConn"].ToString();
            conn = new SqlConnection(strConn);
        }
        catch (Exception se)
        {
            throw se;
        }
    }

    /// <summary>
    /// 单据查询模式
    /// </summary>
    /// <param name="djbh"></param>
    /// <param name="danwbh"></param>
    /// <returns></returns>
    public DataSet SelectData(string djbh, string danwbh)
    {
        SqlCommand comm = null;
        DataSet ds = new DataSet();
        try
        {
            comm = new SqlCommand();
         comm.CommandText =  "exec proc_lmis_xsg @djbh , @danwbh ";
			
            comm.CommandType = CommandType.Text;
            comm.Connection = conn;
            OpenConn();

            comm.Parameters.Add(new SqlParameter("@djbh", SqlDbType.VarChar, 50));
            comm.Parameters["@djbh"].Value = djbh;

            comm.Parameters.Add(new SqlParameter("@danwbh", SqlDbType.VarChar, 50));
            comm.Parameters["@danwbh"].Value = danwbh;

            SqlDataAdapter da = new SqlDataAdapter(comm);
            da.Fill(ds);
            return ds;            
        }
        catch(Exception se)
        {
            throw se;
        }
        finally
        {
            CloseConn();
        }
    }

    public DataSet SelectDataAll()
    {
        SqlCommand comm = null;
        DataSet ds = new DataSet();
        try
        {

            comm = new SqlCommand();
            //comm.CommandText = "select top 20 * from lsmx ";
            comm.CommandText = "select top 20 a.djbh,a.spbh,a.pihao,b.photoID,b.photoClass " 
                  +" from ckdj a" 
                  +" inner join leeBatch  b on a.spbh=b.spid and a.pihao=b.pihao";
            comm.CommandType = CommandType.Text;
            comm.Connection = conn;
            OpenConn();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            da.Fill(ds);
            return ds;
        }
        catch (Exception se)
        {
            throw se;
        }
        finally
        {
            CloseConn();
        }
    }

    /// <summary>
    /// 读取图片
    /// </summary>
    /// <param name="photoID"></param>
    /// <returns></returns>
    public DataSet SelectPhotoByPhotoID(string photoID)
    {
        SqlCommand comm = null;
        DataSet ds = new DataSet();
        try
        {

            comm = new SqlCommand();
            //comm.CommandText = "select top 20 * from lsmx ";
            comm.CommandText = "select * from photoLib where photoID=@photoID";
            comm.CommandType = CommandType.Text;
            comm.Connection = conn;
            OpenConn();

            comm.Parameters.Add(new SqlParameter("@photoID", SqlDbType.VarChar, 50));
            comm.Parameters["@photoID"].Value = photoID;  //+".jpg"

            SqlDataAdapter da = new SqlDataAdapter(comm);
            da.Fill(ds);
            return ds;
        }
        catch (Exception se)
        {
            throw se;
        }
        finally
        {
            CloseConn();
        }
    }

    /// <summary>
    /// 商品查询-湖北模式
    /// </summary>
    /// <param name="spId"></param>
    /// <param name="pihao"></param>
    /// <returns></returns>
    public DataSet SelectPicture(string spId, string pihao)
    {
        SqlCommand comm = null;
        DataSet ds = new DataSet();
        try
        {
       
        	 string strSql = "";
        
            if ((!spId.Equals("")) && (!pihao.Equals("")))
            {
                strSql = "select a.* From dbo.photoLib a inner join leebatch b on a.PhotoID=b.photoID where b.spid='" + spId + "' and b.pihao like '" + pihao + "%' ";
            }
            comm = new SqlCommand(strSql, conn);
             OpenConn();
            da = new SqlDataAdapter(comm);
            da.Fill(ds);

            return ds;
           
         /*
            comm = new SqlCommand();
            comm.CommandText = "proc_SelectPhoto";
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandType = CommandType.Text;
            comm.Connection = conn;
            OpenConn();

            comm.Parameters.Add(new SqlParameter("@spID", SqlDbType.VarChar, 50));
            comm.Parameters["@spID"].Value = spId;

            comm.Parameters.Add(new SqlParameter("@pihao", SqlDbType.VarChar, 50));
            comm.Parameters["@pihao"].Value = pihao;

            SqlDataAdapter da = new SqlDataAdapter(comm);
            da.Fill(ds);
            return ds;
         */
            
        }
        catch (Exception se)
        {
            throw se;
        }
        finally
        {
            CloseConn();
        }
    }

    private  void OpenConn()
    {
        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }
    }
    private  void CloseConn()
    {
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }
    }
}
