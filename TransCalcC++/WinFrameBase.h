#include <windows.h>
#include <string> 
#include <vector>
#include "Control.h"

using namespace std;


class WinFrameBase 
{
private:


	HINSTANCE _hInstance;
	int _nCmdShow; 
	int _x;
	int _y;
	int _w;
	int _h;
	wstring _name;

	int _timerMs;

	vector<MyControl*> _controls;


	void Init();
	void CreateControls();

protected:

	HWND _hWnd;

	virtual void OnPaint() {}
	virtual void OnCommand( WPARAM wParam, LPARAM lParam) {}

	virtual void OnMouseMove (int x, int y) {}
	virtual void OnMouseLeftButtonDown (int x, int y) {}
	virtual void OnMouseLeftButtonUp (int x, int y) {}
	virtual void OnMouseRightButtonDown (int x, int y) {}
	virtual void OnMouseRightButtonUp (int x, int y) {}
	virtual void OnTimer() {}
	virtual void OnHScroll() {}
	virtual void OnVScroll() {}
	virtual void OnSliderChangePosition() {}


	void ClearWindow();

public:

	WinFrameBase(HINSTANCE hInstance,  int nCmdShow, int x, int y, int w, int h, const wstring& name)
	{
		_hInstance = hInstance;
		_nCmdShow = nCmdShow;
		_x = x;
		_y = y;
		_w = w;
		_h = h;
		_name = name;
		_timerMs = 0;
	}

	void AddControl (MyControl* control) 
	{
		_controls.push_back(control);
		
	}

	void SetTimer(int msec);

	void run();

	static LRESULT CALLBACK WindowProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam);


};