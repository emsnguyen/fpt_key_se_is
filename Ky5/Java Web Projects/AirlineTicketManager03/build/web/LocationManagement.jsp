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
        <title>Location Management Page</title>
        <link href="css/LocationManagement.css" rel="stylesheet" type="text/css"/>
    </head>
    <body>
        <c:if test="${noresult ne null && locations.size() == 0}">
            <script src="js/LocationManagementAlertNoResultFound.js" type="text/javascript"></script>
        </c:if>
        <%@include file="Header.jsp" %>
        <div class="wrapper">
            <%@include file="Sidebar.jsp" %>
            <div class="main">
                <h3>Location Management</h3>
                <div>
                    <form action="location/search">
                        LocationID: 
                        <input type="text" name="locationID"/>
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
                    <c:forEach items="${locations}" var="l">
                        <tr>
                            <td>${l.ID}</td>
                            <td>${l.city.country.name}</td>
                            <td>${l.city.name}</td>
                            <td>${l.symbol}</td>
                            <td class="red">${l.status}</td>
                            <td>
                                <!--pass locationID to edit-->
                                <a href="location/edit?locationID=${l.ID}" class="red">Edit</a>
                            </td>
                            <td>
                                <!--pass locationID to checkbox-->
                                <input type="checkbox" name="cbx${l.ID}" value="${l.ID}"/>
                            </td>
                        </tr>
                    </c:forEach>
                </table>
                <div class="right">
                    <a href="location/add" class="add">AddNewLocation</a>
                    <a href="location/delete" class="delete">X</a>
                </div>
            </div>
            <!--end of main class-->
        </div> 
        <!--end of wrapper class-->
    </body>
</html>
