<%-- 
    Document   : LocationManagement
    Created on : May 28, 2018, 4:26:23 PM
    Author     : lenovo
--%>

<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Aircraft Management Page</title>
        <link href="css/LocationManagement.css" rel="stylesheet" type="text/css"/>
    </head>
    <body>
        <%@include file="Header.jsp" %>
        <%@include file="Sidebar.jsp" %>
        <div class="main">
            <h3>Aircraft Management</h3>
            <!--has paging-->
            <div>
                <form action="location/search">
                    Plane Name: 
                    <input type="text" name="planeName"/>
                    <input type="submit" value="Search"/>
                </form>

            </div>
            <table>
                <tr>
                    <th>Location_ID</th>
                    <th>Country</th>
                    <th>City</th>
                    <th>Symbol</th>
                    <th>Status</th>
                    <th></th>
                    <th></th>
                </tr>
                <c:forEach items="${planes}" var="p">
                    <tr>
                        <td>${p.name}</td>
                        <td>${p.number}</td>
                        <td>${l.city.name}</td>
                        <td>${l.symbol}</td>
                        <td>${l.status}</td>
                        <td>
                            <a href="location/edit">Edit</a>
                        </td>
                        <td>
                            <input type="checkbox"/>
                        </td>
                    </tr>
                </c:forEach>
            </table>
            <div class="right">
                <a href="location/add" class="add">AddNewLocation</a>
                <a href="location/delete" class="delete">X</a>
            </div>
        </div>
            </div>
    </body>
</html>
