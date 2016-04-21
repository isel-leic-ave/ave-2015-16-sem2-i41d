using System;

public class Demo03 {

    public static void Main() {
        int n = 65;
        Object o = n; // ldloc0; box Int32; stloc1;
        n = (int) o; // ldloc1; unbox; stloc0;
    }
}