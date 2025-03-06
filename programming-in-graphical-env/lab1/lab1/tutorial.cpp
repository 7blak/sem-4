#include "framework.h"
#include "tutorial.h"
#include "string"
#include "tchar.h"

#define MAX_LOADSTRING 100
const int minSize = 200;
const int maxSize = 400;
static int stepSize = 10;
const int bufSize = 256;
TCHAR buf[bufSize];
static HCURSOR cursor = NULL;

HINSTANCE hInst;
WCHAR szTitle[MAX_LOADSTRING];
WCHAR szWindowClass[MAX_LOADSTRING];

ATOM MyRegisterClass(HINSTANCE hInstance);
BOOL InitInstance(HINSTANCE, int);
LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK About(HWND, UINT, WPARAM, LPARAM);
void GetTextInfoForMouseMsg(WPARAM wParam, LPARAM lParam, const TCHAR* msgName, TCHAR* buf, int bufSize);
void GetTextInfoForKeyMsg(WPARAM wParam, const TCHAR* msgName, TCHAR* buf, int bufSize);

int APIENTRY wWinMain(_In_ HINSTANCE hInstance, _In_opt_ HINSTANCE hPrevInstance, _In_ LPWSTR lpCmdLine, _In_ int nCmdShow)
{
	UNREFERENCED_PARAMETER(hPrevInstance);
	UNREFERENCED_PARAMETER(lpCmdLine);

	LoadString(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
	LoadString(hInstance, IDC_TUTORIAL, szWindowClass, MAX_LOADSTRING);

	MyRegisterClass(hInstance);

	if (!InitInstance(hInstance, nCmdShow))
		return FALSE;

	HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_TUTORIAL));
	MSG msg;
	while(GetMessage(&msg, nullptr, 0, 0))
		if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}

	return static_cast<int>(msg.wParam);
}

ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEXW wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);
	wcex.style = CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc = WndProc;
	wcex.cbClsExtra = 0;
	wcex.cbWndExtra = 0;
	wcex.hInstance = hInstance;
	wcex.hIcon = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_TUTORIAL));
	wcex.hCursor = cursor;
	wcex.hbrBackground = reinterpret_cast<HBRUSH>(COLOR_WINDOW + 1);
	wcex.lpszMenuName = MAKEINTRESOURCE(IDC_TUTORIAL);
	wcex.lpszClassName = szWindowClass;
	wcex.hIconSm = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_SMALL));

	return RegisterClassExW(&wcex);
}

BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
	hInst = hInstance;

	HWND hWnd = CreateWindowW(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, 1920, 1080, nullptr, nullptr, hInstance, nullptr);

	if (!hWnd)
	{
		return FALSE;
	}

	// Making window transparent
	/*
	SetWindowLong(hWnd, GWL_EXSTYLE, GetWindowLong(hWnd, GWL_EXSTYLE) | WS_EX_LAYERED);
	SetLayeredWindowAttributes(hWnd, 0, (255 * 50) / 100, LWA_ALPHA);
	*/
	// Create 9 identical windows positioned in 3 rows and 3 columns
	/*
	int size = 150;
	for (int i = 0; i < 3; i++)
		for (int j = 0; j < 3; j++)
			hWnd = CreateWindow(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW | WS_VISIBLE, i * 150, j * 150, 150, 150, NULL, NULL, hInstance, NULL);
	*/
	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd);

	return TRUE;
}

LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch (message)
	{
	case WM_COMMAND:
	{
		RECT rc;
		GetWindowRect(hWnd, &rc);
		OffsetRect(&rc, 20, 0);
		MoveWindow(hWnd, rc.left, rc.top, rc.right - rc.left, rc.bottom - rc.top, TRUE);
		int wmId = LOWORD(wParam);
		switch (wmId)
		{
		case IDM_ABOUT:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
			break;
		case IDM_EXIT:
			DestroyWindow(hWnd);
			break;
		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
		}
	}
	break;
	case WM_PAINT:
	{
		PAINTSTRUCT ps;
		HDC hdc = BeginPaint(hWnd, &ps);
		//JUST DRAWING TEXT
		/*
		TCHAR s[] = _T("Hello world!");
		RECT rc;
		GetClientRect(hWnd, &rc);
		DrawText(hdc, s, (int)_tcslen(s), &rc, DT_CENTER | DT_VCENTER | DT_SINGLELINE);
		//TextOut(hdc, 0, 0, s, (int)_tcslen(s));
		*/
		// HAVING A PEN TO DRAW
		/*
		HPEN pen = CreatePen(PS_SOLID, 2, RGB(102, 0, 204));
		HPEN oldPen = (HPEN)SelectObject(hdc, pen);
		MoveToEx(hdc, 0, 0, NULL);
		LineTo(hdc, 100, 100);
		SelectObject(hdc, oldPen);
		DeleteObject(pen);
		*/
		// USING A BRUSH
		/*
		HPEN pen = CreatePen(PS_SOLID, 2, RGB(102, 0, 204));
		HPEN oldPen = (HPEN)SelectObject(hdc, pen);
		HBRUSH brush = CreateSolidBrush(RGB(0, 128, 0));
		HBRUSH oldBrush = (HBRUSH)SelectObject(hdc, brush);
		Rectangle(hdc, 20, 20, 120, 120);
		SelectObject(hdc, oldPen);
		DeleteObject(pen);
		SelectObject(hdc, oldBrush);
		DeleteObject(brush);
		*/
		// USING FONTS
		/*
		TCHAR s[] = _T("Hello world!");
		HFONT font = CreateFont(-MulDiv(24, GetDeviceCaps(hdc, LOGPIXELSY), 72),	// Height
			0,																		// Width
			0,																		// Escapement
			0,																		// Orientation
			FW_BOLD,																// Weight
			false,																	// Italic
			TRUE,																	// Underline
			0,																		// StrikeOut
			EASTEUROPE_CHARSET,														// CharSet
			OUT_DEFAULT_PRECIS,														// OutPrecision
			CLIP_DEFAULT_PRECIS,													// ClipPrecision
			DEFAULT_QUALITY,														// Quality
			DEFAULT_PITCH | FF_SWISS,												// PitchAndFamily
			_T("Verdana"));															// Facename
		HFONT oldFont = (HFONT)SelectObject(hdc, font);
		RECT rc;
		GetClientRect(hWnd, &rc);
		DrawText(hdc, s, (int)_tcslen(s), &rc, DT_CENTER | DT_VCENTER | DT_SINGLELINE);
		SelectObject(hdc, oldFont);
		DeleteObject(font);
		*/
		// USING FONTS
		TCHAR s[] = _T("Hello world!");
		HBITMAP bitmap = LoadBitmap(hInst, MAKEINTRESOURCE(IDB_BITMAP1));
		HDC memDC = CreateCompatibleDC(hdc);
		HBITMAP oldBitmap = (HBITMAP)SelectObject(memDC, bitmap);
		BitBlt(hdc, 0, 0, 48, 48, memDC, 0, 0, SRCCOPY);
		StretchBlt(hdc, 200, 100, -200, 100, memDC, 0, 0, 48, 48, SRCCOPY);
		SelectObject(memDC, oldBitmap);
		DeleteObject(bitmap);
		DeleteDC(memDC);
		EndPaint(hWnd, &ps);
	}
	break;
	case WM_DESTROY:
	{
		PostQuitMessage(0);
	}
		break;
	case WM_SIZE:
	{
		int clientWidth = LOWORD(lParam);
		int clientHeight = HIWORD(lParam);
		RECT rc;
		GetWindowRect(hWnd, &rc);
		TCHAR s[256];
		_stprintf_s(s, 256, _T("Window's size: %d x %d Client area's size: %d x %d"), rc.right - rc.left, rc.bottom - rc.top, clientWidth, clientHeight);
		SetWindowText(hWnd, s);
	}
	break;
	case WM_GETMINMAXINFO:
	{
		//MINMAXINFO* minMaxInfo = (MINMAXINFO*)lParam;
		//minMaxInfo->ptMaxSize.x = minMaxInfo->ptMaxTrackSize.x = 500;
		//minMaxInfo->ptMaxSize.y = minMaxInfo->ptMaxTrackSize.y = 200;
	}
	break;
	case WM_SIZING:
	{
		RECT* rc = (RECT*)lParam;
		if (wParam == WMSZ_BOTTOM
			|| wParam == WMSZ_BOTTOMLEFT
			|| wParam == WMSZ_BOTTOMRIGHT
			|| wParam == WMSZ_TOP
			|| wParam == WMSZ_TOPLEFT
			|| wParam == WMSZ_TOPRIGHT)
			rc->right = rc->left + rc->bottom - rc->top;
		else
			rc->bottom = rc->top + rc->right - rc->left;
	}
	break;
	case WM_CREATE:
	{
		//SetTimer(hWnd, 7, 250, NULL);
		cursor = LoadCursor(NULL, IDC_HAND);
	}
	break;
	case WM_SETCURSOR:
	{
		SetCursor(cursor);
	}
	break;
	case WM_TIMER:
	{
		if (wParam == 7)
		{
			RECT rc;
			SystemParametersInfo(SPI_GETWORKAREA, 0, &rc, 0);
			int centerX = (rc.left + rc.right + 1) / 2;
			int centerY = (rc.top + rc.bottom + 1) / 2;
			GetWindowRect(hWnd, &rc);
			int currentSize = max(rc.right - rc.left, rc.bottom - rc.top);
			currentSize += stepSize;
			if (currentSize >= maxSize)
				stepSize = -abs(stepSize);
			else if (currentSize <= minSize)
				stepSize = abs(stepSize);
			MoveWindow(hWnd, centerX - currentSize / 2, centerY - currentSize / 2, currentSize, currentSize, TRUE);
		}
	}
	case WM_LBUTTONDOWN:
	{
		GetTextInfoForMouseMsg(wParam, lParam, _T("LUBTTONDOWN"), buf, bufSize);
		SetWindowText(hWnd, buf);
		SetCapture(hWnd);
	}
	break;
	case WM_LBUTTONUP:
	{
		ReleaseCapture();
		GetTextInfoForMouseMsg(wParam, lParam, _T("LBUTTONUP"), buf, bufSize);
		SetWindowText(hWnd, buf);
	}
	break;
	case WM_RBUTTONDOWN:
	{
		GetTextInfoForMouseMsg(wParam, lParam, _T("RBUTTONDOWN"), buf, bufSize);
		SetWindowText(hWnd, buf);
		SetCapture(hWnd);
	}
	break;
	case WM_RBUTTONUP:
	{
		ReleaseCapture();
		GetTextInfoForMouseMsg(wParam, lParam, _T("RBUTTONUP"), buf, bufSize);
		SetWindowText(hWnd, buf);
	}
	break;
	case WM_LBUTTONDBLCLK:
	{
		GetTextInfoForMouseMsg(wParam, lParam, _T("LBUTTONDBLCLK"), buf, bufSize);
		SetWindowText(hWnd, buf);
	}
	break;
	case WM_MBUTTONDBLCLK:
	{
		GetTextInfoForMouseMsg(wParam, lParam, _T("MBUTTONDBLCLK"), buf, bufSize);
		SetWindowText(hWnd, buf);
	}
	break;
	case WM_RBUTTONDBLCLK:
	{
		GetTextInfoForMouseMsg(wParam, lParam, _T("RBUTTONDBLCLK"), buf, bufSize);
		SetWindowText(hWnd, buf);
	}
	break;
	/*
	case WM_NCHITTEST:
	{
		return HTCAPTION;
	}
	*/
	case WM_KEYDOWN:
	{
		GetTextInfoForKeyMsg(wParam, _T("KEYDOWN"), buf, bufSize);
		SetWindowText(hWnd, buf);
	}
	break;
	case WM_KEYUP:
	{
		GetTextInfoForKeyMsg(wParam, _T("KEYUP"), buf, bufSize);
		SetWindowText(hWnd, buf);
	}
	break;
	case WM_CHAR:
	{
		_stprintf_s(buf, bufSize, _T("WM_CHAR: %c"), (TCHAR)wParam);
		SetWindowText(hWnd, buf);
	}
	break;
	default:
	{
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	}
	return 0;
}

INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);

	switch (message)
	{
	case WM_INITDIALOG:
		return static_cast<INT_PTR>(TRUE);
	case WM_COMMAND:
		if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
		{
			EndDialog(hDlg, LOWORD(wParam));
			return static_cast<INT_PTR>(TRUE);
		}
		break;
	}
	return static_cast<INT_PTR>(FALSE);
}

void GetTextInfoForMouseMsg(WPARAM wParam, LPARAM lParam, const TCHAR* msgName, TCHAR* buf, int bufSize)
{
	short x = (short)LOWORD(lParam);
	short y = (short)HIWORD(lParam);
	_stprintf_s(buf, bufSize, _T("%s x: %d, y: %d, vk:"), msgName, x, y);
	if ((wParam == MK_LBUTTON) != 0)
		_tcscat_s(buf, bufSize, _T(" LEFT"));
	if ((wParam == MK_MBUTTON) != 0)
		_tcscat_s(buf, bufSize, _T(" MIDDLE"));
	if ((wParam == MK_RBUTTON) != 0)
		_tcscat_s(buf, bufSize, _T(" RIGHT"));
}

void GetTextInfoForKeyMsg(WPARAM wParam, const TCHAR* msgName, TCHAR* buf, int bufSize)
{
	static int counter = 0;
	counter++;
	_stprintf_s(buf, bufSize, _T("%s key: %d (counter: %d)"), msgName, wParam, counter);
}