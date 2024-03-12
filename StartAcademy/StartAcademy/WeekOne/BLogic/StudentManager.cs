using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using StartAcademy.WeekOne.DataModels;

namespace StartAcademy.WeekOne.BLogic
{
    //Classe per la gestione dell'oggetto student
    internal class StudentManager
    {
        #region Metodi Interni o Pubblici

        /// <summary>
        /// Method to insert datas about an instance of student 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        internal bool InsertStudent(Student student)
        {
            Student studentNew = new();
            /*var context = new ValidationContext(studentNew, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(studentNew ,context,results,validateAllProperties: true);

            if (isValid) { return true; }
            else { Console.WriteLine("Dati studente non validi");
                foreach(var validationResult in results)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }
            }*/

            try
            {
                Console.Clear();
                Console.WriteLine(new string('*', 50));
                Console.WriteLine("*******  INSERIMENTO DATI STUDENTE  *******");
                Console.WriteLine(new string('*', 50));

                //Insert firstName
                do
                {
                    Console.SetCursorPosition(0, 4);
                    Console.Write("Nome: ");
                    Console.Write(new string(' ', studentNew.FirstName.Length));
                    Console.SetCursorPosition(6, 4);
                    studentNew.FirstName = Console.ReadLine();
                    if(studentNew.FirstName.Length < 3 || studentNew.FirstName.Length > 30) 
                        Console.WriteLine("Errore, Inserisci un nome compreso tra 3 e 30 caratteri");

                } while(studentNew.FirstName.Length < 3 || studentNew.FirstName.Length > 30);


                //Insert MiddleName

                Console.Write("Secondo nome, se presente: ");
                studentNew.MiddleName = Console.ReadLine();

                //Insert Cognome
                


            }
            catch(IOException ioe)
            {
                Console.WriteLine("Error on insert: " + ioe);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error on insert: " + e);
                Console.ReadLine();
            }

            return true;
        }

        #endregion
    }
}
