using FACodeTest.RobotWars.Builders;
using FACodeTest.RobotWars.CommandExecutors;
using FACodeTest.RobotWars.Commands;
using FACodeTest.RobotWars.Configurations;
using SimpleInjector;
using System;
using System.Collections.Generic;

namespace FACodeTest.RobotWars
{
    class Program
    {
        static void Main(string[] args)
        {
            var executors = container.GetAllInstances<ICommandExecutor>();


            bool exit = false;
            while (!exit)
            {
                var command = Console.ReadLine();
                if (command == "exit" || command == "quit")
                {
                    exit = true;
                    continue;
                }

                foreach (var executor in executors)
                {
                    if (!executor.Validate(command))
                    {
                        continue;
                    }

                    executor.Process(command);
                    break;
                }
            }
        }

        static readonly Container container;

        static Program()
        {
            container = new Container();
            container.Options.AllowOverridingRegistrations = true;

            container.Register<IContext, Context>(Lifestyle.Singleton);
            container.Register<IArenaBuilder, ArenaBuilder>(Lifestyle.Singleton);
            container.Register<IRobotBuilder, RobotBuilder>(Lifestyle.Singleton);
            container.Collection.Register<ICommandExecutor>(
                    typeof(CreateArenaCommandExecutor),
                    typeof(CreateRobotCommandExecutor),
                    typeof(MoveRobotCommandExecutor));

            container.Register<ICommand, MoveCommand>();
            container.Register<ICommand, RotateCommand>();
            container.Collection.Register<ICommand>(
                                typeof(MoveCommand),
                                typeof(RotateCommand));
            container.Verify();
        }

    }
}
