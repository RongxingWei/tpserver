using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls; 
using System.IO;

public partial class SelectPicture : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { 
        this.form1.DefaultButton = this.ImgSelect.ID;
    }
    protected void ImgSelect_Click(object sender, ImageClickEventArgs e)
    {
        if (!ValidData())
        {
            this.lbPicture.Text = "";
            return;
        }
        else
        DisplayPicure();
    
      
    }
    private void DisplayPicure()
    {
        DataAccess dataAccess = new DataAccess();        
        DataSet ds = dataAccess.SelectPicture(this.txtSpid.Text.Trim(),this.txtPihao.Text.Trim());
        //先看 有没有相关图片 有 就从图片表中取出其图片名称
        if (ds.Tables[0].Rows.Count > 0)
        {
            this.lbPicture.Text = "<table width='800px'>";            
            
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];

                string picID = dr["PhotoID"].ToString().Trim().Replace(" ","");
                string filePath = Server.MapPath("Pic") + "\\";
                string fileName = "";
                fileName = picID;
                
                //将数据库中的image显示到pictuebox(pbImage)上：   
                byte[] imgbyte = (byte[])dr["photo"];//将图片数据从DataRow中取出来   
                filePath=filePath+fileName;
                FileStream fileStream =null;
                try
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                    fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                    fileStream.Write(imgbyte, 0, imgbyte.Length);
                }
                catch
                {
                
                }
                finally
                {
                    fileStream.Flush();
                    fileStream.Close();
                    fileStream.Dispose();
                    GC.Collect();
                }

                string pictitle ="点此查看此图片";
                string path = filePath;

                int icount = ds.Tables[0].Rows.Count / 3;
                int mod = i % 3;
                if ((i % 3) == 0 && i > 2)
                {
                    this.lbPicture.Text += "</tr>";
                }
                if ((i % 3) == 0)
                {
                    if (i > 0 && (i == (i * icount)))
                    {
                        continue;
                    }
                    else
                    {
                        this.lbPicture.Text += "<tr>";
                    }
                }

                this.lbPicture.Text += "<td>";
                this.lbPicture.Text += "<label id='lbPihao" + i + "'  style='background-color:#3A5F7A; color:White' >报告单编号:" + picID.Substring(0, picID.LastIndexOf('.')) + "</label>";
                this.lbPicture.Text += "<br/><img alt=''  height='165px' width='260px' src='" + "Pic\\" + fileName + "'  />";
                this.lbPicture.Text += "<br/><a id='imgHref" + i + "' Font-Size='12px' href='" + "Pic\\" + fileName + "'  >" + pictitle + " </a><br/><br/><br/>";
                this.lbPicture.Text += "<br/><asp:hyperlink id='imgHlk" + i + "' runat='server' Text='点击下载此图片'  NavigateUrl='" + @"~/Pic/" + fileName + "' ></asp:hyperlink>";
                this.lbPicture.Text += "</td>";

            }
            this.lbPicture.Text += "</tr>";
            this.lbPicture.Text += "</table>";    
       
        }
        else
        {
            this.lbPicture.Text = "暂无图片信息！！！";
        }
    }

    //验证数据
    private bool ValidData()
    {
        if (this.txtSpid.Text.Trim().Equals("") || this.txtPihao.Text.Trim().Equals(""))
        {
            Response.Write("<script language=javascript>alert('商品编号/批号不能为空')</script>");
            return false;
        }

        if (this.txtSpid.Text.Trim().Length>20 || this.txtPihao.Text.Trim().Length>20)
        {
            Response.Write("<script language=javascript>alert('商品编号/批号的长度超长，请重新输入')</script>");
            return false;
        }
        return true;
    }


    protected void ImageDJCX_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}