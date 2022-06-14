using System;
using SplashKitSDK;


public class RobotDodge
{
    private Player _player;
    private Window _gameWindow;
    private List<Robot> _Robots = new List<Robot>();
    private List<Robot> _removedRobots = new List<Robot>();
    
        public bool Quit
    {
        get { return _player.Quit; }
    }

public RobotDodge(Window gameWindow)
    {
        _gameWindow = gameWindow;
        _player= new Player(gameWindow);
    }
    public void HandleInput()
    {
        _player.HandleInput();
        _player.StayOnWindow();
    }

    public Robot RandomRobot()
    {   
        Robot _Boxy = new Boxy(_gameWindow, _player);
        Robot _Roundy = new Roundy(_gameWindow, _player);
        Robot _Special = new Special(_gameWindow, _player);
       

        double randomNumber = SplashKit.Rnd(1000);
        if (randomNumber < 300)
        {
            return _Boxy;
        }
        else if (randomNumber > 300 & randomNumber < 700)
        {
            return _Roundy;
        }
        else
        {
            return _Special;
        }
    }

public void Draw()
    {
        _gameWindow.Clear(Color.White);

        foreach (Robot robot in _Robots)
        {
            robot.Draw();
        }

        _player.Draw();
        _gameWindow.Refresh(60);
    }


public void Update()
    { 
        CheckCollisions();
        foreach (Robot robot in _Robots)
        {
            robot.Update();
        }

        double randomNumber = SplashKit.Rnd(1000);
        if (randomNumber < 30)
        {
            _Robots.Add(RandomRobot());
        }
    }

public void CheckCollisions()
    {
        foreach (Robot robot in _Robots)
        {
            if (_player.CollidedWith(robot) || robot.IsOffscreen(_gameWindow))
            {
                _removedRobots.Add(robot);
            }
        }
        foreach (Robot robot in _removedRobots)
        {
            _Robots.Remove(robot);
        }
    }
}