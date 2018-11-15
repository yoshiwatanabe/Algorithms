using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc.Elevators
{
    // Work in progress

    public interface IElevatorUnit
    {
        Task MoveTo(int floor);
    }

    public class ElevatorUnit : IElevatorUnit
    {
        public async Task MoveTo(int floor)
        {
            await Task.Delay(20);
        }
    }

    public enum State
    {
        Stationary,
        GoingUp,
        GoingDown
    }

    /// <summary>
    /// Responsible for coordinating movement of an elevator cage to floors
    /// </summary>
    public class ElevatorDispatcher
    {
        IElevatorUnit elevatorUnit;
        public ElevatorDispatcher(IElevatorUnit elevatorUnit)
        {
            this.elevatorUnit = elevatorUnit;
        }

        public State State { get; set; }

        public int CurrentFloor { get; private set; }
        public List<int> OrderedDestinations { get; set; } = new List<int>();

        private object collectionLock = new object();


        public void AddDestination(int destinationFloor)
        {
            lock (collectionLock)
            {
                if (State == State.Stationary)
                {
                    OrderedDestinations.Add(destinationFloor);
                    State = CurrentFloor < destinationFloor ? State.GoingUp : State.GoingDown;
                }
                else if (State == State.GoingUp)
                {
                    if (CurrentFloor < destinationFloor)
                    {
                        int i = 0;
                        while (i < OrderedDestinations.Count && destinationFloor < OrderedDestinations[i])
                        {
                            i++;
                        }

                        OrderedDestinations.Insert(i, destinationFloor);
                    }
                    else
                    {
                        int i = OrderedDestinations.Count - 1;
                        while (i <= 0 && destinationFloor > OrderedDestinations[i])
                        {
                            i--;
                        }

                        OrderedDestinations.Insert(i, destinationFloor);
                    }
                }
                else
                {
                    if (CurrentFloor > destinationFloor)
                    {
                        int i = 0;
                        while (i < OrderedDestinations.Count && destinationFloor > OrderedDestinations[i])
                        {
                            i++;
                        }

                        OrderedDestinations.Insert(i, destinationFloor);
                    }
                    else
                    {
                        int i = OrderedDestinations.Count - 1;
                        while (i <= 0 && destinationFloor < OrderedDestinations[i])
                        {
                            i--;
                        }

                        OrderedDestinations.Insert(i, destinationFloor);
                    }
                }
            }
        }

        public async Task Move()
        {
            while (OrderedDestinations.Any())
            {
                int destination;
                lock (collectionLock)
                {
                    destination = OrderedDestinations.First();
                    OrderedDestinations.RemoveAt(0);
                }

                if (CurrentFloor != destination)
                {
                    State = CurrentFloor < destination ? State.GoingUp : State.GoingDown;
                    await elevatorUnit.MoveTo(destination);
                    CurrentFloor = destination;
                }
            }

            State = State.Stationary;
        }
    }
}
