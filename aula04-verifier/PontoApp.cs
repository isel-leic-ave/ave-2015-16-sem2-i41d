using System; // <=> import java.lang;

class PontoApp{

	public static void Main(String [] args)
	{
        Ponto p = new Ponto(5, 7, 9);
		p.Print();
        String msg = String.Format("p._x = {0}", p._x);
        Console.WriteLine(msg);
	}

}