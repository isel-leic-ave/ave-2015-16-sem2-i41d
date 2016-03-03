class PontoApp{

	public static void main(String [] args)
	{
        Ponto p = new Ponto(5, 7, 9);
		p.print();
        String msg = String.format("p._x = %d", p._x);
        System.out.println(msg);
	}

}