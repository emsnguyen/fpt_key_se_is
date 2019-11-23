<%-- 
    Document   : dummy
    Created on : Feb 6, 2018, 9:50:31 AM
    Author     : sonnt5
--%>

<%@page import="modal.Dummy"%>
<%@page import="java.util.ArrayList"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
        <link href="css/pagger.css" rel="stylesheet" type="text/css"/>
        <style>
            #paging{
                
            }
        </style>
        <%
            ArrayList<Dummy> dummies = (ArrayList<Dummy>)
            request.getAttribute("dummies");
            int totalPage = Integer.parseInt(request.getAttribute("totalpage").toString());
            int pagegap = Integer.parseInt(request.getAttribute("pagegap").toString());
            int pageIndex = Integer.parseInt(request.getAttribute("pageindex").toString());
        %>
    </head>
    <body>
        <table border="1px">
            <tr>
                <th>ID</th>
                <th>Name</th>
            </tr>
                <%
                    for(Dummy d : dummies)
                    {
                %>
                <tr>
                    <td><%=d.getId()%></td>
                    <td><%=d.getName()%></td>
                </tr>
                <%
                    }
                %>
        </table>    
        <%=util.HtmlHelper.pagger(pageIndex, pagegap, totalPage) %>
    </body>
</html>
