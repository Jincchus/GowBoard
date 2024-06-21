using GowBoard.Models.DTO.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GowBoard.Models.Service.Interface
{
    public interface IMemberService
    {
        bool RegisterMember(ReqMemberDTO member);
    }
}
