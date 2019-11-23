// ======= DO NOT EDIT MAIN FUNCTION ============
import java.io.*;
import java.util.*;
class Main {
    public static void display(ArrayList<Book> a) {
        System.out.println("Display: ");
        for (int i = 0; i < a.size(); i++) {
            System.out.println(a.get(i));
        }
    }
   public static void main(String args[]) throws Exception {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        System.out.print("Enter number of Book: ");
        int n = Integer.parseInt(in.readLine());
        ArrayList<Book> a = new ArrayList();      
         for(int i = 0; i < n; i++){
             System.out.println("");
             System.out.print("Enter book name: "); 
             String name = in.readLine();           
             System.out.print("Enter book price: ");
             int price = Integer.parseInt(in.readLine());          
             a.add(new Book(name,price));
         }   
        System.out.print("Enter test function (3-f3;4-f4): ");
        int c = Integer.parseInt(in.readLine());
        IBook i = new MyBook();
        System.out.println("OUTPUT:");    
        switch (c) {
            case 3:
                System.out.println(i.f3(a));
                break;
            case 4:
                i.f4(a);
                display(a);
                break;
            default:
                break;
        }
   }
 }
