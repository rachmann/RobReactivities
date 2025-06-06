// public class for MappingProfiles.cs
using AutoMapper; 
using Domain;


namespace Application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Activities
        CreateMap<Activity, Activity>();
      
    }
}

