#define NOMINMAX
#include <windows.h>
#include "battleships.h"

int WINAPI wWinMain(HINSTANCE instance, HINSTANCE prevInstance, LPWSTR command_line, int show_command)
{
	app_battleships app{ instance };
	return app.run(show_command);
}