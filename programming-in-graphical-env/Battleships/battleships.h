#pragma once

#include <string>
#include <Windows.h>
#include "board.h"
#include "resource.h"

class app_battleships
{
private:
	bool register_class();

	static std::wstring const s_class_name;

	static LRESULT CALLBACK window_proc_static(HWND window, UINT message, WPARAM wparam, LPARAM lparam);

	LRESULT window_proc(HWND window, UINT message, WPARAM wparam, LPARAM lparam);

	HWND create_window(DWORD style, HWND parent = nullptr, LPCWSTR name = L"BATTLESHIPS", DWORD exStyle = 0, char wndType = 'S');

	void ChangeGridSize(HWND window, int gridsize);

	HINSTANCE m_instance;
	HWND m_main, m_popup1, m_popup2;
	Board10 m_board;
	Board15 m_board15;
	Board20 m_board20;
	HBRUSH m_field_brush;
	int currGridSize = 10;

public:
	app_battleships(HINSTANCE instance);

	int run(int show_command);
};