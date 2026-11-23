using System.Reflection.Metadata.Ecma335;

public class SeatReservation
{
    private readonly bool[] _reservedSeats;
    public SeatReservation(int SeatCount)
    {
        if (SeatCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(SeatCount));
        }
        _reservedSeats = new bool[SeatCount];

    }
    public bool ReserveSeat(int seatNumber)
    {
        if (seatNumber < 1 || seatNumber > _reservedSeats.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(seatNumber));
        }
        int index = seatNumber - 1;

        if (_reservedSeats[index])
        {
            return false;
        }
        _reservedSeats[index] = true;

        return true;
    }
    public int GetAvailableSeatCount()
    {
        int count = 0;

        foreach (bool seat in _reservedSeats)
        {
            if (!seat)
            {
                count++;
            }
        }

        return count;
    }
}