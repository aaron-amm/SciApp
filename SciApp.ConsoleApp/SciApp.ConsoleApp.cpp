#include "stdafx.h"
#include <string>
#include <iostream>

using namespace std;

int main() {

	//pointer variable
	int a = 3;
	cout << "a is " << a << endl;
	int* pA = &a;
	*pA = 4;
	cout << "a is " << a << endl;
	int b = 100;
	pA = &b;
	(*pA)++;
	cout << "a " << a << ", *pA " << *pA << endl;

	//reference variable
	int& rA = a;
	rA = 5;
	cout << "a is " << a << endl;

	return 0;

}

