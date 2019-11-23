/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dal;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.naming.InitialContext;
import javax.naming.NamingException;

/**
 *
 * @author lenovo
 */
public abstract class BaseDAO {
    Connection connection;
    public Connection getConnection() throws Exception {
        try {
            InitialContext ic = new InitialContext();
            String dbName = (String) ic.lookup("java:comp/env/dbName");
            String servername = (String) ic.lookup("java:comp/env/servername");
            String port = (String) ic.lookup("java:comp/env/port");
            String username = (String) ic.lookup("java:comp/env/username");
            String password = (String) ic.lookup("java:comp/env/password");
            String url = "jdbc:sqlserver://"+ servername +":" + port + ";databaseName=" + dbName;
            Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
            connection = DriverManager.getConnection(url, username, password);
        } catch (Exception ex) {
            throw ex;
        }
        return connection;
    }
}
