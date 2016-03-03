// Ponto.cpp : Defines the exported functions by Ponto.dll
//

#include "Ponto.h"
#include <math.h>
#include <iostream>

/*
* This is the constructor of a class that has been exported.
* see aula01_Ponto.h for the class definition
*/
Ponto::Ponto(int x, int y, int z)
{
	this->_x = x;
	this->_y = y;
	this->_z = z;
}

double Ponto::getModule() {
	return sqrt((double)_x*_x + _y*_y + _z*_z);
}

void Ponto::print(){
	printf("Print V4 SUPER (x = %d, y = %d, z = %d)\n", _x, _y, _z);
}
