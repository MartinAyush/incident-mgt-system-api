﻿using IncidentMgtSystem.API.Enums;

namespace IncidentMgtSystem.API.DTOs
{
    public class IncidentSaveAPIRequest
    {
        public string Description { get; set; }
        public string Symptoms { get; set; }
        public int TenantId { get; set; }
        public int CityId { get; set; }
        public Priority Priority { get; set; }
        public Urgency Urgency { get; set; }

    }

    public class IncidentSaveAPIResponse : ResponseBase
    {
    }
}
