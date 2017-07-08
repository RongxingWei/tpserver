<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>九州通医药有限公司__药品质量相关文件下载 
</title>
</head>
<body>
    <form id="form1" runat="server" style="text-align:center; vertical-align:top;" >    
    <div style="width:800px; text-align:center; vertical-align:top">
    
        <table style="width:800; text-align:center; vertical-align:top; border-top-style:none"  cellpadding="0" cellspacing="0" >
              <tr style=" height:158px;  text-align:center; vertical-align:top; border-bottom-style:none; border-left-style:none; border-right-style:none; border-top-style:none">
                   <td colspan="2" style="text-align:center; height:100%; vertical-align:top; border-bottom-style:none; border-left-style:none; border-right-style:none; border-top-style:none">
                   　 <asp:Image ID="ImgHeader" ImageUrl="~/Img/1bak.jpg" runat="server" Height="220px"  Width="800px"/>
                   </td>
              </tr>
              <tr>
                   <td style="width:800px" align="left" colspan="2">
                      <asp:Label ID="lbText" runat="server" Text="请输入您在九州通的客户编号和出库清单编号，字母区分大小写。" Width="565px" ></asp:Label>
                           <asp:ImageButton ID="ImageSPCX" runat="server" ImageUrl="~/Img/spcx.jpg" Width="160px" Height="32px" OnClick="ImageSPCX_Click" TabIndex="1" />
                   </td>
              </tr>
              <tr>
                   <td align="left"  colspan="2">
                        <table>
                              <tr>
                                   <td align="left" style="width: 79px; height: 25px">
                                       <asp:Label ID="lbSpid" runat="server" Text="客户编号:" Width="77px"></asp:Label>
                                   </td>
                                   <td style="height: 25px">
                                        <asp:TextBox ID="txtDanwbh" runat="server"></asp:TextBox>
                                        
                                   </td>
                                   <td style="width: 76px; height: 25px;" align="right">
                                       <asp:Label ID="lbPihao" runat="server" Text="出库单号:" Width="90px"></asp:Label>
                                   </td>
                                   <td style="height: 25px">
                                        <asp:TextBox ID="txtDjbh" runat="server"></asp:TextBox>
                                   </td>
                                   <td style="height: 25px">
                                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                         <asp:ImageButton ID="ImgSelect" runat="server" ImageUrl="~/Img/searchv.gif" OnClick="ImgSelect_Click"/>
                                   </td>
                              </tr>
                        </table>
                       </td>
              </tr>
              <tr>
                   <td  colspan="2">
                        <asp:Label ID="lbPicture" runat="server" ></asp:Label>
                         
                   </td>                  
              </tr>
              <tr>
                   <td colspan="2">
                   
                        <asp:GridView ID="gvList" runat="server" Width="800px" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        GridLines="Vertical" OnRowDataBound="gvList_RowDataBound" 
                        AutoGenerateColumns="False" DataKeyNames="photoID" >                   
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <Columns>
                                <asp:BoundField HeaderText="序号" >
                                    <ItemStyle Font-Size="Small" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="商品编号" DataField="spbh" >
                                    <ItemStyle Font-Size="Small" />
                                </asp:BoundField>
                                <asp:BoundField DataField="pihao" HeaderText="批号" >
                                    <ItemStyle Font-Size="Small" />
                                </asp:BoundField>
                                <asp:BoundField DataField="spmch" HeaderText="商品名称" >
                                    <ItemStyle Font-Size="Small" />
                                </asp:BoundField>
                                <asp:BoundField DataField="shpgg" HeaderText="商品规格" >
                                    <ItemStyle Font-Size="Small" />
                                </asp:BoundField>

                                <asp:BoundField DataField="dw" HeaderText="包装单位" >
                                    <ItemStyle Font-Size="Small" />
                                </asp:BoundField>
                                <asp:BoundField DataField="shpchd" HeaderText="生产厂家" >
                                    <ItemStyle Font-Size="Small" />
                                </asp:BoundField>



                                <asp:TemplateField HeaderText="图片下载">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1"  runat="server" 
                                            Text="下载"></asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Font-Size="Small" />
                                </asp:TemplateField>
                                
                            </Columns>
                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" Font-Size="small" ForeColor="White" />
                            <AlternatingRowStyle BackColor="Gainsboro" />
                         </asp:GridView>
                         
                   </td>
                   
              </tr>
        </table>
    </div>
    </form>
</body>
</html>
