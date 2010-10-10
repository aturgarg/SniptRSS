<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" ValidateRequest="false"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div>
       <asp:TextBox ID="txtUrl" runat="server" /> 
    <asp:Button Text="Fetch" ID="btnFetchRssFeed" OnClick="btnFetchRssFeed_OnClick" runat="server" />
     </div>
    
    <br />
    <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_OnItemCommand" DataKeyNames="Url,Description"
        onselectedindexchanged="ListView1_SelectedIndexChanged" OnSelectedIndexChanging="ListView1_OnSelectedIndexChanging"  >    
        <LayoutTemplate>        
            <table class="gridview">
                <th>Select</th>
                <th>Published</th>
                <th>Article</th>
                
                <th>Tags</th>                
                <tbody>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </tbody>            
            </table>        
        </LayoutTemplate>        
        <ItemTemplate>
        
            <tr>
            <td>
            <asp:Button CommandName="Select" runat="server" Text="*"  />
            </td>
                <td><%#Eval("Published", "{0:d}") %></td>
                <td>
                    <a href='<%#Eval("Url")%>'><%#Eval("Title") %></a>
                </td>
                
                <td>
                  <asp:Repeater ID="Repeater1" DataSource='<%#Eval("Tags") %>' runat="server">
                        <ItemTemplate> <%#Container.DataItem %> </ItemTemplate>
                        <SeparatorTemplate>,</SeparatorTemplate>
                    </asp:Repeater>

                   
                </td>
            </tr>        
        </ItemTemplate>        
    </asp:ListView>


    <textarea id="txtDescription" cols="20" rows="2" runat="server"></textarea>
    </asp:Content>
