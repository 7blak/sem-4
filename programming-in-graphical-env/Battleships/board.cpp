#include "board.h"

Board10::Board10() : m_fields{}
{
	for (LONG row = 0; row < boardSize; ++row)
	{
		for (LONG col = 0; col < boardSize; ++col)
		{
			auto& f = m_fields[row * boardSize + col];
			f.position.top = row * (fieldSize + gridMargin) + wndMargin;
			f.position.left = col * (fieldSize + gridMargin) + wndMargin;
			f.position.bottom = f.position.top + fieldSize;
			f.position.right = f.position.left + fieldSize;
		}
	}
}

Board15::Board15() : m_fields{}
{
	for (LONG row = 0; row < boardSize; ++row)
	{
		for (LONG col = 0; col < boardSize; ++col)
		{
			auto& f = m_fields[row * boardSize + col];
			f.position.top = row * (fieldSize + gridMargin) + wndMargin;
			f.position.left = col * (fieldSize + gridMargin) + wndMargin;
			f.position.bottom = f.position.top + fieldSize;
			f.position.right = f.position.left + fieldSize;
		}
	}
}

Board20::Board20() : m_fields{}
{
	for (LONG row = 0; row < boardSize; ++row)
	{
		for (LONG col = 0; col < boardSize; ++col)
		{
			auto& f = m_fields[row * boardSize + col];
			f.position.top = row * (fieldSize + gridMargin) + wndMargin;
			f.position.left = col * (fieldSize + gridMargin) + wndMargin;
			f.position.bottom = f.position.top + fieldSize;
			f.position.right = f.position.left + fieldSize;
		}
	}
}