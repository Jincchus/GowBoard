using GowBoard.Models.DTO.RequestDTO;
using GowBoard.Models.DTO.ResponseDTO;

namespace GowBoard.Models.Service.Interface
{
    public interface IMemberService
    {
        RegisterResult RegisterMember(ReqMemberDTO member);

        RegisterResult DuplicatedCheckId(string memberId);

        RegisterResult DuplicatedCheckNickname(string nickname);
    }
}
