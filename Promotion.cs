using System;
using System.Collections.Generic;

namespace entity_course
{
    public class Promotion
    {

        public int Id { get; set; }
        public string Description { get; internal set; }
        public DateTime StartDate { get; internal set; }
        public DateTime EndDate { get; internal set; }
        public IList<PromotionProduct> Poducts { get; internal set; }
    }
}