namespace Mazes
{
	public static class EmptyMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
            MoveLeft(robot, width);
            MoveDown(robot, height);
        }

        static void MoveLeft(Robot robot, int widthMaze)
        {
            while (robot.X != widthMaze - 2)
            {
                robot.MoveTo(Direction.Right);
            }
        }

        static void MoveDown(Robot robot, int heightMaze)
        {
            while (robot.Y != heightMaze - 2)
            {
                robot.MoveTo(Direction.Down);
            }
        }
    }
}