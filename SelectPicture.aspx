<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectPicture.aspx.cs" Inherits="SelectPicture" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>药品质检报告查询</title>

    <script language="javascript" type="text/javascript">   
  document.ondblclick   =   function()   
  {   
      var   e   =   window.event.srcElement;   
      if(e.tagName=="IMG")   
      {   
          var   win=window.open(e.src,   "_blank",   "top=1200px,left=1200px");   
          win.document.execCommand('SaveAs');   
          win.opener=null;   
          win.close();   
      }   
  }   
  
//  function   Saveit(){     
//  temp.location=event.srcElement.src   //在隐藏帧中加载图片     
//  //100毫秒后在id为temp的隐藏帧上执行saveas命令       
//  setTimeout('temp.document.execCommand("saveas")',100)
//  }     

    </script>

    <meta http-equiv="Content-Type" content="JPG/MPEG; charset=gb2312" />
</head>
<body>
    <form id="form1" runat="server" style="text-align: center; vertical-align: top">
        <div style="width: 800px; text-align: center; vertical-align: top">
            <table style="width: 800; text-align: center; vertical-align: top; border-top-style: none"
                cellpadding="0" cellspacing="0">
                <tr style="height: 158px; text-align: center; vertical-align: top; border-bottom-style: none;
                    border-left-style: none; border-right-style: none; border-top-style: none">
                    <td colspan="2" style="text-align: center; height: 100%; vertical-align: top; border-bottom-style: none;
                        border-left-style: none; border-right-style: none; border-top-style: none">
                        <%--<table style ="text-align:center; vertical-align:top"  cellpadding="0" cellspacing="0" >
                   　      <tr style="background-color:#ffccff">
                   　          <td>
                   　             <%-- <asp:Image ID="ImgHeader" ImageUrl=" "runat="server" Height="128px"  Width="220px"/>
                   　          </td>
                   　          <td style="vertical-align:middle">
                   　              <asp:Label ID="lb01" BackColor="#ffccff" Text="<br/>九州通商品图片查询"   Font-Bold="true" Font-Italic="true" Font-Size="28"  runat="server" Height="128px" Width="580px"></asp:Label>
                   　          </td>
                   　      </tr>
                   　 </table>--%>
                        <asp:Image ID="ImgHeader" ImageUrl="~/Img/1bak.jpg" runat="server" Height="220px"
                            Width="800px" />
                    </td>
                    <%--<td style="height:128px; border-bottom-style:none; border-left-style:none; border-right-style:none; border-top-style:none">
                       <asp:Label ID="lb01" BackColor="#ffccff" Text="<br/>九州通商品图片查询"   Font-Bold="true" Font-Italic="true" Font-Size="28"  runat="server" Height="108px" Width="580px"></asp:Label>
                   </td>--%>
                </tr>
                <tr>
                    <td style="width: 800px" align="left" colspan="2">
                        <asp:Label ID="lbText" runat="server" Text="药品质检报告查询:"></asp:Label>&nbsp;&nbsp;<asp:ImageButton ID="ImageDJCX" runat="server" ImageUrl="~/Img/djcx.jpg" Width="160px" OnClick="ImageDJCX_Click" Height="32px"   />
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        <table>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbSpid" runat="server" Text="药品编号:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSpid" runat="server"></asp:TextBox>
                                </td>
                                <td  align="right">
                                    <asp:Label ID="lbPihao" runat="server" Text="批号:" Width="90px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPihao" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:ImageButton ID="ImgSelect" runat="server" ImageUrl="~/Img/searchv.gif" OnClick="ImgSelect_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lbPicture" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
