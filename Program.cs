using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Window gameWindow = new Window("RobotGame", 800, 600);
        RobotDodge robotDodge = new RobotDodge(gameWindow);
        
        do
        {
            SplashKit.ProcessEvents();
            robotDodge.HandleInput();
            robotDodge.Update();
            robotDodge.Draw();

        }while (!gameWindow.CloseRequested);

        gameWindow.Close();
    }
}




