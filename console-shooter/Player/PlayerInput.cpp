#include <conio.h>
#include "PlayerInput.h"


PlayerInput::PlayerInput()
{
    _left = false;
    _right = false;
    _shoot = false;
    _exit = false;
}


PlayerInput::~PlayerInput()
{
    _left = false;
    _right = false;
    _shoot = false;
    _exit = false;
}


void PlayerInput::Update()
{
    ResetKeys();

    // キー入力の処理.
    if (_kbhit())
    {
        int ch = _getch();
        // 矢印キーの場合、先頭が0または224.
        if (ch == 0 || ch == 224)
        {
            int arrow = _getch();
            _left |= arrow == 75;
            _right |= arrow == 77;
        }
        else
        {
            _left |= ch == 'a';
            _right |= ch == 'd';
            _shoot |= ch == ' ';
            _exit |= ch == 'q';
        }
    }
}


bool PlayerInput::GetMoveLeft() const
{
    return _left;
}


bool PlayerInput::GetMoveRight() const
{
    return _right;
}


bool PlayerInput::GetShoot() const
{
    return _shoot;
}


bool PlayerInput::GetExit() const
{
    return _exit;
}


// --- private method ---


void PlayerInput::ResetKeys()
{
    _left = false;
    _right = false;
    _shoot = false;
    _exit = false;
}


