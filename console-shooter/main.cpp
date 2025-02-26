#include <iostream>
#include <conio.h>
#include <windows.h>
#include <cstdlib>

#include "Player/PlayerInput.h"

using namespace std;

int main()
{
    const int frameUpdateMs = 16;                 // フレームレート（30fps).
    const int screenWidth = 30;         // 画面の横幅
    const int screenHeight = 20;        // 画面全体の行数
    const int infoLines = 5;            // スコアなど表示用の行数
    const int separatorLine = 1;        // 区切り線の行数
    const int gameAreaHeight = screenHeight - infoLines - separatorLine; // ゲーム領域の行数（14行）
    int playerPos = screenWidth / 2;      // 自キャラの初期位置（中央）
    int score = 0;                      // スコア（例として更新）


    PlayerInput* playerInput = new PlayerInput();

    while (true)
    {
        // .5秒待機
        Sleep(frameUpdateMs);
        score++;  // スコアを更新
        
        // キー入力の処理
        playerInput->Update();
        if (playerInput->GetMoveLeft() && playerPos > 0)
        {
            playerPos--;
        }
        else if (playerInput->GetMoveRight() && playerPos < screenWidth - 1)
        {
            playerPos++;
        }
        else if (playerInput->GetShoot())
        {
            // 何かしらの処理
        }
        else if (playerInput->GetExit())
        {
            delete playerInput;
            return 0;
        }

        // 画面をクリアして最上部にカーソルを移動
        system("cls");
        
        // 上部情報エリア（infoLines 行）
        for (int i = 0; i < infoLines; i++)
        {
            if (i == 0)
            {
                cout << "Score: " << score;
            }
            cout << "\n";
        }

        // 区切り線エリア（screenWidth文字の'-'）
        for (int i = 0; i < screenWidth; i++)
        {
            cout << "-";
        }
        cout << "\n";

        // ゲームエリア（gameAreaHeight 行）
        // 最終行に自キャラ '@' を描画、それ以外は空行
        for (int i = 0; i < gameAreaHeight; i++)
        {
            if (i == gameAreaHeight - 1)
            {
                for (int j = 0; j < screenWidth; j++)
                {
                    if (j == playerPos)
                        cout << "@";
                    else
                        cout << " ";
                }
            }
            else
            {
                for (int j = 0; j < screenWidth; j++)
                {
                    cout << " ";
                }
            }
            cout << "\n";
        }
        cout.flush();
    }


    
    return 0;
}