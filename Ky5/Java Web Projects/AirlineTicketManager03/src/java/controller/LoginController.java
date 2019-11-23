/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controller;

import dal.AccountDAO;
import dal.LocationDAO;
import java.io.IOException;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import model.Account;
import model.Location;

/**
 *
 * @author lenovo
 */
public class LoginController extends HttpServlet {

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        try {
            String username = request.getParameter("username");
            String password = request.getParameter("password");
            AccountDAO accDB = new AccountDAO();
            Account u = accDB.getAccount(username, password);
            if (u != null) {
                HttpSession session = request.getSession();
                session.setAttribute("username", u.getUsername());
                session.setAttribute("firstname", u.getFirstname());
                session.setAttribute("userID", u.getID());
                //will work on remember me function later
                
                //get location info to display
                LocationDAO locDB = new LocationDAO();
                ArrayList<Location> locations = locDB.getAll();
                request.getSession().setAttribute("locations", locations);
                response.sendRedirect("LocationManagement.jsp");
            } else {
                request.setAttribute("error", "Account not found");
                request.setAttribute("username", username);
                request.setAttribute("password", password);
                request.getRequestDispatcher("Login.jsp").forward(request, response);
            }
        } catch (Exception ex) {
            Logger.getLogger(LoginController.class.getName()).log(Level.SEVERE, null, ex);
        } 
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}
