<%-- 
    Document   : Login
    Created on : May 28, 2018, 3:52:02 PM
    Author     : lenovo
--%>

<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
        <link href="css/Login.css" rel="stylesheet" type="text/css"/>
    </head>
    <body>
        <h3>Login</h3>
        <form action="login" method="POST">
            <table>
                <tbody>
                    <tr>
                        <td>Username</td>
                        <td>Password</td>
                    </tr>
                    <tr>
                        <td>
                            <input type="text" value="${username}" name="username" required="required"/>
                        </td>
                        <td>
                            <input type="password" value="${password}" name="password" required="required"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" value="cbRemember"/>Remember me
                        </td>
                        <td>
                            <input type="submit" value="Submit"/>
                        </td>
                    </tr>
                </tbody>
            </table>
            <c:if test="${error ne null}">
                <span>${error}</span>
            </c:if>
        </form>
    </body>
</html>
