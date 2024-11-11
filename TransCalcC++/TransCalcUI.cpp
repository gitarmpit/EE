#include "TransCalc.h"

static int WINAPI WinMain(HINSTANCE hInstance,
                   HINSTANCE hPrevInstance,
                   LPSTR lpCmdLine,
                   int nCmdShow)
{


	TransCalc calc (hInstance,  nCmdShow, 300, 300, 700, 600, L"Transformer Calculator");
	calc.run();

	return 0;

}