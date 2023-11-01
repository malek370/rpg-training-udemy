using AutoMapper;
using rpg_training.DTOs.CharacterDTO;
using rpg_training.DTOs.SkillDTO;
using System.Reflection;

namespace rpg_training
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Character, GetCharacterDTO>();
            CreateMap<AddCharacterDTO, Character>();
            CreateMap<Weapon, GetWeaponDTO>();
            CreateMap<Skill,GetSkillDTO>();
        }

    }
}
