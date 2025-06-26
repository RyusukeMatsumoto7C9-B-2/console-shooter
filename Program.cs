using System;
using System.Threading;
using console_shooter;

class Program
{
    static void Main(string[] args)
    {
        const int frameUpdateMs = 16;                 // フレームレート（約60fps).
        const int screenWidth = 30;         // 画面の横幅
        const int screenHeight = 20;        // 画面全体の行数
        const int infoLines = 5;            // スコアなど表示用の行数
        const int separatorLine = 1;        // 区切り線の行数
        const int gameAreaHeight = screenHeight - infoLines - separatorLine; // ゲーム領域の行数（14行）

        var game = new Game(screenWidth);
        Console.CursorVisible = false;

        while (true)
        {
            // フレームレートを維持するための待機
            Thread.Sleep(frameUpdateMs);
            game.UpdateScore();

            // キー入力の処理
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Q)
                {
                    return; // ゲーム終了
                }
                game.MovePlayer(keyInfo.Key);
            }

            // 画面をクリアして最上部にカーソルを移動
            Console.SetCursorPosition(0, 0);
            
            // 上部情報エリア
            Console.WriteLine($"Score: {game.Score}");
            for (int i = 1; i < infoLines; i++)
            {
                Console.WriteLine();
            }

            // 区切り線
            Console.WriteLine(new string('-', screenWidth));

            // ゲームエリア
            for (int i = 0; i < gameAreaHeight; i++)
            {
                if (i == gameAreaHeight - 1)
                {
                    // プレイヤーの行
                    Console.Write(new string(' ', game.PlayerPos));
                    Console.Write("@");
                    Console.WriteLine(new string(' ', screenWidth - game.PlayerPos - 1));
                }
                else
                {
                    // 空の行
                    Console.WriteLine(new string(' ', screenWidth));
                }
            }
        }
    }
}
