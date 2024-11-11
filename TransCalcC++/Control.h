#ifndef _CONTROL_H 
#define _CONTROL_H

#include <Windows.h>
#include <string> 
#include <vector>
#include <CommCtrl.h>

using namespace std;

class MyControl 
{
private:

	friend class ButtonGroup;
	DWORD  _hMenu;

	BOOL _created;
	BOOL _inited;

	static int _menuCounter;

	const wchar_t* _windowType;
	const wchar_t* _windowName;
	int _x;
	int _y;
	int _w;
	int _h;
	HWND _parent;

protected:
	
	HWND _hWnd;
	wchar_t tmp[256];
	DWORD  _style;
	DWORD  _ex_style;

public:

	MyControl(const wchar_t* windowType) 
	{
		_style = WS_VISIBLE | WS_CHILD;
		_windowType = windowType;
		_created = false;
		_inited = false;
		_ex_style = 0;
	}

	void Init (const wchar_t* windowName, int x, int y, int w, int h) 
	{
		_windowName = windowName;
		_x = x;
		_y = y;
		_w = w;
		_h = h;
		_inited = true;
	}

	virtual void Create(HWND parent) 
	{
		if (_inited && !_created) 
		{
			_hMenu = _menuCounter++;
			_parent = parent;
			_hWnd = CreateWindowEx(_ex_style, _windowType, _windowName, _style, _x, _y, _w, _h, parent, (HMENU)_hMenu,  GetModuleHandle(NULL), NULL);	

			_created = true;
		}
	}

	void SetText (const wchar_t* txt) 
	{
		SendMessage(_hWnd, WM_SETTEXT, NULL, (LPARAM) txt); 
	}

	wchar_t* GetText() 
	{
		GetWindowText (_hWnd, tmp, sizeof tmp);
		return tmp;
	}

	void SetRightAdjusted() 
	{
		_style |= SS_RIGHT;
	}

	void SetLeftAdjusted() 
	{
		_style |= SS_LEFT;
	}

	void SetReadOnly() 
	{
		_style |= ES_READONLY;
		_style &= ~WS_TABSTOP;
	}


	DWORD GetHmenu() { return _hMenu; }

};

class AlphaNumeric : public MyControl
{
public:
	AlphaNumeric (const wchar_t* type) : MyControl (type)
	{
	}

	void SetDouble (double value) 
	{
		swprintf (tmp, 255, L"%5.2f", value);
		SetText (tmp);
	}

	void SetInt (int value) 
	{
		swprintf (tmp, 255, L"%d", value);
		SetText (tmp);
	}


	double GetDouble () 
	{
		wchar_t* t = GetText();
		return _wtof (t);
	}

	int GetInt () 
	{
		wchar_t* t = GetText();
		return _wtoi (t);
	}



};

class Label : public AlphaNumeric 
{
public: 

	Label () : AlphaNumeric (L"STATIC")
	{
		//_style |= SS_ETCHEDFRAME;
		//_style |= SS_SUNKEN;
	}
};

class Edit : public AlphaNumeric 
{
public: 

	Edit () : AlphaNumeric(L"EDIT")
	{
		_style |= WS_TABSTOP;
		_ex_style |= WS_EX_CLIENTEDGE;
	}


};

class EditReadOnly : public Edit
{
public: 

	EditReadOnly ()
	{
		SetReadOnly();
	}
};



class Button : public MyControl 
{
public: 

	Button () : MyControl (L"BUTTON")
	{
		_style |= WS_TABSTOP | BS_DEFPUSHBUTTON;
	}
};

class DropdownList : public MyControl 
{
private:
	vector<wstring> _items;

public: 

	DropdownList () : MyControl (L"COMBOBOX")
	{
		_style |= CBS_DROPDOWNLIST | CBS_HASSTRINGS;
	}

	virtual void Create(HWND parent) 
	{
		MyControl::Create (parent);

		for (int i = 0; i < _items.size(); ++i) 
		{
			SendMessage(_hWnd, CB_ADDSTRING, 0,(LPARAM) _items[i].c_str());
		}

		SendMessage(_hWnd, CB_SETCURSEL, (WPARAM)0, (LPARAM)0);
	}

	void AddItem (const wstring& txt) 
	{
		_items.push_back (txt);
	}

	int GetCurrentItem() 
	{
		return (int)SendMessage(_hWnd, CB_GETCURSEL, (WORD)0, 0L);
	}

};



class Groupable : public MyControl 
{

public:

	Groupable () : MyControl (L"BUTTON")
	{
	}

	virtual void Create(HWND parent) 
	{
		MyControl::Create (parent);
		if ((_style & WS_GROUP) == WS_GROUP)
		{
			SendMessage(_hWnd, BM_SETCHECK, BST_CHECKED, 0); 
			
		}
	}

	void StartGroup() 
	{
		_style |= WS_GROUP | BS_GROUPBOX;
	}

	bool IsChecked() 
	{
		return SendMessage(_hWnd , BM_GETCHECK, (WPARAM) NULL, (LPARAM) NULL ) == BST_CHECKED;
	}

	void SetTextOnLeft() 
	{
		_style |= BS_LEFTTEXT;
	}

};


class CheckBox : public Groupable
{

public:

	CheckBox()
	{
		//_style |= BS_CHECKBOX | BS_PUSHLIKE;
		_style |= BS_AUTOCHECKBOX;
	}

};

class RadioButton : public Groupable
{

public:

	RadioButton()
	{
		_style |= BS_AUTORADIOBUTTON;
	}


};

class GroupBox : public Groupable 
{
public:
	GroupBox() 
	{
		_style |= BS_GROUPBOX;
	}
};


class TrackBar : public MyControl 
{
private:

	int _min; 
	int _max;

public:
	TrackBar(int min, int max) : MyControl (TRACKBAR_CLASS) 
	{
		_style |= TBS_AUTOTICKS; // |  TBS_ENABLESELRANGE;
		_min = min;
		_max = max;
	}

	virtual void Create(HWND parent) 
	{
		MyControl::Create (parent);

		SendMessage(_hWnd, TBM_SETRANGE, (WPARAM) TRUE, (LPARAM) MAKELONG(_min, _max));  
	}

	int GetValue() 
	{
		return SendMessage(_hWnd, TBM_GETPOS, 0, 0); 	
	}

};







#endif