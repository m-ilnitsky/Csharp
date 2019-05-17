using System;

namespace Task01_Rooms
{
    class Rooms
    {
        static void Main(string[] args)
        {
            const int roomsOnFloorCount = 4;

            int entrancesCount;
            do
            {
                Console.Write("Введите число подъездов: ");
                entrancesCount = Convert.ToInt32(Console.ReadLine());
                if (entrancesCount < 1)
                {
                    Console.WriteLine("ОШИБКА: Число подъездов должно быть не меньше 1!");
                }
            }
            while (entrancesCount < 1);

            int floorsCount;
            do
            {
                Console.Write("Введите число этажей: ");
                floorsCount = Convert.ToInt32(Console.ReadLine());
                if (floorsCount < 1)
                {
                    Console.WriteLine("ОШИБКА: Число этажей должно быть не меньше 1!");
                }
            }
            while (floorsCount < 1);

            int entranceRoomsCount = floorsCount * roomsOnFloorCount;
            int homeRoomsCount = entrancesCount * entranceRoomsCount;

            Console.WriteLine();
            Console.WriteLine("В доме {0} подъездов", entrancesCount);
            Console.WriteLine("В доме {0} этажей", floorsCount);
            Console.WriteLine("В доме {0} квартир", homeRoomsCount);

            int roomNumber;
            do
            {
                Console.Write("Введите номер квартиры: ");
                roomNumber = Convert.ToInt32(Console.ReadLine());
                if (roomNumber < 1)
                {
                    Console.WriteLine("ОШИБКА: Номер квартиры должен быть не меньше 1!");
                }
                else if (roomNumber > homeRoomsCount)
                {
                    Console.WriteLine("ОШИБКА: Номер квартиры слишком большой (квартир меньше чем введённый номер)!");
                }
            }
            while (roomNumber < 1 || roomNumber > homeRoomsCount);

            int roomNumberFromZero = roomNumber - 1;
            int entranceNumber = roomNumberFromZero / entranceRoomsCount + 1;
            int floorNumber = (roomNumberFromZero - entranceRoomsCount * (entranceNumber - 1)) / roomsOnFloorCount + 1;
            int position = (roomNumberFromZero - entranceRoomsCount * (entranceNumber - 1)) % roomsOnFloorCount;

            Console.WriteLine();
            Console.WriteLine("В доме {0} подъездов, {1} этажей, {2} квартир", entrancesCount, floorsCount, homeRoomsCount);
            Console.WriteLine("В подъезде {0} квартир", entranceRoomsCount);

            Console.WriteLine("Квартира №{0} находится в {1} подъезде на {2} этаже", roomNumber, entranceNumber, floorNumber);

            switch (position)
            {
                case 0:
                    Console.WriteLine("Квартира №{0} ближняя слева", roomNumber);
                    break;
                case 1:
                    Console.WriteLine("Квартира №{0} дальняя слева", roomNumber);
                    break;
                case 2:
                    Console.WriteLine("Квартира №{0} дальняя справа", roomNumber);
                    break;
                case 3:
                    Console.WriteLine("Квартира №{0} ближняя справа", roomNumber);
                    break;
                default:
                    Console.WriteLine("ОШИБКА: Квартира №{0} находится НЕПОНЯТНО ГДЕ!", roomNumber);
                    break;
            }

            Console.ReadLine();
        }
    }
}
