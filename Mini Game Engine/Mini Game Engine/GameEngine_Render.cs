using System;

public partial class GameEngine
{
    public void renderBorder()
    {
        for (int y = 1; y <= borderHeight; y++)
        {
            for (int x = 1; x <= borderWidth; x++)
            {
                if (y == 1 || y == borderHeight)
                {
                    border.Add(new Border() { x = x, y = y });
                }
                else if (x == 1 || x == borderWidth)
                {
                    border.Add(new Border() { x = x, y = y });
                }
            }
        }

        foreach (var item in border)
        {
            Console.SetCursorPosition(item.x, item.y);
            Console.Write('#');
        }
    }

    public void renderPlayer()
    {
        Console.SetCursorPosition(player.x, player.y);
        Console.Write(player.playerName);
    }

    public void renderCoin()
    {
        Console.SetCursorPosition(coin.x, coin.y);
        Console.Write(coin.coinName);
    }

    public void Clear(int x, int y)
    {
        Console.SetCursorPosition(x,y);
        Console.Write(" ");
    }
}