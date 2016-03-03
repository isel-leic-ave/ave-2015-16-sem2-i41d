using System; // <=> import java.lang;

public class Ponto{

	public readonly int  _y, _z, _x;

	public Ponto(int x, int y, int z)
	{
		this._x = x;
		this._y = y;
		this._z = z;
	}

	public double GetModule() {	 
		return Math.Sqrt((double)_x*_x + _y*_y + _z*_z);
	}

	public void Print(){
		String msg = String.Format("Version 4 Point (x = {0}, y = {1}, z = {2})", _x, _y, _z);
        Console.WriteLine(msg);
	}

}