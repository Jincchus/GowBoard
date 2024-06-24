using GowBoard.Models.DTO.RequestDTO;
using GowBoard.Models.DTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GowBoard.Models.Service.Interface
{
    public interface IMemberService
    {
        RegisterResult RegisterMember(ReqMemberDTO member);
    }
}
