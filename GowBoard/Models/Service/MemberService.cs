using GowBoard.Models.Context;
using GowBoard.Models.DTO.RequestDTO;
using GowBoard.Models.DTO.ResponseDTO;
using GowBoard.Models.Entity;
using GowBoard.Models.Service.Interface;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace GowBoard.Models.Service
{
    public class MemberService : IMemberService
    {
        private readonly GowBoardContext _context;

        public MemberService(GowBoardContext context)
        {
            _context = context;
        }

        public RegisterResult RegisterMember(ReqMemberDTO memberDto)
        {
            var result = new RegisterResult{
                Success = true,
                Message = "회원가입에 성공했습니다."
            };

            if (!string.IsNullOrEmpty (memberDto.Memberid)
                || !string.IsNullOrEmpty(memberDto.Name) 
                || !string.IsNullOrEmpty( memberDto.Nickname) 
                || !string.IsNullOrEmpty (memberDto.Email)
                || !string.IsNullOrEmpty(memberDto.Password))
            {
                result.Success = false;
                result.Message = "빈 값은 입력 될 수 없습니다. 입력된 값을 확인해 주세요.";

                
                return result;
            }


            var memberContext = _context.Members;

            if (memberContext.Any(m => m.MemberId == memberDto.Memberid ||  m.Nickname == memberDto.Nickname))
            {
                result.Success = false;
                result.Message = "아이디 혹은 닉네임 중복 확인이 필요합니다.";

                return result;
            }

            if (memberContext.Any(m => m.Email == memberDto.Email))
            {
                result.Success = false;
                result.Message = "중복된 이메일입니다.";
            }


            try
            {
                var member = new Member
                {
                    MemberId = memberDto.Memberid,
                    Password = memberDto.Password,
                    Name = memberDto.Name,
                    Email = memberDto.Email,
                    Nickname = memberDto.Nickname,
                    Phone = memberDto.Phone,
                    CreatedAt = DateTime.Now // TODO : DATABASE Default : GETDATE();
                };

                _context.Members.Add(member);
                _context.SaveChanges();

                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "회원가입에 실패하였습니다. 다시 시도하여주십시오";

                return result;
            }

        }

    }
}