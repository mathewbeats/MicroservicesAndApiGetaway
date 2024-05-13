namespace Microservices.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Name Name { get; set; }
        [Required]
        public Email Email { get; set; }
        [Required]
        public string ContactInformation { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string MedicalHistory { get; set; }

        // Constructor por defecto
        public Patient() { }

        // Constructor sobrecargado completo
        public Patient(int id, Name name, Email email, string contactInformation, DateTime dateOfBirth, string medicalHistory)
        {
            Id = id;
            Name = name;
            Email = email;
            ContactInformation = contactInformation;
            DateOfBirth = dateOfBirth;
            MedicalHistory = medicalHistory;
        }

        // Constructor sin fecha de nacimiento
        public Patient(int id, Name name, Email email, string contactInformation, string medicalHistory)
        {
            Id = id;
            Name = name;
            Email = email;
            ContactInformation = contactInformation;
            MedicalHistory = medicalHistory;
        }


        //Los métodos WithDate, WithEmail, y WithName no son constructores, aunque sí utilizan constructores en su implementación.

        //Estos métodos son parte de un patrón de diseño conocido como el patrón de "modificación inmutable",

        //que permite cambiar datos de un objeto inmutable creando una nueva instancia de ese objeto con el cambio aplicado.

        //Dado que las instancias de la clase Reservation son inmutables (no puedes cambiar sus propiedades después de que han sido creadas),

        //estos métodos permiten "modificar" una Reservation de manera segura sin alterar la instancia original, devolviendo una nueva instancia con el cambio deseado.


        //Funcionamiento de los Métodos With

        //Cada método With toma un único parámetro y crea una nueva instancia de Reservation usando un constructor de la clase, 
        //pasando el valor actual de todas las propiedades excepto la que se desea modificar, para la cual se usa el nuevo valor proporcionado como parámetro.
        //Esto es clave en contextos donde la inmutabilidad es importante, como en programación funcional, donde los objetos no deben cambiar una vez creados 
        //para evitar efectos secundarios no deseados.



        public Patient WithName(Name newName)
        {
            return new Patient(Id, newName, Email, ContactInformation, DateOfBirth, MedicalHistory);

        }


        public Patient WithDate(DateTime newAt)
        {

            return new Patient(Id, Name, Email, ContactInformation, newAt, MedicalHistory);
        }






        // Sobrescribir el método ToString
        public override string ToString()
        {
            return $"{Id} - {Name}, Born on {DateOfBirth.ToShortDateString()}, Contact: {ContactInformation}, Medical History: {MedicalHistory}, Email: {Email}";
        }

        // Sobrescribir el método Equals
        public override bool Equals(object obj)
        {
            return obj is Patient patient &&
                   Id.Equals( patient.Id) &&
                   DateOfBirth == patient.DateOfBirth &&
                   EqualityComparer<Email>.Default.Equals(Email, patient.Email ) &&
                   EqualityComparer<Name>.Default.Equals(Name, patient.Name) &&
                   ContactInformation == patient.ContactInformation &&
                   MedicalHistory == patient.MedicalHistory;


        }

        //El Método Equals


        //El método Equals es un método heredado de la clase base Object que se sobrescribe para proporcionar una forma de comparar si dos instancias de Reservation son "iguales"
        //en términos de sus datos, en lugar de si son la misma instancia en memoria(lo cual sería la igualdad por referencia).

        //El código en tu ejemplo comprueba si el objeto obj proporcionado puede ser tratado como una instancia de Reservation(usando is) 
        //y luego compara todas las propiedades relevantes de Reservation para determinar si son iguales.Si todas las propiedades coinciden, devuelve true; de lo contrario, devuelve false.

        //Aquí se desglosa cómo funciona la comparación:

        //obj is Reservation reservation verifica si obj es de tipo Reservation y, si es así, lo asigna a la variable reservation para su uso en las comparaciones siguientes.
        //Id.Equals(reservation.Id) compara los identificadores Guid para ver si son iguales.Los Guid tienen su propio método Equals que asegura una comparación adecuada.
        //        At == reservation.At compara las fechas para ver si son exactamente las mismas.
        //EqualityComparer<Email>.Default.Equals(Email, reservation.Email) utiliza un comparador por defecto para Email, que es probablemente un tipo personalizado, 
        //    para determinar si son iguales.Esto es útil si Email es un tipo cuya igualdad no se determina simplemente por la igualdad de referencia.
        //EqualityComparer<Name>.Default.Equals(Name, reservation.Name) hace lo mismo para el tipo Name.
        //Quantity == reservation.Quantity compara directamente los valores de Quantity.
        //Sobrescribir Equals es útil para:

        //Comparar objetos en colecciones, como listas y diccionarios, donde la igualdad de contenido es importante.
        //Realizar pruebas unitarias, donde quieres verificar si dos objetos representan el mismo estado.
        //Implementar lógica en aplicaciones donde la igualdad de dos entidades no se basa en si son la misma instancia, sino si representan el mismo concepto o datos.




        // Sobrescribir el método GetHashCode
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }


}
