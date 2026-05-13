namespace APIsprint.DTOs.PersonDTOs
{
    public class PersonResponseDTO
    {
        public int person_id { get; set; }

        public string person_name { get; set; }

        public string person_surname { get; set; }

        public string cpf { get; set; }

        public int age { get; set; }

        public string occupation { get; set; }

        public decimal monthly_income { get; set; }
    }
}