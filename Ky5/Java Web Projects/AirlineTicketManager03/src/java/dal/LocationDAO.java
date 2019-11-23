package dal;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;
import model.City;
import model.Country;
import model.Location;

/**
 *
 * @author lenovo
 */
public class LocationDAO extends BaseDAO {
    public LocationDAO() throws Exception {
        super();
    }
    public ArrayList<Location> getAll() throws Exception {
        PreparedStatement ps = null;
        ResultSet rs = null;
        ArrayList<Location> locations = new ArrayList<>();
        try {
            String query = "SELECT [ID]\n"
                    + "      ,[CityID]\n"
                    + "      ,[Symbol]\n"
                    + "      ,[Status]\n"
                    + "  FROM [Location]";
            connection = getConnection();
            ps = connection.prepareStatement(query);
            rs = ps.executeQuery();
            while (rs.next()) {
                Location loc = new Location();
                loc.setID(rs.getInt(1));
                loc.setCity(getCity(rs.getInt(2)));
                loc.setSymbol(rs.getString(3));
                loc.setStatus(rs.getBoolean(4));
                locations.add(loc);
            }
            connection.close();
        } catch (SQLException ex) {
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
        return locations;
    }

    public City getCity(int cityID) throws Exception {
        PreparedStatement ps = null;
        ResultSet rs = null;
        try {
            String query = "SELECT  [ID]\n"
                    + "      ,[Name]\n"
                    + "      ,[CountryID]\n"
                    + "  FROM [City] WHERE ID = ?";
            connection = getConnection();
            ps = connection.prepareStatement(query);
            ps.setInt(1, cityID);
            rs = ps.executeQuery();
            if (rs.next()) {
                City c = new City();
                c.setID(cityID);
                c.setName(rs.getString(2));
                c.setCountry(getCountry(rs.getInt(3)));
                connection.close();
                return c;
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

    public Country getCountry(int countryID) throws Exception {
        PreparedStatement ps = null;
        ResultSet rs = null;
        try {
            String query = "SELECT [ID]\n"
                    + "      ,[Name]\n"
                    + "  FROM [Country] \n"
                    + "  WHERE ID = ?";
            connection = getConnection();
            ps = connection.prepareStatement(query);
            ps.setInt(1, countryID);
            rs = ps.executeQuery();
            if (rs.next()) {
                Country c = new Country();
                c.setID(countryID);
                c.setName(rs.getString(2));
                return c;
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

    public ArrayList<Location> getAll(String locationID) throws Exception {
        PreparedStatement ps = null;
        ResultSet rs = null;
        ArrayList<Location> locations = new ArrayList<>();
        try {
            String query = "SELECT [ID]\n"
                    + "      ,[CityID]\n"
                    + "      ,[Symbol]\n"
                    + "      ,[Status]\n"
                    + "  FROM [Location] WHERE ID LIKE '%" + locationID + "%'";
            System.out.println("search query: " + query);
            connection = getConnection();
            ps = connection.prepareStatement(query);
            rs = ps.executeQuery();
            while (rs.next()) {
                Location loc = new Location();
                loc.setID(rs.getInt(1));
                loc.setCity(getCity(rs.getInt(2)));
                loc.setSymbol(rs.getString(3));
                loc.setStatus(rs.getBoolean(4));
                locations.add(loc);
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
        return locations;
    }
}

