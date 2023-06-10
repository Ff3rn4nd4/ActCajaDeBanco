//Actividad Tema 1

using System;
using System.Collections.Generic;

bool volverAlMenu = true;
//Para poder utilizar esta variable en dos opciones diferentes del switch 
//tuvieron que convertirse en una variables globales
int numRetiro = 0;
List<int> cantidadesRetiro = new List<int>();

do{
    Console.Clear();
    Console.WriteLine("---------------------------------- Michu Bank ----------------------------------");
    Console.WriteLine("Ambas opcines solo estan disponibles para usuarios de este banco");
    Console.WriteLine("1. Cantidad de retiros ha realizar");
    Console.WriteLine("2. Cantidad de dinero recibido");
    Console.WriteLine("3. Salir del programa");
    Console.Write("\tIngresar opcion: ");
    string opcion = Console.ReadLine();

        switch(opcion)
        {
            case "1": 
            System.Console.Clear();
            Console.WriteLine("Solo se pueden realizar 10 movimientos");
            Console.Write("\tCuantos retiros deseas realizar? ");
            numRetiro = Convert.ToInt32(Console.ReadLine());
            #region ManejoDeRetiros

                if (numRetiro <= 10)
                {
                    for(int i = 1; i <= numRetiro; i++)
                    {
                        int cantidadRetiro;

                        string Message = $"\tIngrese la cantidad del retiro {i}#:";
                        Console.Write(Message);
                        cantidadRetiro = Convert.ToInt32(Console.ReadLine());
                    
                        if(cantidadRetiro >= 50000)
                        {
                            Console.WriteLine("Lo siento no puedes realizar movimientos mayores a $50,000");
                            string Message1 = $"\tIngrese una cantidad valida {i}#:";
                            Console.Write(Message1);
                            cantidadRetiro = Convert.ToInt32(Console.ReadLine());
                            cantidadesRetiro.Add(cantidadRetiro);
                        }else
                        cantidadesRetiro.Add(cantidadRetiro);  
                    }
                }else Console.WriteLine("Lo siento no puedes realizar mas movimientos de los indicados, vuelve a intentarlo!");
            #endregion

            #region VolverAlMenu
            Console.Write("\n¿Deseas volver al menú principal? (S/N): ");
            string respuesta = Console.ReadLine();

            if (respuesta.ToUpper() != "S")
            {
                volverAlMenu = false;
            }
            #endregion
            break;

            case "2":
            Console.Clear();
            Console.WriteLine("La cantidad de dinero se dividira en dos secciones: Billetes y Monedas\n");
            #region CalculoDinero

                int cantBilletes = 0;
                int cantMonedas = 0;

                for(int i=1; i <= cantidadesRetiro.Count ; i++)
                {
                    do{
                        if(i <= cantidadesRetiro.Count && cantidadesRetiro[i-1] >= 500)
                        {
                            cantidadesRetiro[i-1] -=500;
                            cantBilletes++;
                        }else if(cantidadesRetiro[i-1]<500 && cantidadesRetiro[i-1]>= 200)
                            {
                                cantidadesRetiro[i-1] -=200;
                                cantBilletes++;
                            }else if(cantidadesRetiro[i-1]<200 && cantidadesRetiro[i-1]>= 100)
                                {
                                    cantidadesRetiro[i-1] -= 100;
                                    cantBilletes++;
                                }else if(cantidadesRetiro[i-1]<100 && cantidadesRetiro[i-1]>= 50)
                                    {
                                        cantidadesRetiro[i-1] -= 50;
                                        cantBilletes++;
                                    }else if(cantidadesRetiro[i-1]<50 && cantidadesRetiro[i-1]>=20)
                                        {
                                            cantidadesRetiro[i-1] -= 20;
                                            cantBilletes++;
                                        }else if(cantidadesRetiro[i-1]<20 && cantidadesRetiro[i-1]>=10)
                                            {
                                                cantidadesRetiro[i-1] -= 10;
                                                cantMonedas++;
                                            }else if(cantidadesRetiro[i-1]<10 && cantidadesRetiro[i-1]>=5)
                                                {
                                                    cantidadesRetiro[i-1] -= 5;
                                                    cantMonedas++;
                                                }else if(cantidadesRetiro[i-1]>=1)
                                                    {
                                                        cantidadesRetiro[i-1] -= 1;
                                                        cantMonedas++;
                                                    }
                    }while(cantidadesRetiro[i-1]>=1);
                    
                    Console.WriteLine($"Retiro{i}#:");
                    Console.WriteLine($"Cantidad en billetes: {cantBilletes}");
                    Console.WriteLine($"Cantidad en monedas: {cantMonedas} \n");
                    //reiniciando las variables para el sig retiro
                    cantBilletes = 0;
                    cantMonedas = 0;
                }
            #endregion

            #region VolverAlMenu
            Console.Write("\n¿Deseas volver al menú principal? (S/N): ");
            respuesta = Console.ReadLine();

            if (respuesta.ToUpper() != "S")
            {
                volverAlMenu = false;
            }
            #endregion
            break;

            case "3":
            volverAlMenu = false;
            break;

            default:
            Console.Clear();
            Console.WriteLine("Ups! esa opcion no existe");
            #region VolverAlMenu
            Console.Write("\n¿Deseas volver al menú principal? (S/N): ");
            respuesta = Console.ReadLine();

            if (respuesta.ToUpper() != "S")
            {
                volverAlMenu = false;
            }
            #endregion
            break;
        }

}while (volverAlMenu);
    
