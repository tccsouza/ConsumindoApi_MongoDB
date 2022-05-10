namespace ConsumindoApi_MongoDB.Model
{
    /// <summary>
    /// Modelo do Schema para consumir as raças dos gatos. 
    /// </summary>
    public class Cat
    {
        public string id { get; set; }
        public string name { get; set; }
        public string temperament { get; set; }

        public string lifspan { get; set; }

        public string alt_names { get; set; }

        public string wikipedia_url { get; set; }

        public string origin { get; set; }

        public string weight_imperial { get; set; }

        public string experimental { get; set; }

        public int hairless { get; set; }

        public int natural { get; set; }

        public int rare { get; set; }

        public int rex { get; set; }

        public int suppress_tail { get; set; }

        public int short_legs { get; set; }

        public int hypoallergic { get; set; }

        public int adaptability { get; set; }

        public int affection_level { get; set; }

        public string country_code { get; set; }

        public int child_friendly { get; set; }

        public int dog_friendly { get; set; }

        public int energy_level { get; set; }

        public int grooming { get; set; }

        public int healt_issues { get; set; }

        public int intelligence { get; set; }

        public int shedding_level { get; set; }

        public int social_needs { get; set; }

        public int stranger_friendly { get; set; }

        public int vocalisation { get; set; }
    }
}
