namespace BtkAkademi.Models
{
    public static class Repository
    {
        private static List<Candidate> applications = new();
        public static IEnumerable<Candidate> Applications => applications;    //ıenumerable yani her seferinde bir örnek dönebilir bir ifadeyle yani bir interface yapısıyla bir dönüş yapıcaz. ve bunları da applications listesinde  tutacağız.


        public static void Add(Candidate candidate)
        {
            applications.Add(candidate);
        }
    }
}