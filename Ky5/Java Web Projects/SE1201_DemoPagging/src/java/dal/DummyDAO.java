/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dal;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;
import modal.Dummy;

/**
 *
 * @author sonnt5
 */
public class DummyDAO {
    public Connection connection;
    public DummyDAO()
    {
        try {
            String username = "sa";
            String password = "12345";
            String url = "jdbc:sqlserver://localhost:1433;databaseName=DemoPaging";
            Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
            connection = DriverManager.getConnection(url,username,password);
        } catch (ClassNotFoundException | SQLException ex) {
            Logger.getLogger(DummyDAO.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    public ArrayList<Dummy> all(int start, int end)
    {
        ArrayList<Dummy> dummies = new ArrayList<>();
        String query = "select rn,id,name from (\n" +
                        "    select ROW_NUMBER() over (order by id asc) as rn, id,name\n" +
                        "    from DummyTBL\n" +
                        ") as x\n" +
                        "where rn between ? and ?";
        try {
            PreparedStatement statement = connection.prepareStatement(query);
            statement.setInt(1, start);
            statement.setInt(2, end);
            ResultSet rs = statement.executeQuery();
            while(rs.next())
            {
                Dummy d = new Dummy();
                d.setId(rs.getInt("id"));
                d.setName(rs.getString("name"));
                dummies.add(d);
            }
        } catch (SQLException ex) {
            Logger.getLogger(DummyDAO.class.getName()).log(Level.SEVERE, null, ex);
        }
        return dummies;
    }
    
    public int count()
    {
        String query = "SELECT COUNT(*) as TotalRows FROM DummyTBL";
        try {
            PreparedStatement statement = connection.prepareStatement(query);
            ResultSet rs = statement.executeQuery();
            if(rs.next())
            {
                return rs.getInt("TotalRows");
            }
        } catch (SQLException ex) {
            Logger.getLogger(DummyDAO.class.getName()).log(Level.SEVERE, null, ex);
        }
        return 0;
    }
    
    
}
