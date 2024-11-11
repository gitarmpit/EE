#ifndef _TRANS_CALC_H
#define _TRANS_CALC_H

#include "WinFrameBase.h"
#include "Control.h"

class TransCalc : public WinFrameBase 
{
private:

	Label		  _labelAwg;
	DropdownList  _dropdownAwg;
	Label		  _labelDmm;

	Label		  _labelBobbinLength;
	Edit          _editBobbinLength;         

	Label		  _labelBobbinWidth;
	Edit          _editBobbinWidth;         

	Label		  _labelBobbinHeight;
	Edit          _editBobbinHeight;         

	Label		  _labelWfactor;
	Edit          _editWfactor;         

	Label		  _labelTurns;
	Edit          _editTurns;         

	Label		  _labelTurnsPerLayer;
	Edit          _editTurnsPerLayer;

	Label		  _labelCoreH;
	Edit          _editCoreH;

	Label		  _labelCoreW;
	Edit          _editCoreW;


	Label         _labelResultTotalLayers;
	EditReadOnly  _editResultTotalLayers;

	Label         _labelResultTurnsPerLayer;
	EditReadOnly  _editResultTurnsPerLayer;


	Label		  _labelResultLastLayerTurns;
	EditReadOnly  _editResultLastLayerTurns;

	Label         _labelResultLengthMeters;
	EditReadOnly  _editResultLengthMeters;

	Label         _labelResultLengthFeet;
	EditReadOnly  _editResultLengthFeet;

	Label         _labelResultThickness;
	EditReadOnly  _editResultThickness;

	Label         _labelResultResistivity;
	EditReadOnly  _editResultResistivity;

	Button        _runButton;

	int           Calc();

public:

	TransCalc(HINSTANCE hInstance,  int nCmdShow, int x, int y, int w, int h, const wstring& name);

	virtual void OnPaint();

	virtual void OnCommand (WPARAM wParam, LPARAM lParam);

};


#endif