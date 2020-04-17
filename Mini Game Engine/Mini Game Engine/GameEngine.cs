using System;
using System.Collections.Generic;

public partial class GameEngine
{
    List<Border> border = new List<Border>();
    public int borderHeight, borderWidth;
    public Player player = new Player();
    public Coin coin = new Coin();
    bool gameDone;  

    public void initialize()
    {
        Console.Clear();
        gameDone = false;        
        Console.CursorVisible = false;

        borderHeight = 20;
        borderWidth = 30;

        Console.WindowHeight = borderHeight + 10;
        Console.WindowWidth = borderWidth + 10;

        player.x = (borderWidth / 2);
        player.y = (borderHeight / 2);

        coin.x = new Random().Next(2, borderWidth - 1);
        coin.y = new Random().Next(2, borderHeight - 1);

        renderBorder();
        renderPlayer();
        renderCoin();        

        while (true)
        {            
            if (!gameDone)
            {
                inputUpdate();
                Move();
                if (player.x == coin.x && player.y == coin.y)
                {
                    Victory();
                    Console.SetCursorPosition(0, borderHeight + 2);
                    Console.WriteLine("Press SPACE to RESTART");
                    Console.WriteLine("Press ESC to EXIT");               
                }
            }
            else
            {
                inputUpdate();
                if (space.down)
                {
                    space.down = false;
                    Reset();
                    gameDone = true;                    
                }
                else if (esc.down)
                {
                    Exit();
                }
            }
            
        }
    }   

    public void Victory()
    {
        Console.Clear();
        renderBorder();
        Console.SetCursorPosition((borderWidth / 2) - 3, borderHeight / 2);
        Console.WriteLine("Victory");
        gameDone = true;
    }

    public void Exit()
    {
        Environment.Exit(0);        
    }

    public void Reset()
    {       
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        initialize();
    }
}

public class Border 
{
    public int x;
    public int y;    
}

public class Player
{
    public int x;
    public int y;
    public string playerName = "P";
}

public class Coin
{
    public int x;
    public int y;
    public string coinName = "C";
}

