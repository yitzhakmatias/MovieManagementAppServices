﻿namespace MovieManagementAppServices.Core.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }

}
