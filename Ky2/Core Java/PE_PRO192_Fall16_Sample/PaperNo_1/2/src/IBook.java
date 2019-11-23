import java.util.ArrayList;
public interface IBook { 
    /*
     * return name of first book in the list "a"
     */
    public String f1(ArrayList<Book> a);        
   
    /*
     * calculate and return number of books in the list "a" which
     * have price greater than or equals to the given price (given
     * price as input parameter)
     */
    public int f2(ArrayList<Book> a, int price);
    //return name of book with second largest price
    String f3(ArrayList<Book> t);
    //delete the second largest elems in t
    void f4(ArrayList<Book> t);
}
