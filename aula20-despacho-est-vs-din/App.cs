using System;

class Point {
    public int x, y;
    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }
    public void Print() { // Método Não Virtual
        Console.WriteLine("[{0}, {1}]", x, y);
    }
    public void Dummy() { // Método Não Virtual
        Console.WriteLine("Dummy");
    }
}

class App {
    static void Main() {
        Point p = null;
        
        // p.Print();  // callvirt Point::Print => Despacho Estatico
        
        p.Dummy();
        
    }
}

