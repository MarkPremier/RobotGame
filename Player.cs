using System;
using SplashKitSDK;

public class Player
{
    private Window _gameWindow;
    private Bitmap _PlayerBitmap;

    public double X {get; private set; }
    public double Y {get; private set; }

    public Boolean Quit {get; private set; }

public int Width
{
    get
    {
        return _PlayerBitmap.Width;
    }
}

public int Height
{
    get
    {
        return _PlayerBitmap.Height;
    }
}

public Player(Window gameWindow)
{

    _gameWindow = gameWindow;
    Bitmap playerbitmap = new Bitmap("PlayerBitmap", "Player.png");
    _PlayerBitmap = playerbitmap;
   
    
    
    X = (gameWindow.Width - Width) / 2;
    Y = (gameWindow.Height - Height) / 2;      
}

public void Draw()
{
    _PlayerBitmap.Draw(X, Y);
}

public void HandleInput()
{
    int speed = 3;
    Quit = false;
    SplashKit.ProcessEvents();

    if (SplashKit.KeyDown(KeyCode.UpKey))
    {
        Y += -speed;
        _PlayerBitmap.Draw(X, Y);
        StayOnWindow();
    }
    if (SplashKit.KeyDown(KeyCode.LeftKey))
    {
        X += -speed;
        _PlayerBitmap.Draw(X, Y);
        StayOnWindow();
    }
    if (SplashKit.KeyDown(KeyCode.RightKey))
    {
        X += speed;
        _PlayerBitmap.Draw(X, Y);
        StayOnWindow();
    }
    if (SplashKit.KeyDown(KeyCode.DownKey))
    {
        Y += speed;
        _PlayerBitmap.Draw(X, Y);
        StayOnWindow();
    }
    if (SplashKit.KeyDown(KeyCode.EscapeKey))
    {
        Quit = true;
        _gameWindow.Close();
    }
    
}

public void StayOnWindow()
{
    const int GAP = 10;

    if (X<GAP)
    {
        X=GAP;
    }
    if (Y<GAP)
    {
        Y=GAP;
    }
    if (X>_gameWindow.Width-Width-GAP)
    {
        X=_gameWindow.Width-Width-GAP;
    }
    if (Y>_gameWindow.Height-Height-GAP)
    {
        Y=_gameWindow.Height-Height-GAP;
    }
}

public bool CollidedWith(Robot other)
{
   return _PlayerBitmap.CircleCollision(X, Y, other.CollissionCircle);
}

}

