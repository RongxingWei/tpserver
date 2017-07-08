using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class _Default : System.Web.UI.Page 
{
    static int  rowID=0;
    DataAccess dataAccess;
    protected void Page_Load(object sender, EventArgs e)
    {
        dataAccess = new DataAccess();
        this.gvList.AutoGenerateColumns = false;
        this.form1.DefaultButton = this.ImgSelect.ID;
        
    }
    //点击查询
    protected void ImgSelect_Click(object sender, ImageClickEventArgs e)
    {
        if (!ValidData())
        {
            this.lbPicture.Text = "";
            return;
        }

        BindData(this.txtDjbh.Text.Trim(),this.txtDanwbh.Text.Trim());
    }
    private void BindData(string spid,string pihao)
    {
        rowID = 0;
        DeleteFile();//删除当前项目pic文件夹中的图片。
        DataSet ds=dataAccess.SelectData(spid,pihao);
        if (ds.Tables[0].Rows.Count > 0)
        {
            this.lbPicture.Text = "尊敬的客户您好：共有" + ds.Tables[0].Rows.Count + " 条记录";
        }
        else
        {
            this.lbPicture.Text = "尊敬的客户您好：没有可供查询的记录";
        }
        this.gvList.DataSource = ds.Tables[0].DefaultView;
        this.gvList.DataBind();
    }
    private void BindData()
    {
        rowID = 0;
        DataSet ds = dataAccess.SelectDataAll();
        this.gvList.DataSource = ds.Tables[0].DefaultView;
        this.gvList.DataBind();
    }

    //从数据库中取出图片。
    private string  GetImgUrl(string photoID)
    {
            if (photoID.Equals(""))
            {
                return "";
            }
            DataSet ds=dataAccess.SelectPhotoByPhotoID(photoID.Trim().ToString());
            //得到图片名称XX.jpg
            string fileName = ds.Tables[0].Rows[0]["PhotoID"].ToString().Trim().Replace(" ", "");
            fileName= ReturnFile(fileName);//给图片加.jpg后缀名。
            string filePath = Server.MapPath("Pic") + "\\";

            byte[] imgbyte = (byte[])ds.Tables[0].Rows[0]["photo"];//将图片数据从DataRow中取出来   
            filePath = filePath + fileName;
            FileStream fileStream = null;

            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                else
                {
                    fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                    fileStream.Write(imgbyte, 0, imgbyte.Length);
                }

                return fileName;
            }
            catch(Exception se)
            {
                throw se;
            }
            finally
            {
                fileStream.Flush();
                fileStream.Close();
                fileStream.Dispose();
                GC.Collect();
            }
    }
    //规范图片的名称 没有后缀名给加上后缀名
    private string ReturnFile(string fileName)
    {
        string str="";
        int i=fileName.LastIndexOf('.');
        if (i < 0)
        {
            fileName = fileName + ".jpg";
            return fileName;
        }
        str=fileName.Substring(i+1);
        if (str.Equals(""))
        {
            if (i > 0)
            {
                fileName = fileName+"jpg";
            }
            else
            {
                fileName = fileName + ".jpg";
            }
        }
        return fileName;
    }
    //验证数据
    private bool ValidData()
    {
        if (this.txtDjbh.Text.Trim().Equals("") || this.txtDanwbh.Text.Trim().Equals(""))
        {
            Response.Write("<script language=javascript>alert('客户编号/出库单号不能为空')</script>");
            return false;
        }

        if (this.txtDjbh.Text.Trim().Length > 20 || this.txtDanwbh.Text.Trim().Length > 20)
        {
            Response.Write("<script language=javascript>alert('客户编号/出库单号的长度超长，请重新输入')</script>");
            return false;
        }
        return true;
    }
  　//在对行进行数据绑定后，触发的事件。
    protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            rowID++;
            e.Row.Cells[0].Text = rowID.ToString();
            if (e.Row.Cells[7].HasControls())
            {
                HyperLink hlink =(HyperLink)e.Row.Cells[7].FindControl("HyperLink1");

                string photoID = this.gvList.DataKeys[e.Row.RowIndex].Value.ToString();
                string fileName = "";
                try
                {
                    fileName = this.GetImgUrl(photoID.Trim().ToString());
                }
                catch (Exception se)
                {
                    string error = se.Message;
                }
                string filePath = "";
                if (!fileName.Equals(""))
                {
                    filePath = "~//Pic//" + fileName;
                }
                else
                {
                    hlink.Text = "无图片";
                }
                //下载图片
                hlink.NavigateUrl =filePath;
            }
        }
    }

    //删除PIC文件夹里面 原来的图片
    private void DeleteFile()
    {
        string sn = Server.MapPath("Pic");
        foreach (string s in Directory.GetFiles(sn)) // 把全路径名称房子 s中        
        {
            File.Delete(s); //删除此文件
        }

    }
    //点击商品查询按钮
    protected void ImageSPCX_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("SelectPicture.aspx");
    }
}
