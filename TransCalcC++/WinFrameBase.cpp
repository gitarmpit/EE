#include "WinFrameBase.h"
#include <WindowsX.h>

//static LRESULT CALLBACK WindowProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam);

void WinFrameBase::Init()
{
	WNDCLASSEX wc;

	ZeroMemory(&wc, sizeof(WNDCLASSEX));

	wc.lpfnWndProc = WinFrameBase::WindowProc;

	wc.cbSize = sizeof(WNDCLASSEX);
	wc.style = CS_HREDRAW | CS_VREDRAW;
	wc.hInstance = _hInstance;
	wc.hCursor = LoadCursor(NULL, IDC_ARROW);
	wc.hbrBackground = (HBRUSH)COLOR_WINDOW;
	//wc.hbrBackground = CreateSolidBrush(RGB(255, 255, 255));
	wc.lpszClassName = L"WindowClass1";

	RegisterClassEx(&wc);

	_hWnd = CreateWindowEx(NULL,
		L"WindowClass1",    // name of the window class
		_name.c_str(),   // title of the window
		WS_OVERLAPPED | WS_SYSMENU,    // window style
		_x,    // x-position of the window
		_y,    // y-position of the window
		_w,    // width of the window
		_h,    // height of the window
		NULL,    // we have no parent window, NULL
		NULL,    // we aren't using menus, NULL
		_hInstance,    // application handle
		NULL);    // used with multiple windows, NULL


	SetWindowLong(_hWnd, GWLP_USERDATA, (long)this);

	CreateControls();

	ShowWindow(_hWnd, _nCmdShow);

	if (_timerMs != 0) 
	{
		::SetTimer (_hWnd, NULL, _timerMs, NULL);
	}

}

void WinFrameBase::run()
{
	Init();
	MSG msg;

	while(TRUE)
	{
		while(PeekMessage(&msg, NULL, 0, 0, PM_REMOVE))
		{
			if (IsDialogMessage(_hWnd, &msg) == 0)
			{
				TranslateMessage(&msg);
				DispatchMessage(&msg);
			}
		}

		if(msg.message == WM_QUIT) //DESTROY HAPPENS FIRST in WindowProc, PostQuitMessage posts WM_QUIT
		{
			break;
		}

		Sleep(10);
	}

	//return msg.wParam;
}


void WinFrameBase::CreateControls() 
{
	for (int i = 0; i < _controls.size(); ++i) 
	{
		_controls[i]->Create(_hWnd);
	}
}

LRESULT CALLBACK WinFrameBase::WindowProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	WinFrameBase* window = NULL;
	LONG_PTR user_data = GetWindowLongPtr(hWnd, GWLP_USERDATA);
	window = (WinFrameBase*)(user_data);

	switch(message)
	{
	case WM_CREATE:
		{
			if (window != NULL)
			{
				window->CreateControls();
			}
			break;
		}

	case WM_DESTROY:
		{
			PostQuitMessage(0);
			return 0;
		} 
	case WM_CHAR:
		{
			break;
		}
	case WM_COMMAND:
		{
			if (window != NULL)
			{
				window->OnCommand(wParam, lParam);
			}
		}
	case WM_PAINT:
		{
			if (window != NULL)
			{
				window->OnPaint();
			}
			break;
		}

	case WM_LBUTTONDOWN:
		{
			if (window != NULL) 
			{
				//int x = LOWORD(lParam);
				//int y = HIWORD(lParam);

				int x = GET_X_LPARAM(lParam); 
				int y = GET_Y_LPARAM(lParam); 
				window->OnMouseLeftButtonDown (x, y);
			}
			break;
		}

	case WM_RBUTTONDOWN:
		{
			if (window != NULL) 
			{
				//int x = LOWORD(lParam);
				//int y = HIWORD(lParam);

				int x = GET_X_LPARAM(lParam); 
				int y = GET_Y_LPARAM(lParam); 
				window->OnMouseRightButtonDown (x, y);
			}
			break;
		}


	case WM_LBUTTONUP:
		{
			if (window != NULL) 
			{
				//int x = LOWORD(lParam);
				//int y = HIWORD(lParam);

				int x = GET_X_LPARAM(lParam); 
				int y = GET_Y_LPARAM(lParam); 
				window->OnMouseLeftButtonUp (x, y);
			}
			break;
		}


	case WM_RBUTTONUP:
		{
			if (window != NULL) 
			{
				//int x = LOWORD(lParam);
				//int y = HIWORD(lParam);

				int x = GET_X_LPARAM(lParam); 
				int y = GET_Y_LPARAM(lParam); 
				window->OnMouseRightButtonUp (x, y);
			}
			break;
		}


	case WM_MOUSEMOVE:
		{
			if (window != NULL) 
			{
				int x = GET_X_LPARAM(lParam); 
				int y = GET_Y_LPARAM(lParam); 
				window->OnMouseMove (x, y);
			}
			break;
		}

	case WM_TIMER:
		{
			if (window != NULL) 
			{
				window->OnTimer();
			}

			break;
		}

	case WM_HSCROLL:
		{
			window->OnHScroll();
			if (LOWORD(wParam) == TB_THUMBPOSITION)
			{
				window->OnSliderChangePosition();
				break;
			}
		}

	case WM_VSCROLL:
		{
			window->OnVScroll();
			if (LOWORD(wParam) == TB_THUMBPOSITION)
			{
				window->OnSliderChangePosition();
				break;
			}
			break;
		}
		
	}


	return DefWindowProc (hWnd, message, wParam, lParam);

}

void WinFrameBase::ClearWindow() 
{
	InvalidateRect (_hWnd, NULL, true);
}


void WinFrameBase::SetTimer(int msec) 
{
	_timerMs = msec;
}