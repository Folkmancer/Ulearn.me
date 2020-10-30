namespace Mazes
{
	public static class SnakeMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
            while (!robot.Finished)
            {
                MoveRight(robot, width);
                MoveDown(robot);
                MoveLeft(robot, width);
                if (!robot.Finished) MoveDown(robot);
            } 
        }

        static void MoveLeft(Robot robot, int widthMaze)
        {
            for (int i = widthMaze - 3; i > 0; i--)
            {
                robot.MoveTo(Direction.Left);
            }
        }

        static void MoveRight(Robot robot, int widthMaze)
        {
            for (int i = 0; i < widthMaze - 3; i++)
            {
                robot.MoveTo(Direction.Right);
            }
        }
        
        static void MoveDown(Robot robot)
        {
            for (int i = 0; i < 2; i++)
            {
                robot.MoveTo(Direction.Down);
            }      
        }
    }
}