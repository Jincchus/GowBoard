using GowBoard.Models.DTO.RequestDTO;
using GowBoard.Models.DTO.ResponseDTO;
using System;
using System.Collections.Generic;

namespace GowBoard.Models.Service.Interface
{
    public interface IMemberService
    {
        RegisterResult RegisterMember(ReqMemberDTO member);

        RegisterResult DuplicatedCheckId(string memberId);

        RegisterResult DuplicatedCheckNickname(string nickname);

        RegisterResult DuplicatedCheckEmail(string nickname);

        Tuple<bool, string> SendAuthenticationEmail(string email);
    }
}
