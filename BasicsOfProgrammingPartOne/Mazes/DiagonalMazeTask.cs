namespace Mazes
{
	public static class DiagonalMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
            if (width > height) MoveForBigWidth(robot, width, height);
            else MoveForBigHeight(robot, width, height);
        }
        
        static void MoveForBigWidth(Robot robot, int width, int height)
        {
            int stepRight = (width - 2) / (height - 2);
            int stepDown = (width - 2) % (height - 2);
            while (!robot.Finished)
            {
                MoveRight(robot, stepRight);
                if (!robot.Finished) MoveDown(robot, stepDown);
            }
        }

        static void MoveForBigHeight(Robot robot, int width, int height)
        {
            int stepRight = (height - 2) % (width - 2);
            int stepDown = (height - 2) / (width - 2);
            while (!robot.Finished)
            {
                MoveDown(robot, stepDown);
                if (!robot.Finished) MoveRight(robot, stepRight);
            }
        }

        static void MoveRight(Robot robot, int countStep)
        {
            for (int i = 0; i < countStep; i++)
            {
                robot.MoveTo(Direction.Right);
            }
        }
        
        static void MoveDown(Robot robot, int countStep)
        {
            for (int i = 0; i < countStep; i++)
            {
                robot.MoveTo(Direction.Down);
            }
        }
    }
}