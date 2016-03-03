public class Ponto{

	public final int  _y, _z, _x;

	public Ponto(int x, int y, int z)
	{
		this._x = x;
		this._y = y;
		this._z = z;
	}

	public double getModule() {	 
		return Math.sqrt((double)_x*_x + _y*_y + _z*_z);
	}

	public void print(){
		String msg = String.format("Version 4 Point (x = %d, y = %d, z = %d)", _x, _y, _z);
        System.out.println(msg);
	}

}