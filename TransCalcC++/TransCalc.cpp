#include "TransCalc.h"

typedef struct _awg_info 
{
	wstring awg_label;
	double  awg_value;
} AWG_INFO;




static AWG_INFO awg_info[] = 
{
	{ L"AWG 35", 0.14 },
	{ L"AWG 34", 0.16 },
	{ L"AWG 33", 0.18 },
	{ L"AWG 32", 0.20 },
	{ L"AWG 30", 0.25 },
	{ L"AWG 28", 0.33 },
	{ L"AWG 26", 0.41 },
	{ L"AWG 25", 0.46 },
	{ L"AWG 24", 0.51 },
	{ L"AWG 22", 0.64 },
	{ L"AWG 20", 0.81 },
	{ L"AWG 18", 1.02 },
	{ L"AWG 16", 1.29 },
	{ L"AWG 14", 1.63 },
	{ L"AWG 12", 2.05 },
	{ L"AWG 10", 2.59 },
};

TransCalc::TransCalc(HINSTANCE hInstance,  int nCmdShow, int x, int y, int w, int h, const wstring& name) : 
WinFrameBase(hInstance, nCmdShow, x, y, w, h, name)
{
	static int xoff = 50;
	static int yoff = 20;
	static int ydel = 40;
	static int xoff2 = xoff + 350;

	_labelAwg.Init (L"AWG: ", xoff, yoff, 100, 20);
	_labelAwg.SetRightAdjusted();

	_dropdownAwg.Init (NULL, xoff + 100,  yoff,   100,   300);

	for (int i = 0; i < sizeof(awg_info)/sizeof(AWG_INFO); ++i)
	{
		_dropdownAwg.AddItem (awg_info[i].awg_label.c_str());
    }


	_labelDmm.Init (L"", xoff + 200, yoff, 100, 20);

	_labelBobbinLength.Init (L"Bobbin L, cm: ", xoff, yoff + ydel, 100, 20);
	_labelBobbinLength.SetRightAdjusted();
	_editBobbinLength.Init (L"", xoff + 100,  yoff + ydel, 100, 20);

	_labelBobbinWidth.Init (L"Bobbin W, cm: ", xoff, yoff + ydel*2, 100, 20);
	_labelBobbinWidth.SetRightAdjusted();
	_editBobbinWidth.Init (L"", xoff + 100,  yoff + ydel*2, 100, 20);

	_labelBobbinHeight.Init (L"Bobbin H, cm: ", xoff, yoff + ydel*3, 100, 20);
	_labelBobbinHeight.SetRightAdjusted();
	_editBobbinHeight.Init (L"", xoff + 100,  yoff + ydel*3,   100,   20);

	_labelWfactor.Init (L"W factor: ", xoff, yoff + ydel*4, 100, 20);
	_labelWfactor.SetRightAdjusted();
	_editWfactor.Init (L"", xoff + 100,  yoff + ydel*4,   100,   20);

	_labelCoreW.Init (L"Core W, cm: ", xoff, yoff + ydel*5, 100, 20);
	_labelCoreW.SetRightAdjusted();
	_editCoreW.Init (L"", xoff + 100,  yoff + ydel*5,   100,   20);

	_labelCoreH.Init (L"Core H, cm: ", xoff, yoff + ydel*6, 100, 20);
	_labelCoreH.SetRightAdjusted();
	_editCoreH.Init (L"", xoff + 100,  yoff + ydel*6,   100,   20);

	_labelTurns.Init (L"Turns: ", xoff-10, yoff + ydel*7, 100, 20);
	_labelTurns.SetRightAdjusted();
	_editTurns.Init (L"", xoff + 100,  yoff + ydel*7,   100,   20);

	_labelTurnsPerLayer.Init (L"Turns per layer: ", xoff-10, yoff + ydel*8, 110, 20);
	_labelTurnsPerLayer.SetRightAdjusted();
	_editTurnsPerLayer.Init (L"", xoff + 100,  yoff + ydel*8,   100,   20);

	_labelResultTotalLayers.Init (L"Total layers: ", xoff2, yoff, 120, 20);
	_labelResultTotalLayers.SetRightAdjusted();
	_editResultTotalLayers.Init (L"",  xoff2 + 120,  yoff,   100,   20);

	_labelResultTurnsPerLayer.Init (L"Turns per layer: ", xoff2, yoff + ydel, 120, 20);
	_labelResultTurnsPerLayer.SetRightAdjusted();
	_editResultTurnsPerLayer.Init (L"", xoff2 + 120,  yoff + ydel,   100,   20);

	_labelResultLastLayerTurns.Init (L"Last layer turns: ", xoff2, yoff + ydel*2, 120, 20);
	_labelResultLastLayerTurns.SetRightAdjusted();
	_editResultLastLayerTurns.Init (L"", xoff2 + 120,  yoff + ydel*2,   100,   20);

	_labelResultLengthMeters.Init (L"Length, m: ", xoff2, yoff + ydel*3, 120, 20);
	_labelResultLengthMeters.SetRightAdjusted();
	_editResultLengthMeters.Init (L"", xoff2 + 120,  yoff + ydel*3,   100,   20);

	_labelResultLengthFeet.Init (L"Length, ft: ", xoff2, yoff + ydel*4, 120, 20);
	_labelResultLengthFeet.SetRightAdjusted();
	_editResultLengthFeet.Init (L"", xoff2 + 120,  yoff + ydel*4,   100,   20);

	_labelResultThickness.Init ( L"Thickness, mm: ", xoff2, yoff + ydel*5, 120, 20);
	_labelResultThickness.SetRightAdjusted();
	_editResultThickness.Init (L"", xoff2 + 120,  yoff + ydel*5,   100,   20);

	_labelResultResistivity.Init (L"Resistivity, ohm: ", xoff2, yoff + ydel*6, 120, 20);
	_labelResultResistivity.SetRightAdjusted();
	_editResultResistivity.Init (L"", xoff2 + 120,  yoff + ydel*6,   100,   20);

	
	_runButton.Init (L"Calculate", xoff + 100, yoff + ydel*9, 100, 24);

	AddControl (&_labelAwg);
	AddControl (&_dropdownAwg);
	AddControl (&_labelDmm);

	AddControl (&_labelBobbinLength);
	AddControl (&_editBobbinLength);         

	AddControl (&_labelBobbinWidth);
	AddControl (&_editBobbinWidth);         

	AddControl (&_labelBobbinHeight);
	AddControl (&_editBobbinHeight);         

	AddControl (&_labelWfactor);
	AddControl (&_editWfactor);         

	AddControl (&_labelCoreW);
	AddControl (&_editCoreW);         

	AddControl (&_labelCoreH);
	AddControl (&_editCoreH);         

	AddControl (&_labelTurns);
	AddControl (&_editTurns);         

	AddControl (&_labelTurnsPerLayer);
	AddControl (&_editTurnsPerLayer);         

	AddControl (&_labelResultTotalLayers);
	AddControl (&_editResultTotalLayers);

	AddControl (&_labelResultTurnsPerLayer);
	AddControl (&_editResultTurnsPerLayer);


	AddControl (&_labelResultLastLayerTurns);
	AddControl (&_editResultLastLayerTurns);

	AddControl (&_labelResultLengthMeters);
	AddControl (&_editResultLengthMeters);

	AddControl (&_labelResultLengthFeet);
	AddControl (&_editResultLengthFeet);

	AddControl (&_labelResultThickness);
	AddControl (&_editResultThickness);

	AddControl (&_labelResultResistivity);
	AddControl (&_editResultResistivity);

	AddControl (&_runButton);


}



void TransCalc::OnCommand (WPARAM wParam, LPARAM lParam)
{
	if (LOWORD(wParam) == _runButton.GetHmenu()) 
	{
		Calc();
	}
	else if (LOWORD(wParam) == _dropdownAwg.GetHmenu() && (HIWORD(wParam) == CBN_SELCHANGE))
	{
		int d_idx = _dropdownAwg.GetCurrentItem();
		double d =  awg_info[d_idx].awg_value;
		_labelDmm.SetDouble (d);
	}
}


void TransCalc::OnPaint()
{
}

int TransCalc::Calc() 
{

	//cm
	double core_w = _editCoreW.GetDouble();
	double core_h = _editCoreH.GetDouble();

	//bobbin l w h in mm
	double l = _editBobbinLength.GetDouble() * 10.;
	double w = _editBobbinWidth.GetDouble() * 10.;
	double h = _editBobbinHeight.GetDouble() * 10.;
	double wfactor = _editWfactor.GetDouble();
	double N = _editTurns.GetInt();

	if ((int)N == 0) 
	{
		double E = 120.;
		double B = 1.;
		double f = 60.;

		N = E / (4.443 * B * core_w*core_h*.0001 * f);
		_editTurns.SetInt(N);
	}

	int d_idx = _dropdownAwg.GetCurrentItem();
	double d =  awg_info[d_idx].awg_value; //mm

	double dl = d/wfactor;
	double dh = d/wfactor;

	if ((int)w == 0 || (int)h == 0 || (int)w == 0 || (int)N == 0) 
	{
		return -1;
	}

	int turnsPerLayer = _editTurnsPerLayer.GetInt();

	if (turnsPerLayer == 0) 
	{
		turnsPerLayer = (int)(l / dl);
	}

	if (turnsPerLayer == 0)
	{
		return -1;
	}

	int totalLayers = N / turnsPerLayer;



	int lastTurns = N - (totalLayers * turnsPerLayer);

	if (lastTurns == 0)
	{
		lastTurns = turnsPerLayer;
	}
	else 
	{
		++totalLayers;
	}
        
	double length = 0; 
	double turnsPerLayerSaved = turnsPerLayer;

	for (int i = 0; i < totalLayers; ++i)
	{
		double delta = dh * (double)i;
		if (i == totalLayers - 1)
		{
			turnsPerLayerSaved = lastTurns;
		}

		double p = 2.0 * (w + h + 2.0*delta);
		length += p * turnsPerLayerSaved;

	}

	double length_m = length / 1000.;
	double length_f = length * 0.0032808;
	double thickness = totalLayers * dh;
    double resistivity = length / 1000 * 1.678e-8 / (3.14159 * d/2/1000. * d/2/1000.);

	_editResultLengthMeters.SetDouble (length_m);
	_editResultLengthFeet.SetDouble (length_f);
	_editResultThickness.SetDouble (thickness);
	_editResultResistivity.SetDouble (resistivity);

	_editResultTotalLayers.SetInt (totalLayers);
	_editResultTurnsPerLayer.SetInt (turnsPerLayer);
	_editResultLastLayerTurns.SetInt (lastTurns);

	return 0;

}

/*
int WINAPI WinMain(HINSTANCE hInstance,
                   HINSTANCE hPrevInstance,
                   LPSTR lpCmdLine,
                   int nCmdShow)
{


	TransCalc calc (hInstance,  nCmdShow, 300, 300, 700, 600, L"Transformer Calculator");
	calc.run();

	return 0;

}
*/
