using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.carrito
{
    class Carrito
    {

        private int cantidad = 0;
        private double precio = 1000;
        private double descuento = 0;
        private bool isRun = true;

        public void interfaz()
        {
            Console.WriteLine("Camisas 'PROFE APROBE?' - Ventas minoristas y mayoristas");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("MENÚ PRINCIPAL:");
            Console.WriteLine("1- Añadir camisa al carro de compras");
            Console.WriteLine("2- Eliminar camisa del carro de compras");
            Console.WriteLine("3- Salir");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("   - Cantidad de camisas en el carro de compras: "+cantidad);
            Console.WriteLine("   - Precio unitario: "+precio);
            Console.WriteLine("   - Precio total sin descuento: "+(precio*cantidad));
            Console.WriteLine("   - Tipo de descuento aplicado: "+descuento+"%");
            Console.WriteLine("   - Precio final con descuento: $"+((precio*cantidad)-((precio * cantidad)*(descuento / 100))));
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write("Ingrese una opción del menú: ");
            int choose = selection();
            function(choose);
            Console.Clear();
        }

        public void run()
        {
            while (isRun) {
                interfaz();
            }
        }

        public int selection()
        {
            bool isValid = false;
            int selection = 0;
            while(isValid == false)
            {
                try
                {
                    String data = Console.ReadLine();
                    selection = Int16.Parse(data);
                    if (selection >= 1 && selection <= 3)
                    {
                        isValid = true;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception e)
                {
                    Console.Write("Lo que usted ingreso no es correcto. Ingreselo otra vez: ");
                }
            }

            return selection;
        }

        public void function(int selection)
        {
            switch (selection)
            {
                case 1:
                    cantidad++;
                    discount();
                    break;
                case 2:
                    if(cantidad > 0)
                    {
                        cantidad--;
                    }
                    else
                    {
                        Console.WriteLine("La cantidad es 0. No se puede restar");
                    }
                    discount();
                    break;
                case 3:
                    Console.Clear();
                    Console.Write("¿Está seguro que desea salir? S/N: ");
                    exit();
                    break;
            }
        }

        public void discount()
        {
            if(cantidad < 3)
            {
                descuento = 0;
            } else if(cantidad >= 3 && cantidad <= 5)
            {
                descuento = 10;
            }
            else if (cantidad > 5)
            {
                descuento = 20;
            }
        }

        public void exit()
        {
            bool isValid = true;
            while (isValid)
            {
                String exit = Console.ReadLine();
                switch (exit)
                {
                    case "S":
                        isValid = false;
                        isRun = false;
                        break;
                    case "N":
                        isValid = false;
                        break;
                    default:
                        Console.WriteLine("|ADVERTENCIA| El caracter debe de ser mayuscula.");
                        Console.Write("Lo que usted ingreso no es correcto. Ingreselo otra vez: ");
                        break;
                }
            }
        }

    }
}
