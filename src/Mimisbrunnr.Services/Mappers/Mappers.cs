using Mimisbrunnr.Domain.Common;
using Mimisbrunnr.Domain.Praesidium;
using Mimisbrunnr.Shared.Common.Dtos;
using Mimisbrunnr.Shared.Praesidium.Dtos;

namespace Mimisbrunnr.Services.Mappers;

public static class Mappers
{
    #region Common

    #region Image
    public static ImageDto.Simple ImageToSimpleDto(Image image)
    {
        return new ImageDto.Simple
        {
            Url = image.Url,
            Description = image.Description,
        };
    }
    public static ImageDto.Detailed ImageToDetailedDto(Image image)
    {
        return new ImageDto.Detailed
        {
            Id = image.Id,
            Url = image.Url,
            Description = image.Description,
        };
    }
    #endregion

    #region SocialType
    public static SocialTypeDto.Simple SocialTypeToSimpleDto(SocialType socialType)
    {
        return new SocialTypeDto.Simple
        {
            Icon = ImageToSimpleDto(socialType.Icon),
        };
    }
    public static SocialTypeDto.Detailed SocialTypeToDetailedDto(SocialType socialType)
    {
        return new SocialTypeDto.Detailed
        {
            Id = socialType.Id,
            Name = socialType.Name,
            Icon = ImageToSimpleDto(socialType.Icon),
        };
    }
    #endregion

    #region Social
    public static SocialDto.Simple SocialToSimpleDto(Social social)
    {
        return new SocialDto.Simple
        {
            Type = SocialTypeToSimpleDto(social.Type),
            Url = social.Url
        };
    }
    public static SocialDto.Detailed SocialToDetailedDto(Social social)
    {
        return new SocialDto.Detailed
        {
            Id = social.Id,
            Type = SocialTypeToSimpleDto(social.Type),
            Url = social.Url
        };
    }
    #endregion
    
    #endregion
    
    #region Praesidium
    
    #region MemberDetails
    public static MemberDetailsDto.Simple MemberDetailtsToSimpleDto(MemberDetails  memberdetails)
    {
        return new MemberDetailsDto.Simple
        {
            Id = memberdetails.Id,
            FirstName = memberdetails.FirstName,
            LastName = memberdetails.LastName,
            Socials = memberdetails.Socials.Select(SocialToSimpleDto).ToArray()
        };
    }
    public static MemberDetailsDto.Detailed MemberDetailtsToDetailedDto(MemberDetails  memberdetails)
    {
        return new MemberDetailsDto.Detailed
        {
            Id = memberdetails.Id,
            FirstName = memberdetails.FirstName,
            LastName = memberdetails.LastName,
            Socials = memberdetails.Socials.Select(SocialToSimpleDto).ToArray(),
            Quote = memberdetails.Quote,
            Trivia = memberdetails.Trivia,
        };
    }
    #endregion

    #region PraesidiumRole
    public static PraesidiumRoleDto.Simple RoleToSimpleDto(PraesidiumRole role)
    {
        return new PraesidiumRoleDto.Simple
        {
            Id = role.Id,
            Name = role.Name,
            Order = role.Order
        };
    }
    public static PraesidiumRoleDto.Detailed RoleToDetailedDto(PraesidiumRole role)
    {
        return new PraesidiumRoleDto.Detailed
        {
            Id = role.Id,
            Name = role.Name,
            Order = role.Order,
            Email = role.Email.Address
        };
    }
    #endregion

    #region PraesidiumTerm
    public static PraesidiumTermDto.Simple TermToSimpleDto(PraesidiumTerm term)
    {
        return new PraesidiumTermDto.Simple
        {
            Id = term.Id,
            Member = MemberDetailtsToSimpleDto(term.MemberDetails),
            Role = RoleToSimpleDto(term.Role),
            Image = ImageToSimpleDto(term.Image),
            Year = term.Year,
        };
    }

    public static PraesidiumTermDto.Detailed TermToDetailedDto(PraesidiumTerm term)
    {
        return new PraesidiumTermDto.Detailed
        {
            Id = term.Id,
            Member = MemberDetailtsToDetailedDto(term.MemberDetails),
            Role = RoleToDetailedDto(term.Role),
            Image = ImageToSimpleDto(term.Image),
            Year = term.Year,
        };
    }
    #endregion
    
    #region EreLid
    public static ErelidDto.Simple ErelidToSimpleDto(Erelid erelid)
    {
        return new ErelidDto.Simple
        {
            Id = erelid.Id,
            Member = MemberDetailtsToSimpleDto(erelid.MemberDetails),
            Image = ImageToSimpleDto(erelid.Image),
        };
    }

    public static ErelidDto.Detailed ErelidToDetailedDto(Erelid erelid)
    {
        return new ErelidDto.Detailed
        {
            Id = erelid.Id,
            Member = MemberDetailtsToDetailedDto(erelid.MemberDetails),
            Image = ImageToSimpleDto(erelid.Image),
        };
    }
    #endregion

    #region SuperSchacht
    public static SuperSchachtDto.Simple SuperSchachtToSimpleDto(SuperSchacht superschacht)
    {
        return new SuperSchachtDto.Simple
        {
            Id = superschacht.Id,
            Member = MemberDetailtsToSimpleDto(superschacht.MemberDetails),
            Image = ImageToSimpleDto(superschacht.Image),
            Year = superschacht.Year,
        };
    }
    public static SuperSchachtDto.Detailed SuperSchachtToDetailedDto(SuperSchacht superschacht)
    {
        return new SuperSchachtDto.Detailed()
        {
            Id = superschacht.Id,
            Member = MemberDetailtsToDetailedDto(superschacht.MemberDetails),
            Image = ImageToSimpleDto(superschacht.Image),
            Year = superschacht.Year,
        };
    }
    #endregion

    #region LustrumLid
    public static LustrumLidDto.Simple LustrumLidToSimpleDto(LustrumLid lustrumLid)
    {
        return new LustrumLidDto.Simple
        {
            Id = lustrumLid.Id,
            Member = MemberDetailtsToSimpleDto(lustrumLid.MemberDetails),
            Image = ImageToSimpleDto(lustrumLid.Image),
            Year = lustrumLid.Year,
        };
    }
    public static LustrumLidDto.Detailed LustrumLidToDetailedDto(LustrumLid lustrumLid)
    {
        return new LustrumLidDto.Detailed
        {
            Id = lustrumLid.Id,
            Member = MemberDetailtsToDetailedDto(lustrumLid.MemberDetails),
            Image = ImageToSimpleDto(lustrumLid.Image),
            Year = lustrumLid.Year,
        };
    }
    #endregion
   
    #endregion
}