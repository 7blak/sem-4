#pragma once
#define NOMINMAX
#include <array>
#include <windows.h>

struct field
{
	RECT position;
};

class Board10
{
public:
	static constexpr LONG boardSize = 10;	// 10x10 -> 10, 15x15 -> 15, 20x20 -> 20
	static constexpr LONG fieldSize = 30;	// 30
	static constexpr LONG gridMargin = 3;	// 3
	static constexpr LONG wndMargin = 5;	// 5
	static constexpr LONG fieldCount = boardSize * boardSize;	// boardSize * boardSize
	static constexpr LONG length = boardSize * (fieldSize + gridMargin) + wndMargin;	// Both width and height, boardSize * (fieldSize + gridMargin) + wndMargin;

	using field_array = std::array<field, fieldCount>;

	Board10();

	field_array const& fields() const { return m_fields; }

private:
	field_array m_fields;

};

class Board15
{
public:
	static constexpr LONG boardSize = 15;	// 10x10 -> 10, 15x15 -> 15, 20x20 -> 20
	static constexpr LONG fieldSize = 30;	// 30
	static constexpr LONG gridMargin = 3;	// 3
	static constexpr LONG wndMargin = 5;	// 5
	static constexpr LONG fieldCount = boardSize * boardSize;	// boardSize * boardSize
	static constexpr LONG length = boardSize * (fieldSize + gridMargin) + wndMargin;	// Both width and height, boardSize * (fieldSize + gridMargin) + wndMargin;

	using field_array = std::array<field, fieldCount>;

	Board15();

	field_array const& fields() const { return m_fields; }

private:
	field_array m_fields;

};

class Board20
{
public:
	static constexpr LONG boardSize = 20;	// 10x10 -> 10, 15x15 -> 15, 20x20 -> 20
	static constexpr LONG fieldSize = 30;	// 30
	static constexpr LONG gridMargin = 3;	// 3
	static constexpr LONG wndMargin = 5;	// 5
	static constexpr LONG fieldCount = boardSize * boardSize;	// boardSize * boardSize
	static constexpr LONG length = boardSize * (fieldSize + gridMargin) + wndMargin;	// Both width and height, boardSize * (fieldSize + gridMargin) + wndMargin;

	using field_array = std::array<field, fieldCount>;

	Board20();

	field_array const& fields() const { return m_fields; }

private:
	field_array m_fields;

};