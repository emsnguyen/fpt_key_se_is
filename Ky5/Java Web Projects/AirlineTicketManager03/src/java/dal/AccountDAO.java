/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dal;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import model.Account;

/**
 *
 * @author lenovo
 */
public class AccountDAO extends BaseDAO{
    public AccountDAO() throws ClassNotFoundException {
        super();
    }
    public Account getAccount(String username, String password) throws Exception {
        PreparedStatement ps = null;
        ResultSet rs = null;
        try {
            String query = "SELECT [ID]\n"
                    + "      ,[Username]\n"
                    + "      ,[Password]\n"
                    + "      ,[Firstname]\n"
                    + "      ,[Lastname]\n"
                    + "      ,[Email]\n"
                    + "      ,[Status]\n"
                    + "  FROM [Account]\n"
                    + "  WHERE Username = ? \n"
                    + "  AND Password = ?";
            connection = getConnection();
            ps = connection.prepareStatement(query);
            ps.setString(1, username);
            ps.setString(2, password);
            rs = ps.executeQuery();
            if (rs.next()) {
                Account acc = new Account();
                acc.setID(rs.getInt(1));
                acc.setUsername(username);
                acc.setPassword(password);
                acc.setFirstname(rs.getString(4));
                acc.setLastname(rs.getString(5));
                acc.setEmail(rs.getString(6));
                acc.setStatus(rs.getBoolean(7));
                connection.close();
                return acc;
            }
        } catch (Exception ex) {
            if (connection != null && !connection.isClosed()) {
                connection.close();
            }
            if (ps != null && !ps.isClosed()) {
                ps.close();
            }
            if (rs != null && !rs.isClosed()) {
                rs.close();
            }
        }
        return null;
    }

}
