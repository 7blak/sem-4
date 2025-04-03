#include "battleships.h"
#include <dwmapi.h>
#include <ctime>

std::wstring const app_battleships::s_class_name{ L"Battleships window" };

volatile static long long timeElapsed = 0;

bool app_battleships::register_class()
{
	WNDCLASSEXW desc{};
	if (GetClassInfoExW(m_instance, s_class_name.c_str(), &desc) != 0)
		return true;
	desc = {
		.cbSize = sizeof(WNDCLASSEXW),
		.lpfnWndProc = window_proc_static,
		.hInstance = m_instance,
		.hIcon = LoadIconW(m_instance, MAKEINTRESOURCEW(IDI_ICON)),
		.hCursor = LoadCursorW(nullptr, L"IDC_ARROW"),
		.hbrBackground = CreateSolidBrush(RGB(164,174,196)),
		.lpszMenuName = MAKEINTRESOURCE(IDR_MENU),
		.lpszClassName = s_class_name.c_str()
	};
	return RegisterClassExW(&desc) != 0;
}

HWND app_battleships::create_window(DWORD style, HWND parent, LPCWSTR name, DWORD exStyle, char wndType)
{
	switch (wndType)
	{
	default:
	case 'S':
	{
		int screenWidth = GetSystemMetrics(SM_CXSCREEN);
		int screenHeight = GetSystemMetrics(SM_CYSCREEN);

		int windowWidth = 600;
		int windowHeight = 250;

		int windowX = (screenWidth - windowWidth) / 2;
		int windowY = 3 * screenHeight / 4 - windowHeight;

		HWND window = CreateWindowExW(
			exStyle,
			s_class_name.c_str(),
			name,
			style,
			windowX,
			windowY,
			windowWidth,
			windowHeight,
			parent,
			nullptr,
			m_instance,
			this
		);
		return window;
	}
	case 'B':
	{
		RECT size;
		switch (currGridSize)
		{
		default:
		case 10:
		{
			size = { 0, 0, Board10::length, Board10::length };
			AdjustWindowRectEx(&size, style, false, 0);
			HWND window = CreateWindowExW(
				exStyle,
				s_class_name.c_str(),
				name,
				style,
				CW_USEDEFAULT,
				0,
				size.right - size.left,
				size.bottom - size.top,
				parent,
				nullptr,
				m_instance,
				this
			);
			for (auto& f : m_board.fields())
				CreateWindowExW(
					0,
					L"STATIC",
					nullptr,
					WS_CHILD | WS_VISIBLE | SS_CENTER,
					f.position.left,
					f.position.top,
					f.position.right - f.position.left,
					f.position.bottom - f.position.top,
					window,
					nullptr,
					m_instance,
					nullptr
				);
			return window;
		}
		case 15:
		{
			size = { 0, 0, Board15::length, Board15::length };
			AdjustWindowRectEx(&size, style, false, 0);
			HWND window = CreateWindowExW(
				exStyle,
				s_class_name.c_str(),
				name,
				style,
				CW_USEDEFAULT,
				0,
				size.right - size.left,
				size.bottom - size.top,
				parent,
				nullptr,
				m_instance,
				this
			);
			for (auto& f : m_board15.fields())
				CreateWindowExW(
					0,
					L"STATIC",
					nullptr,
					WS_CHILD | WS_VISIBLE | SS_CENTER,
					f.position.left,
					f.position.top,
					f.position.right - f.position.left,
					f.position.bottom - f.position.top,
					window,
					nullptr,
					m_instance,
					nullptr
				);
			return window;
		}
		case 20:
		{
			size = { 0, 0, Board20::length, Board20::length };
			AdjustWindowRectEx(&size, style, false, 0);
			HWND window = CreateWindowExW(
				exStyle,
				s_class_name.c_str(),
				name,
				style,
				CW_USEDEFAULT,
				0,
				size.right - size.left,
				size.bottom - size.top,
				parent,
				nullptr,
				m_instance,
				this
			);
			for (auto& f : m_board20.fields())
				CreateWindowExW(
					0,
					L"STATIC",
					nullptr,
					WS_CHILD | WS_VISIBLE | SS_CENTER,
					f.position.left,
					f.position.top,
					f.position.right - f.position.left,
					f.position.bottom - f.position.top,
					window,
					nullptr,
					m_instance,
					nullptr
				);
			return window;
		}
		}
		/*
		AdjustWindowRectEx(&size, style, false, 0);
		HWND window = CreateWindowExW(
			exStyle,
			s_class_name.c_str(),
			name,
			style,
			CW_USEDEFAULT,
			0,
			size.right - size.left,
			size.bottom - size.top,
			parent,
			nullptr,
			m_instance,
			this
		);
		for (auto& f : m_board.fields())
			CreateWindowExW(
				0,
				L"STATIC",
				nullptr,
				WS_CHILD | WS_VISIBLE | SS_CENTER,
				f.position.left,
				f.position.top,
				f.position.right - f.position.left,
				f.position.bottom - f.position.top,
				window,
				nullptr,
				m_instance,
				nullptr
			);
		return window;
		*/
	}
	}
}

LRESULT app_battleships::window_proc_static(HWND window, UINT message, WPARAM wparam, LPARAM lparam)
{
	app_battleships* app = nullptr;
	if (message == WM_NCCREATE)
	{
		app = static_cast<app_battleships*>(reinterpret_cast<LPCREATESTRUCTW>(lparam)->lpCreateParams);
		SetWindowLongPtrW(window, GWLP_USERDATA, reinterpret_cast<LONG_PTR>(app));
	}
	else
		app = reinterpret_cast<app_battleships*>(GetWindowLongPtrW(window, GWLP_USERDATA));
	LRESULT res = app ? app->window_proc(window, message, wparam, lparam) : DefWindowProcW(window, message, wparam, lparam);
	if (message == WM_NCDESTROY)
		SetWindowLongPtrW(window, GWLP_USERDATA, 0);
	return res;
}

LRESULT app_battleships::window_proc(HWND window, UINT message, WPARAM wparam, LPARAM lparam)
{
	switch (message)
	{
	case WM_CLOSE:
		KillTimer(window, 1);
		DestroyWindow(m_main);
		return 0;
	case WM_DESTROY:
		if (window == m_main)
			PostQuitMessage(EXIT_SUCCESS);
		return 0;
	case WM_CTLCOLORSTATIC:
		return reinterpret_cast<INT_PTR>(m_field_brush);
	case WM_COMMAND:
		switch (LOWORD(wparam))
		{
		case ID_MENU_EASY10X10:
			ChangeGridSize(window, 10);
			break;
		case ID_MENU_MEDIUM15X15:
			ChangeGridSize(window, 15);
			break;
		case ID_MENU_HARD20X20:
			ChangeGridSize(window, 20);
			break;
		}
		break;
	case WM_TIMER:
	{
		static int secondsElapsed = 0;
		secondsElapsed++;
		WCHAR title[256];
		wsprintf(title, L"BATTLESHIPS: %d", secondsElapsed);
		SetWindowText(window, title);
		break;
	}
	}
	return DefWindowProcW(window, message, wparam, lparam);
}

void app_battleships::ChangeGridSize(HWND window, int gridsize)
{
	DWORD popup_style = WS_OVERLAPPED | WS_CAPTION;
	if (gridsize == currGridSize)
		return;
	currGridSize = gridsize;
	RECT rect;
	GetWindowRect(window, &rect);
	DestroyWindow(m_popup1);
	DestroyWindow(m_popup2);
	m_popup1 = create_window(popup_style, m_main, L"BATTLESHIPS - MY", 0, 'B');
	m_popup2 = create_window(popup_style, m_main, L"BATTLESHIPS - PC", 0, 'B');
	SetMenu(m_popup1, NULL);
	SetMenu(m_popup2, NULL);
	ShowWindow(m_popup1, SW_SHOWNA);
	ShowWindow(m_popup2, SW_SHOWNA);
}

app_battleships::app_battleships(HINSTANCE instance) : m_instance{ instance }, m_popup1{}, m_popup2{}, m_main {}, m_field_brush(CreateSolidBrush(RGB(255, 255, 255)))
{
	register_class();

	DWORD main_style = WS_OVERLAPPED | WS_SYSMENU | WS_CAPTION;
	DWORD popup_style = WS_OVERLAPPED | WS_CAPTION;

	m_main = create_window(main_style, nullptr, L"BATTLESHIPS - STATISTICS", WS_EX_LAYERED, 'S');
	SetTimer(m_main, 1, 1000, NULL);
	SetLayeredWindowAttributes(m_main, 0, 76, LWA_ALPHA);
	m_popup1 = create_window(popup_style, m_main, L"BATTLESHIPS - MY", 0, 'B');
	m_popup2 = create_window(popup_style, m_main, L"BATTLESHIPS - PC", 0, 'B');
	SetMenu(m_popup1, NULL);
	SetMenu(m_popup2, NULL);
}

int app_battleships::run(int show_command)
{
	ShowWindow(m_main, show_command);
	ShowWindow(m_popup1, SW_SHOWNA);
	ShowWindow(m_popup2, SW_SHOWNA);

	MSG msg{};
	BOOL result = TRUE;
	while ((result = GetMessageW(&msg, nullptr, 0, 0)) != 0)
	{
		if (result == -1)
			return EXIT_FAILURE;
		TranslateMessage(&msg);
		DispatchMessageW(&msg);
	}
	return EXIT_SUCCESS;
}