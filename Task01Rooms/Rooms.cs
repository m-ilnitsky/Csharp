using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01_Rooms
{
    class Rooms
    {
        static void Main(string[] args)
        {
            int entranceNumber = 0;
            do
            {
                Console.Write("Введите число подъездов: ");
                entranceNumber = Convert.ToInt32(Console.ReadLine());
                if (entranceNumber < 1)
                {
                    Console.WriteLine("ОШИБКА: Число подъездов должно быть не меньше 1!");
                }
            }
            while (entranceNumber < 1);

            int floorNumber = 0;
            do
            {
                Console.Write("Введите число этажей: ");
                floorNumber = Convert.ToInt32(Console.ReadLine());
                if (floorNumber < 1)
                {
                    Console.WriteLine("ОШИБКА: Число этажей должно быть не меньше 1!");
                }
            }
            while (floorNumber < 1);

            uint entranceRoomsNumber = (uint)floorNumber * 4;
            uint homeRoomsNumber = (uint)entranceNumber * entranceRoomsNumber;

            Console.WriteLine();
            Console.WriteLine("В доме {0} подъездов", entranceNumber);
            Console.WriteLine("В доме {0} этажей", floorNumber);
            Console.WriteLine("В доме {0} квартир", homeRoomsNumber);

            int room = 0;
            do
            {
                Console.Write("Введите номер квартиры: ");
                room = Convert.ToInt32(Console.ReadLine());
                if (room < 1)
                {
                    Console.WriteLine("ОШИБКА: Номер квартиры должен быть не меньше 1!");
                }
                else if (room > homeRoomsNumber)
                {
                    Console.WriteLine("ОШИБКА: Номер квартиры слишком большой (квартир меньше чем введённый номер)!");
                }
            }
            while (room < 1 || room > homeRoomsNumber);

            uint roomFromZero = (uint)room - 1;
            uint entranceFromZero = roomFromZero / entranceRoomsNumber;
            uint floorFromZero = (roomFromZero - entranceRoomsNumber * entranceFromZero) / 4;
            uint positionFromZero = (roomFromZero - entranceRoomsNumber * entranceFromZero) % 4;

            Console.WriteLine();
            Console.WriteLine("В доме {0} подъездов, {1} этажей, {2} квартир", entranceNumber, floorNumber, homeRoomsNumber);
            Console.WriteLine("В подъезде {0} квартир", entranceRoomsNumber);

            Console.WriteLine("Квартира №{0} находится в {1} подъезде на {2} этаже", room, entranceFromZero + 1, floorFromZero + 1);

            switch (positionFromZero)
            {
                case 0:
                    Console.WriteLine("Квартира №{0} ближняя слева", room);
                    break;
                case 1:
                    Console.WriteLine("Квартира №{0} дальняя слева", room);
                    break;
                case 2:
                    Console.WriteLine("Квартира №{0} дальняя справа", room);
                    break;
                case 3:
                    Console.WriteLine("Квартира №{0} ближняя справа", room);
                    break;
                default:
                    Console.WriteLine("ОШИБКА: Квартира №{0} находится НЕПОНЯТНО ГДЕ!", room);
                    break;
            }

            Console.ReadLine();
        }
    }
}
