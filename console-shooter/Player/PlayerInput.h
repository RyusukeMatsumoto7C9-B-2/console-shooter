#pragma once

class PlayerInput
{
public:
    PlayerInput();
    ~PlayerInput();
    
    void Update();
    
    bool GetMoveLeft() const;
    bool GetMoveRight() const;
    bool GetShoot() const;
    bool GetExit() const;

private:
    bool _left;
    bool _right;
    bool _shoot;
    bool _exit;

    void ResetKeys();
};
