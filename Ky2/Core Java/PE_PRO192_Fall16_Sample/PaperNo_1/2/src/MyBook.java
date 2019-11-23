import java.util.*;
//Your task is to complete this class 
public class MyBook implements IBook {    
    //write the definition of method f1 here 
    @Override
    public String f1(ArrayList<Book> a) {
        throw new UnsupportedOperationException(
                "Remove this line and implement your code here!");
    }  
    
    //write the definition of method f2 here 
    @Override
    public int f2(ArrayList<Book> a, int price) { 
       throw new UnsupportedOperationException(
                "Remove this line and implement your code here!");
    }    
    //add and complete you other methods (if needed) here   
    @Override
    public String f3(ArrayList<Book> t) {
        //return name of book with second largest price
        Comparator<Book> u = new Comparator<Book>() {
            @Override
            public int compare(Book x, Book y) {
                if (x.price < y.price) {
                    return -1;
                } else if (x.price < y.price) {
                    return 1;
                } else
                    return 0;
                }
        };
        Collections.sort(t, u);
        int n = t.size();
        return t.get(n-2).name;
    }

    @Override
    public void f4(ArrayList<Book> t) {
        //delete the second largest elems in t
        Comparator<Book> u = new Comparator<Book>() {
            @Override
            public int compare(Book x, Book y) {
                return x.name.compareTo(y.name);
            }
        };
        Collections.sort(t, u);
        int n = t.size();
        t.remove(n-2);
    }
}
