using GowBoard.Models.DTO.RequestDTO;
using GowBoard.Models.DTO.ResponseDTO;
using GowBoard.Models.Entity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GowBoard.Models.Service.Interface
{
    public interface IMemberService
    {
        RegisterResult RegisterMember(ReqRegisterrDTO registerDto);

        RegisterResult DuplicatedCheckId(string memberId);

        RegisterResult DuplicatedCheckNickname(string nickname);

        RegisterResult DuplicatedCheckEmail(string nickname);

        Tuple<bool, string> SendAuthenticationEmail(string email);

        Member Login(reqLoginDto loginDto);
        
        Member GetMemberById(string memberId);

        bool VerifyPassword(Member member, string password);
        void DeleteMember(string memberId);


    }
}
