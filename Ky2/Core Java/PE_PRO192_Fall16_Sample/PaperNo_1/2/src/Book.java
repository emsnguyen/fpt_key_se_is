//your task is to complete this class
public class Book{  
    String name;
    int price;
    public Book(String name, int price) {
        this.name = name;
        this.price = price;
    }  
    //add and complete you other methods (if needed) here   

    @Override
    public String toString() {
        return name + ": " + price;
        
    }

}
