#define NOMINMAX
#include <Windows.h>
#include <windowsx.h>
#include "resource.h"
#include <string>
#include <vector>
#include <random>
#define TIMER_ID 1

HWND mainWnd, boardMyWnd, boardPCWnd;

const std::wstring mainClassName = L"Battleships Statistics Class";
const std::wstring boardClassName = L"Board Class";
const std::wstring mainWndName = L"BATTLESHIPS - STATISTICS";
const std::wstring boardMyWndName = L"BATTLESHIPS - MY";
const std::wstring boardPCWndName = L"BATTLESHIPS - PC";

static int secondsElapsed = 0;

enum FieldColor
{
	WHITE = 0,
	BLUE = 1,
	YELLOW = 2,
	RED = 3
};

struct Ship
{
	int size = -1;
	int coords[4] = { -1,-1,-1,-1 };
	bool sunk[4] = { false,false,false,false };
};

struct Field
{
	int index;
	RECT rect;
	bool clicked;
	FieldColor color;
	bool bShip;
	Ship* ship;
};

std::vector<Ship*> allShips;
std::vector<Field> myFields;
std::vector<Field> PCFields;

WCHAR path[256];

int boardSize = 10;
const int fieldSize = 30;
const int gridMargin = 3;
const int wndMargin = 5;
int boardLength = 0;
bool bIsGameOver = false;
bool bHumanWon = true;

void LoadCurrentDir()
{
	GetCurrentDirectoryW(256, path);
	wcscat_s(path, L"\\battleships.ini");
}

void SaveToIni()
{
	WCHAR diff[256];
	wsprintfW(diff, L"%d\0", boardSize);
	BOOL check = WritePrivateProfileStringW(L"BATTLESHIPS", L"DIFFICULTY", diff, path);
	if (check == false)
		fprintf(stderr, "ERROR WRITING TO INI FILE");
}

void ReadFromIni()
{
	WCHAR read[256];
	BOOL check = GetPrivateProfileStringW(L"BATTLESHIPS", L"DIFFICULTY", NULL, read, 256, path);
	if (check == false)
	{
		fprintf(stderr, "ERROR READING FROM INI FILE");
		boardSize = 10;
	}
	int readval = 0;
	if (swscanf_s(read, L"%d", &readval) == EOF)
		boardSize = 10;
	boardSize = readval;
}

const DWORD mainStyle = WS_OVERLAPPED | WS_SYSMENU | WS_CAPTION | WS_MINIMIZEBOX;
const DWORD boardStyle = WS_OVERLAPPED | WS_CAPTION;

const int screenWidth = GetSystemMetrics(SM_CXSCREEN);
const int screenHeight = GetSystemMetrics(SM_CYSCREEN);
const int windowWidth = 600;
const int windowHeight = 250;
const int windowX = (screenWidth - windowWidth) / 2;
const int windowY = 3 * screenHeight / 4 - windowHeight;

int CalculateBoardLength()
{
	return boardSize * (fieldSize + gridMargin) + wndMargin;
}

void ChangeBoardSize(int desiredBoardSize)
{
	if (desiredBoardSize != 10 && desiredBoardSize != 15 && desiredBoardSize != 20 || desiredBoardSize == boardSize)
		return;

	boardSize = desiredBoardSize;
	boardLength = CalculateBoardLength();

	RECT size{ 0,0, boardLength, boardLength };
	AdjustWindowRectEx(&size, boardStyle, false, 0);

	MoveWindow(boardMyWnd,
		screenWidth / 3 - boardLength,
		(screenHeight / 2) - boardLength / 2,
		size.right - size.left,
		size.bottom - size.top,
		TRUE);

	MoveWindow(boardPCWnd,
		2 * screenWidth / 3,
		(screenHeight / 2) - boardLength / 2,
		size.right - size.left,
		size.bottom - size.top,
		TRUE);

	InvalidateRect(boardMyWnd, NULL, FALSE);
	InvalidateRect(boardPCWnd, NULL, FALSE);
}

int GetNIndexToLeft(int index, int n = 1)
{
	if (n == 0)
		return index;
	if (index < 0)
		return -1;
	int row = index / boardSize;
	int col = index % boardSize;

	int newCol = col - n;
	if (newCol >= 0 && newCol < boardSize)
		return row * boardSize + newCol;
	else
		return -1;
}

int GetNIndexToRight(int index, int n = 1)
{
	if (n == 0)
		return index;
	if (index < 0)
		return -1;
	int row = index / boardSize;
	int col = index % boardSize;

	int newCol = col + n;
	if (newCol >= 0 && newCol < boardSize)
		return row * boardSize + newCol;
	else
		return -1;
}

int GetNIndexAbove(int index, int n = 1)
{
	if (n == 0)
		return index;
	if (index < 0)
		return -1;
	int row = index / boardSize;
	int col = index % boardSize;

	int newRow = row - n;
	if (newRow >= 0 && newRow < boardSize)
		return newRow * boardSize + col;
	else
		return -1;
}

int GetNIndexBelow(int index, int n = 1)
{
	if (n == 0)
		return index;
	if (index < 0)
		return -1;
	int row = index / boardSize;
	int col = index % boardSize;

	int newRow = row + n;
	if (newRow >= 0 && newRow < boardSize)
		return newRow * boardSize + col;
	else
		return -1;
}

bool CheckMyEdges(int index)
{
	int temp = GetNIndexToLeft(GetNIndexAbove(index));
	if (temp >= 0 && temp <= boardSize * boardSize - 1 && myFields[temp].bShip)
		return true;
	temp = GetNIndexAbove(index);
	if (temp >= 0 && temp <= boardSize * boardSize - 1 && myFields[temp].bShip)
		return true;
	temp = GetNIndexToRight(GetNIndexAbove(index));
	if (temp >= 0 && temp <= boardSize * boardSize - 1 && myFields[temp].bShip)
		return true;

	temp = GetNIndexToLeft(index);
	if (temp >= 0 && temp <= boardSize * boardSize - 1 && myFields[temp].bShip)
		return true;
	if (temp >= 0 && temp <= boardSize * boardSize - 1 && myFields[index].bShip)
		return true;
	temp = GetNIndexToRight(index);
	if (temp >= 0 && temp <= boardSize * boardSize - 1 && myFields[temp].bShip)
		return true;

	temp = GetNIndexToLeft(GetNIndexBelow(index));
	if (temp >= 0 && temp <= boardSize * boardSize - 1 && myFields[temp].bShip)
		return true;
	temp = GetNIndexBelow(index);
	if (temp >= 0 && temp <= boardSize * boardSize - 1 && myFields[temp].bShip)
		return true;
	temp = GetNIndexToRight(GetNIndexBelow(index));
	if (temp >= 0 && temp <= boardSize * boardSize - 1 && myFields[temp].bShip)
		return true;
	return false;
}

bool CheckPCEdges(int index)
{
	int temp = GetNIndexToLeft(GetNIndexAbove(index));
	if (temp >= 0 && temp <= boardSize * boardSize - 1 && PCFields[temp].bShip)
		return true;
	temp = GetNIndexAbove(index);
	if (temp >= 0 && temp <= boardSize * boardSize - 1 && PCFields[temp].bShip)
		return true;
	temp = GetNIndexToRight(GetNIndexAbove(index));
	if (temp >= 0 && temp <= boardSize * boardSize - 1 && PCFields[temp].bShip)
		return true;

	temp = GetNIndexToLeft(index);
	if (temp >= 0 && temp <= boardSize * boardSize - 1 && PCFields[temp].bShip)
		return true;
	if (temp >= 0 && temp <= boardSize * boardSize - 1 && PCFields[index].bShip)
		return true;
	temp = GetNIndexToRight(index);
	if (temp >= 0 && temp <= boardSize * boardSize - 1 && PCFields[temp].bShip)
		return true;

	temp = GetNIndexToLeft(GetNIndexBelow(index));
	if (temp >= 0 && temp <= boardSize * boardSize - 1 && PCFields[temp].bShip)
		return true;
	temp = GetNIndexBelow(index);
	if (temp >= 0 && temp <= boardSize * boardSize - 1 && PCFields[temp].bShip)
		return true;
	temp = GetNIndexToRight(GetNIndexBelow(index));
	if (temp >= 0 && temp <= boardSize * boardSize - 1 && PCFields[temp].bShip)
		return true;
	return false;
}

bool CheckIfAllMySunk()
{
	for (int i = 0; i < boardSize * boardSize; i++)
	{
		if (myFields[i].bShip && myFields[i].clicked == false)
			return false;
	}
	return true;
}

bool CheckIfAllPCSunk()
{
	for (int i = 0; i < boardSize * boardSize; i++)
	{
		if (PCFields[i].bShip && PCFields[i].clicked == false)
			return false;
	}
	return true;
}

void GenerateBoard()
{
	// NOTES: FIELDS ARE STORED IN VECTORS, SO ROW IDS AS FOLLOWS: 
	// FIRST  [0,...,boardSize-1]
	// SECOND [boardSize,....,(2*boardSize)-1]
	// ...................................
	// LAST   [(boardSize-1)*(boardSize),...,(boardSize*boardSize)-1)]

	std::random_device rd;
	std::mt19937 gen(rd());
	std::uniform_int_distribution<size_t> dist(0, boardSize * boardSize - 1);

	int shipsToSpawn[10] = { 4,3,3,2,2,2,1,1,1,1 };

	for (int i = 0; i < 10; i++) //BUILDING MYBOARD - CAN BE PUT INTO ONE FUNCTION
	{
		Ship* ship = new Ship();
		ship->size = shipsToSpawn[i];
		int direction = rand() % 2;

		bool bIsPlaced = false;
		while (!bIsPlaced)
		{
			bool bForFlag = false;
			int index = (int)dist(gen);
			if (direction == 0) //BUILDING SHIP UP
			{
				if (GetNIndexAbove(index, ship->size) != -1)
				{
					for (int i = 0; i < ship->size; i++) //CHECKING FOR ANY SHIPS THAT MIGHT BE IN THE WAY
					{
						if (CheckMyEdges(GetNIndexAbove(index, i)))
						{
							bForFlag = true;
							break;
						}
					}
					if (bForFlag)
						continue;
					for (int i = 0; i < ship->size; i++) //PLACING THE SHIP
					{
						ship->coords[i] = GetNIndexAbove(index, i);
						myFields[GetNIndexAbove(index, i)].bShip = true;
						myFields[GetNIndexAbove(index, i)].ship = ship;
					}
					bIsPlaced = true;
					break;
				}
			}
			else //BUILDING SHIP DOWN
			{
				if (GetNIndexBelow(index, ship->size) != -1)
				{
					for (int i = 0; i < ship->size; i++) //CHECKING FOR ANY SHIPS THAT MIGHT BE IN THE WAY
					{
						if (CheckMyEdges(GetNIndexBelow(index, i)))
						{
							bForFlag = true;
							break;
						}
					}
					if (bForFlag)
						continue;
					for (int i = 0; i < ship->size; i++) //PLACING THE SHIP
					{
						ship->coords[i] = GetNIndexBelow(index, i);
						myFields[GetNIndexBelow(index, i)].bShip = true;
						myFields[GetNIndexBelow(index, i)].ship = ship;
					}
					bIsPlaced = true;
					break;
				}
			}
		}
		allShips.push_back(ship);
	}

	for (int i = 0; i < 10; i++) //BUILDING PCBOARD - CAN BE PUT INTO ONE FUNCTION
	{
		Ship* ship = new Ship();
		ship->size = shipsToSpawn[i];
		int direction = rand() % 2;

		bool bIsPlaced = false;
		while (!bIsPlaced)
		{
			bool bForFlag = false;
			int index = (int)dist(gen);
			if (direction == 0) //BUILDING SHIP UP
			{
				if (GetNIndexAbove(index, ship->size) != -1)
				{
					for (int i = 0; i < ship->size; i++) //CHECKING FOR ANY SHIPS THAT MIGHT BE IN THE WAY
					{
						if (CheckPCEdges(GetNIndexAbove(index, i)))
						{
							bForFlag = true;
							break;
						}
					}
					if (bForFlag)
						continue;
					for (int i = 0; i < ship->size; i++) //PLACING THE SHIP
					{
						ship->coords[i] = GetNIndexAbove(index, i);
						PCFields[GetNIndexAbove(index, i)].bShip = true;
						PCFields[GetNIndexAbove(index, i)].ship = ship;
					}
					bIsPlaced = true;
					break;
				}
			}
			else //BUILDING SHIP DOWN
			{
				if (GetNIndexBelow(index, ship->size) != -1)
				{
					for (int i = 0; i < ship->size; i++) //CHECKING FOR ANY SHIPS THAT MIGHT BE IN THE WAY
					{
						if (CheckPCEdges(GetNIndexBelow(index, i)))
						{
							bForFlag = true;
							break;
						}
					}
					if (bForFlag)
						continue;
					for (int i = 0; i < ship->size; i++) //PLACING THE SHIP
					{
						ship->coords[i] = GetNIndexBelow(index, i);
						PCFields[GetNIndexBelow(index, i)].bShip = true;
						PCFields[GetNIndexBelow(index, i)].ship = ship;
					}
					bIsPlaced = true;
					break;
				}
			}
		}
		allShips.push_back(ship);
	}

}

void InitializeBoards()
{
	InvalidateRect(boardMyWnd, NULL, TRUE);
	InvalidateRect(boardPCWnd, NULL, TRUE);
	bIsGameOver = false;
	myFields.resize(boardSize * boardSize);
	for (int row = 0; row < boardSize; ++row)
	{
		for (int col = 0; col < boardSize; ++col)
		{
			myFields[row * boardSize + col].rect = {
				col * (fieldSize + gridMargin) + wndMargin,
				row * (fieldSize + gridMargin) + wndMargin,
				col * (fieldSize + gridMargin) + wndMargin + fieldSize,
				row * (fieldSize + gridMargin) + wndMargin + fieldSize
			};
			myFields[row * boardSize + col].clicked = false;
			myFields[row * boardSize + col].color = FieldColor::WHITE;
			myFields[row * boardSize + col].bShip = false;
			myFields[row * boardSize + col].index = row * boardSize + col;
			myFields[row * boardSize + col].ship = nullptr;
		}
	}
	PCFields.resize(boardSize * boardSize);
	for (int row = 0; row < boardSize; ++row)
	{
		for (int col = 0; col < boardSize; ++col)
		{
			PCFields[row * boardSize + col].rect = {
				col * (fieldSize + gridMargin) + wndMargin,
				row * (fieldSize + gridMargin) + wndMargin,
				col * (fieldSize + gridMargin) + wndMargin + fieldSize,
				row * (fieldSize + gridMargin) + wndMargin + fieldSize
			};
			PCFields[row * boardSize + col].clicked = false;
			PCFields[row * boardSize + col].color = FieldColor::WHITE;
			PCFields[row * boardSize + col].bShip = false;
			PCFields[row * boardSize + col].index = row * boardSize + col;
			PCFields[row * boardSize + col].ship = nullptr;
		}
	}
	GenerateBoard();
}

void DrawGameOverOverlay(PAINTSTRUCT* ps, HDC hdc, RECT& rectSize, HWND window)
{
	HDC tempHdc = CreateCompatibleDC(hdc);
	HBRUSH brush;
	HBRUSH oldBrush;
	std::wstring text;

	if (!((window == boardMyWnd && bHumanWon) || window == boardPCWnd && !bHumanWon)) // FLIP THIS, I BELIEVE IT SHOULD BE THE OTHER WAY AROUND BUT WHATEVER
	{
		brush = CreateSolidBrush(RGB(0, 255, 0));
		oldBrush = (HBRUSH)SelectObject(tempHdc, brush);
		text = L"CONGRATS, YOU WON";
	}
	else
	{
		brush = CreateSolidBrush(RGB(255, 0, 0));
		oldBrush = (HBRUSH)SelectObject(tempHdc, brush);
		text = L"YOU LOST";
	}

	RECT rect = { 0, 0, ps->rcPaint.right - ps->rcPaint.left, ps->rcPaint.bottom - ps->rcPaint.top };

	HBITMAP hBitmap = CreateCompatibleBitmap(hdc, rect.right, rect.bottom);
	HBITMAP hOldBitmap = (HBITMAP)SelectObject(tempHdc, hBitmap);

	FillRect(tempHdc, &rect, brush);

	BLENDFUNCTION blend = { AC_SRC_OVER, 0, 128, 0 };
	AlphaBlend(hdc, ps->rcPaint.left, ps->rcPaint.top, rect.right, rect.bottom,
		tempHdc, ps->rcPaint.left, ps->rcPaint.top, rect.right, rect.bottom,
		blend);

	SelectObject(tempHdc, oldBrush);
	SelectObject(tempHdc, hOldBitmap);
	DeleteObject(brush);

	HFONT font = CreateFont(-MulDiv(24, GetDeviceCaps(hdc, LOGPIXELSY), 100),	// Height
		0,																		// Width
		0,																		// Escapement
		0,																		// Orientation
		FW_BOLD,																// Weight
		false,																	// Italic
		FALSE,																	// Underline
		0,																		// StrikeOut
		EASTEUROPE_CHARSET,														// CharSet
		OUT_DEFAULT_PRECIS,														// OutPrecision
		CLIP_DEFAULT_PRECIS,													// ClipPrecision
		DEFAULT_QUALITY,														// Quality
		DEFAULT_PITCH | FF_SWISS,												// PitchAndFamily
		L"Verdana");
	HFONT oldFont = (HFONT)SelectObject(hdc, font);
	SetTextColor(hdc, RGB(255, 255, 255));
	SetBkMode(hdc, TRANSPARENT);
	DrawTextW(hdc, text.c_str(), -1, &rectSize, DT_SINGLELINE | DT_VCENTER | DT_CENTER);
	SelectObject(hdc, oldFont);
	DeleteObject(font);
	DeleteDC(tempHdc);
}

void DrawShip(HDC hdc, Ship* ship, int xPos, int yPos)
{
	int tileSize = 20;
	int margin = 5;

	for (int i = 0; i < ship->size; ++i)
	{
		HBRUSH brush = CreateSolidBrush(ship->sunk[i] ? RGB(255,0,0) : RGB(0,0,255));
		HBRUSH oldBrush = (HBRUSH)SelectObject(hdc, brush);

		RECT rect = { xPos, yPos + i * (tileSize + margin), xPos + tileSize, yPos + (i + 1) * (tileSize + margin) };
		RoundRect(hdc, rect.left, rect.top, rect.right, rect.bottom, 10, 10);
		//FillRect(hdc, &rect, (ship->sunk[i]) ? CreateSolidBrush(RGB(255,0,0)) : CreateSolidBrush(RGB(0,0,255)));
		FrameRect(hdc, &rect, CreateSolidBrush(RGB(255, 255, 255)));
		SelectObject(hdc, oldBrush);
		DeleteObject(brush);
	}
}

void TileLogic(Field& field, HWND window)
{
	if (field.color == FieldColor::YELLOW)
		return;
	if (window == boardMyWnd)
	{
		int index = field.index;
		if (field.bShip)
		{
			field.color = FieldColor::RED;
			for (int i = 0; i < field.ship->size; i++)
			{
				if (field.ship->coords[i] == index)
				{
					field.ship->sunk[i] = true;
					InvalidateRect(mainWnd, NULL, TRUE);
					break;
				}
			}
			if (field.ship->size > 1)
			{
				for (int i = 0; i < field.ship->size; i++)
				{
					if (myFields[field.ship->coords[i]].clicked == false)
						return;
				}
			}
			for (int i = 0; i < field.ship->size; i++)
			{
				index = field.ship->coords[i];
				int temp = GetNIndexToLeft(GetNIndexAbove(index));
				if (temp >= 0 && temp <= boardSize * boardSize - 1 && !myFields[temp].bShip && myFields[temp].color != FieldColor::BLUE)
					myFields[temp].color = FieldColor::YELLOW;
				temp = GetNIndexAbove(index);
				if (temp >= 0 && temp <= boardSize * boardSize - 1 && !myFields[temp].bShip && myFields[temp].color != FieldColor::BLUE)
					myFields[temp].color = FieldColor::YELLOW;
				temp = GetNIndexToRight(GetNIndexAbove(index));
				if (temp >= 0 && temp <= boardSize * boardSize - 1 && !myFields[temp].bShip && myFields[temp].color != FieldColor::BLUE)
					myFields[temp].color = FieldColor::YELLOW;

				temp = GetNIndexToLeft(index);
				if (temp >= 0 && temp <= boardSize * boardSize - 1 && !myFields[temp].bShip && myFields[temp].color != FieldColor::BLUE)
					myFields[temp].color = FieldColor::YELLOW;
				temp = GetNIndexToRight(index);
				if (temp >= 0 && temp <= boardSize * boardSize - 1 && !myFields[temp].bShip && myFields[temp].color != FieldColor::BLUE)
					myFields[temp].color = FieldColor::YELLOW;

				temp = GetNIndexToLeft(GetNIndexBelow(index));
				if (temp >= 0 && temp <= boardSize * boardSize - 1 && !myFields[temp].bShip && myFields[temp].color != FieldColor::BLUE)
					myFields[temp].color = FieldColor::YELLOW;
				temp = GetNIndexBelow(index);
				if (temp >= 0 && temp <= boardSize * boardSize - 1 && !myFields[temp].bShip && myFields[temp].color != FieldColor::BLUE)
					myFields[temp].color = FieldColor::YELLOW;
				temp = GetNIndexToRight(GetNIndexBelow(index));
				if (temp >= 0 && temp <= boardSize * boardSize - 1 && !myFields[temp].bShip && myFields[temp].color != FieldColor::BLUE)
					myFields[temp].color = FieldColor::YELLOW;
			}
		}
		else
			field.color = FieldColor::BLUE;
	}
	if (window == boardPCWnd)
	{
		int index = field.index;
		if (field.bShip)
		{
			field.color = FieldColor::RED;
			for (int i = 0; i < field.ship->size; i++)
			{
				if (field.ship->coords[i] == index)
				{
					field.ship->sunk[i] = true;
					InvalidateRect(mainWnd, NULL, TRUE);
					break;
				}
			}
			if (field.ship->size > 1)
			{
				for (int i = 0; i < field.ship->size; i++)
				{
					if (PCFields[field.ship->coords[i]].clicked == false)
						return;
				}
			}
			for (int i = 0; i < field.ship->size; i++)
			{
				index = field.ship->coords[i];
				int temp = GetNIndexToLeft(GetNIndexAbove(index));
				if (temp >= 0 && temp <= boardSize * boardSize - 1 && !PCFields[temp].bShip && PCFields[temp].color != FieldColor::BLUE)
					PCFields[temp].color = FieldColor::YELLOW;
				temp = GetNIndexAbove(index);
				if (temp >= 0 && temp <= boardSize * boardSize - 1 && !PCFields[temp].bShip && PCFields[temp].color != FieldColor::BLUE)
					PCFields[temp].color = FieldColor::YELLOW;
				temp = GetNIndexToRight(GetNIndexAbove(index));
				if (temp >= 0 && temp <= boardSize * boardSize - 1 && !PCFields[temp].bShip && PCFields[temp].color != FieldColor::BLUE)
					PCFields[temp].color = FieldColor::YELLOW;

				temp = GetNIndexToLeft(index);
				if (temp >= 0 && temp <= boardSize * boardSize - 1 && !PCFields[temp].bShip && PCFields[temp].color != FieldColor::BLUE)
					PCFields[temp].color = FieldColor::YELLOW;
				temp = GetNIndexToRight(index);
				if (temp >= 0 && temp <= boardSize * boardSize - 1 && !PCFields[temp].bShip && PCFields[temp].color != FieldColor::BLUE)
					PCFields[temp].color = FieldColor::YELLOW;

				temp = GetNIndexToLeft(GetNIndexBelow(index));
				if (temp >= 0 && temp <= boardSize * boardSize - 1 && !PCFields[temp].bShip && PCFields[temp].color != FieldColor::BLUE)
					PCFields[temp].color = FieldColor::YELLOW;
				temp = GetNIndexBelow(index);
				if (temp >= 0 && temp <= boardSize * boardSize - 1 && !PCFields[temp].bShip && PCFields[temp].color != FieldColor::BLUE)
					PCFields[temp].color = FieldColor::YELLOW;
				temp = GetNIndexToRight(GetNIndexBelow(index));
				if (temp >= 0 && temp <= boardSize * boardSize - 1 && !PCFields[temp].bShip && PCFields[temp].color != FieldColor::BLUE)
					PCFields[temp].color = FieldColor::YELLOW;
			}
		}
		else
			field.color = FieldColor::BLUE;
	}
}

void SimulatePCMove()
{
	if (bIsGameOver)
		return;
	if (CheckIfAllMySunk())
	{
		bHumanWon = false;
		bIsGameOver = true;
		InvalidateRect(boardMyWnd, NULL, TRUE);
		InvalidateRect(boardPCWnd, NULL, TRUE);
		return;
	}
	size_t numFields = myFields.size();

	std::random_device rd;
	std::mt19937 gen(rd());
	std::uniform_int_distribution<size_t> dist(0, numFields - 1);

	bool bKeepLoopAlive = false;
	do
	{
		bKeepLoopAlive = false;
		size_t randomIndex = dist(gen);

		Field& field = myFields[randomIndex];
		if (field.clicked == true)
		{
			bKeepLoopAlive = true;
			continue;
		}
		field.clicked = true;
		if (field.bShip)
			bKeepLoopAlive = true;
		TileLogic(field, boardMyWnd);
		InvalidateRect(boardMyWnd, NULL, TRUE);
		UpdateWindow(boardMyWnd);
	} while (bKeepLoopAlive);
}

LRESULT CALLBACK window_proc_main(HWND window, UINT message, WPARAM wparam, LPARAM lparam)
{
	switch (message)
	{
	case WM_PAINT:
	{
		RECT rectPos;
		GetWindowRect(window, &rectPos);

		RECT rectSize;
		GetClientRect(window, &rectSize);

		PAINTSTRUCT ps;
		HDC hdc = BeginPaint(window, &ps);
		
		int offset = 20;
		int count = 0;

		for (const auto& ship : allShips)
		{
			if (count == 10)
				offset += 40; //DONE TO OFFSET THE OTHER PLAYER/PC
			DrawShip(hdc, ship, offset, 0);
			offset += 20;
			count++;
		}
		EndPaint(window, &ps);
		break;
	}
	case WM_CREATE:
	{
		InitializeBoards();
		break;
	}
	case WM_CLOSE:
	{
		DestroyWindow(window);
		return 0;
	}
	case WM_DESTROY:
	{
		SaveToIni();
		PostQuitMessage(0);
		return 0;
	}
	case WM_TIMER:
	{
		secondsElapsed++;
		WCHAR title[256];
		wsprintf(title, L"%s: %d", mainWndName.c_str(), secondsElapsed);
		SetWindowText(window, title);
		break;
	}
	case WM_COMMAND:
	{
		switch (LOWORD(wparam))
		{
		case ID_MENU_EASY:
			secondsElapsed = 0;
			ChangeBoardSize(10);
			InitializeBoards();
			break;
		case ID_MENU_MEDIUM:
			secondsElapsed = 0;
			ChangeBoardSize(15);
			InitializeBoards();
			break;
		case ID_MENU_HARD:
			secondsElapsed = 0;
			ChangeBoardSize(20);
			InitializeBoards();
			break;
		}
		break;
	}
	}
	return DefWindowProcW(window, message, wparam, lparam);
}

LRESULT CALLBACK window_proc_board(HWND window, UINT message, WPARAM wparam, LPARAM lparam)
{
	switch (message)
	{
	case WM_PAINT:
	{
		//InvalidateRect(window, NULL, TRUE);

		RECT rectPos;
		GetWindowRect(window, &rectPos);

		RECT rectSize;
		GetClientRect(window, &rectSize);

		PAINTSTRUCT ps;
		HDC hdc = BeginPaint(window, &ps);

		HFONT font = CreateFont(-MulDiv(24, GetDeviceCaps(hdc, LOGPIXELSY), 100),	// Height
			0,																		// Width
			0,																		// Escapement
			0,																		// Orientation
			FW_BOLD,																// Weight
			false,																	// Italic
			FALSE,																	// Underline
			0,																		// StrikeOut
			EASTEUROPE_CHARSET,														// CharSet
			OUT_DEFAULT_PRECIS,														// OutPrecision
			CLIP_DEFAULT_PRECIS,													// ClipPrecision
			DEFAULT_QUALITY,														// Quality
			DEFAULT_PITCH | FF_SWISS,												// PitchAndFamily
			L"Verdana");
		HFONT oldFont = (HFONT)SelectObject(hdc, font);
		SetTextColor(hdc, RGB(0, 0, 0));
		SetBkMode(hdc, TRANSPARENT);

		if (window == boardMyWnd)
		{
			for (const auto& field : myFields)
			{
				HBRUSH brush; // CREATING A MAGENTA BRUSH FOR DEBUG IF SMTH GOES WRONG
				switch (field.color)
				{
				case FieldColor::WHITE:
					brush = CreateSolidBrush(RGB(255, 255, 255));
					break;
				case FieldColor::BLUE:
					brush = CreateSolidBrush(RGB(0, 0, 255));
					break;
				case FieldColor::YELLOW:
					brush = CreateSolidBrush(RGB(255, 255, 0));
					break;
				case FieldColor::RED:
					brush = CreateSolidBrush(RGB(255, 0, 0));
					break;
				default:
					brush = CreateSolidBrush(RGB(255, 0, 255)); // HERE
					break;
				}
				HBRUSH oldBrush = (HBRUSH)SelectObject(hdc, brush);
				RoundRect(hdc, field.rect.left, field.rect.top, field.rect.right, field.rect.bottom, 10, 10);
				WCHAR shipText[2];
				int size = field.ship == nullptr ? 0 : field.ship->size;
				wsprintf(shipText, L"%d", size);

				if (field.clicked && field.color == FieldColor::BLUE)
					TextOutW(hdc, field.rect.left + fieldSize / 2 - 4, field.rect.top, L".", 1);
				else if (field.clicked && field.color == FieldColor::RED)
					TextOutW(hdc, field.rect.left + fieldSize / 2 - 9, field.rect.top, L"X", 1);
				else if (field.bShip)
					TextOutW(hdc, field.rect.left + fieldSize / 2 - 8, field.rect.top, shipText, 1);

				SelectObject(hdc, oldBrush);
				DeleteObject(brush);
			}
		}
		if (window == boardPCWnd)
		{
			for (const auto& field : PCFields)
			{
				HBRUSH brush; // CREATING A MAGENTA BRUSH FOR DEBUG IF SMTH GOES WRONG
				switch (field.color)
				{
				case FieldColor::WHITE:
					brush = CreateSolidBrush(RGB(255, 255, 255));
					break;
				case FieldColor::BLUE:
					brush = CreateSolidBrush(RGB(0, 0, 255));
					break;
				case FieldColor::YELLOW:
					brush = CreateSolidBrush(RGB(255, 255, 0));
					break;
				case FieldColor::RED:
					brush = CreateSolidBrush(RGB(255, 0, 0));
					break;
				default:
					brush = CreateSolidBrush(RGB(255, 0, 255)); // HERE
					break;
				}
				HBRUSH oldBrush = (HBRUSH)SelectObject(hdc, brush);
				RoundRect(hdc, field.rect.left, field.rect.top, field.rect.right, field.rect.bottom, 10, 10);
				//WCHAR shipText[2];																    	/// UNCOMMENT TO ENABLE WALLHACKS
				//int size = field.ship == nullptr ? 0 : field.ship->size;								/// UNCOMMENT TO ENABLE WALLHACKS
				//wsprintf(shipText, L"%d", size);														/// UNCOMMENT TO ENABLE WALLHACKS

				if (field.clicked && field.color == FieldColor::BLUE)
					TextOutW(hdc, field.rect.left + fieldSize / 2 - 4, field.rect.top, L".", 1);
				else if (field.clicked && field.color == FieldColor::RED)
					TextOutW(hdc, field.rect.left + fieldSize / 2 - 9, field.rect.top, L"X", 1);
				//else if (field.bShip)																	/// UNCOMMENT TO ENABLE WALLHACKS
					//TextOutW(hdc, field.rect.left + fieldSize / 2 - 8, field.rect.top, shipText, 1);	/// UNCOMMENT TO ENABLE WALLHACKS

				SelectObject(hdc, oldBrush);
				DeleteObject(brush);
			}
		}

		if (bIsGameOver)
		{
			DrawGameOverOverlay(&ps, hdc, rectSize, window);
		}

		SelectObject(hdc, oldFont);
		DeleteObject(font);
		EndPaint(window, &ps);
		break;
	}
	case WM_LBUTTONDOWN:
	{
		if (bIsGameOver)
			break;
		bool bKeepLoopAlive = false;
		bool bWasValidGuess = false;
		do
		{
			if (CheckIfAllPCSunk())
			{
				bHumanWon = true;
				bIsGameOver = true;
				InvalidateRect(window, NULL, TRUE);
				InvalidateRect((window == boardMyWnd) ? boardPCWnd : boardMyWnd, NULL, TRUE);
				break;
			}
			bKeepLoopAlive = false;
			int xPos = GET_X_LPARAM(lparam);
			int yPos = GET_Y_LPARAM(lparam);
			bool bIsPCWnd = (window == boardPCWnd) ? true : false;

			if (bIsPCWnd)
			{
				for (auto& field : PCFields)
				{
					if (xPos >= field.rect.left && xPos <= field.rect.right && yPos >= field.rect.top && yPos <= field.rect.bottom)
					{
						if (field.clicked)
						{
							return 0;
						}
						bWasValidGuess = true;
						field.clicked = true;
						if (field.bShip)
							bKeepLoopAlive = true;
						TileLogic(field, boardPCWnd); //IMPLEMENT COLOR LOGIC
						InvalidateRect(window, NULL, TRUE);
						UpdateWindow(window);
						break;
					}
				}
			}
		} while (bKeepLoopAlive);
		if (bWasValidGuess)
			SimulatePCMove();
		break;
	}
	}
	return DefWindowProcW(window, message, wparam, lparam);
}

int WINAPI wWinMain(HINSTANCE instance, HINSTANCE prevInstance, LPWSTR command_line, int show_command)
{
	LoadCurrentDir();
	ReadFromIni();

	boardLength = CalculateBoardLength();

	WNDCLASSEXW wcMain, wcBoard;

	wcMain = {
		.cbSize = sizeof(WNDCLASSEXW),
		.lpfnWndProc = window_proc_main,
		.hInstance = instance,
		.hIcon = LoadIconW(instance, MAKEINTRESOURCE(ID_APPICON)),
		.hCursor = LoadCursorW(nullptr, L"IDC_ARROW"),
		.hbrBackground = CreateSolidBrush(RGB(164,174,196)),
		.lpszMenuName = MAKEINTRESOURCE(IDR_MENU),
		.lpszClassName = mainClassName.c_str(),
		.hIconSm = LoadIconW(instance, MAKEINTRESOURCE(ID_APPICON))
	};
	if (!RegisterClassExW(&wcMain))
		return 0;

	wcBoard = {
		.cbSize = sizeof(WNDCLASSEXW),
		.lpfnWndProc = window_proc_board,
		.hInstance = instance,
		.hCursor = LoadCursorW(nullptr, L"IDC_ARROW"),
		.hbrBackground = CreateSolidBrush(RGB(164,174,196)),
		.lpszMenuName = NULL,
		.lpszClassName = boardClassName.c_str(),
	};
	if (!RegisterClassExW(&wcBoard))
		return 0;

	mainWnd = CreateWindowExW(
		WS_EX_LAYERED,
		mainClassName.c_str(),
		mainWndName.c_str(),
		mainStyle,
		windowX,
		windowY,
		windowWidth,
		windowHeight,
		NULL,
		NULL,
		instance,
		NULL);

	SetLayeredWindowAttributes(mainWnd, 0, 180, LWA_ALPHA);

	RECT size{ 0,0, boardLength, boardLength };
	AdjustWindowRectEx(&size, boardStyle, false, 0);

	boardMyWnd = CreateWindowExW(
		0,
		boardClassName.c_str(),
		boardMyWndName.c_str(),
		boardStyle,
		screenWidth / 4 - boardLength + 200,
		(screenHeight / 2) - boardLength / 2,
		size.right - size.left,
		size.bottom - size.top,
		mainWnd,
		NULL,
		instance,
		NULL);

	boardPCWnd = CreateWindowExW(
		0,
		boardClassName.c_str(),
		boardPCWndName.c_str(),
		boardStyle,
		3 * screenWidth / 4 - 200,
		(screenHeight / 2) - boardLength / 2,
		size.right - size.left,
		size.bottom - size.top,
		mainWnd,
		NULL,
		instance,
		NULL);

	ShowWindow(mainWnd, SW_SHOW);
	ShowWindow(boardMyWnd, SW_SHOWNA);
	ShowWindow(boardPCWnd, SW_SHOWNA);

	MSG msg{};
	BOOL result = TRUE;
	SetTimer(mainWnd, TIMER_ID, 1000, NULL);
	while ((result = GetMessageW(&msg, nullptr, 0, 0)) != 0)
	{
		if (result == -1)
			return EXIT_FAILURE;
		TranslateMessage(&msg);
		DispatchMessageW(&msg);
	}

	return EXIT_SUCCESS;
}