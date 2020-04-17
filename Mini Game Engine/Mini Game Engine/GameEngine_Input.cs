using System;
using System.Runtime.InteropServices;

public partial class GameEngine
{
    //defining keycodes for needed keys
    public KeyState w = new KeyState() {keyCode = 0x57};
    public KeyState a = new KeyState() {keyCode = 0x41};
    public KeyState s = new KeyState() {keyCode = 0x53};
    public KeyState d = new KeyState() {keyCode = 0x44};
    public KeyState space = new KeyState() {keyCode = 0x20};
    public KeyState esc = new KeyState() { keyCode = 0x1B };

    //function that checks if a key is pressed - no delays
    [DllImport("user32.dll")]
    static extern ushort GetAsyncKeyState(int vKey);

    public void inputUpdate()
    {
        updateKeyState(w);
        updateKeyState(a);
        updateKeyState(s);
        updateKeyState(d);
        updateKeyState(space);
        updateKeyState(esc);       

        void updateKeyState(KeyState k)
        {
            bool isPressed = GetAsyncKeyState(k.keyCode) > 0;            
            if (isPressed)
            {
                if (!k.down && !k.hold)
                {
                    k.down = true;
                }
                else if (k.down)
                {
                    k.down = false;
                    k.hold = true;
                }
            }
            else
            {
                if (k.hold)
                {
                    k.hold = false;
                    k.up = true;
                }
                else
                {
                    k.up = false;
                }
            }        
        }        
    }

    public void Move()
    {
        if (a.down)
        {
            if (player.x > 2)
            {
                Clear(player.x, player.y);
                player.x = player.x - 1;
                renderPlayer();
            }
        }
        else if (d.down)
        {
            if (player.x < borderWidth - 1)
            {
                Clear(player.x, player.y);
                player.x = player.x + 1;
                renderPlayer();
            }
        }
        else if (s.down)
        {
            if (player.y < borderHeight - 1)
            {
                Clear(player.x, player.y);
                player.y = player.y + 1;
                renderPlayer();
            }
        }
        else if (w.down)
        {
            if (player.y > 2)
            {
                Clear(player.x, player.y);
                player.y = player.y - 1;
                renderPlayer();
            }
        }
    }
}

//Unity-like system that marks in which state is a button
public class KeyState
{
    public int keyCode;
    public bool down;
    public bool hold;
    public bool up;
}