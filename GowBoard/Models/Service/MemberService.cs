using GowBoard.Models.Context;
using GowBoard.Models.DTO.RequestDTO;
using GowBoard.Models.DTO.ResponseDTO;
using GowBoard.Models.Entity;
using GowBoard.Models.Service.Interface;
using GowBoard.Models.Service.Utility;
using GowBoard.Utility;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.UI;

namespace GowBoard.Models.Service
{
    public class MemberService : IMemberService
    {
        private readonly GowBoardContext _context;
        private readonly PasswordHash _passwordHash;

        public MemberService(GowBoardContext context)
        {
            _context = context;
            _passwordHash = new PasswordHash();
        }

        public RegisterResult RegisterMember(ReqRegisterDTO register)
        {
            var result = new RegisterResult
            {
                Success = false,
                Message = "회원가입에 실패하였습니다. 다시 시도하여주십시오"
            };

            if (string.IsNullOrEmpty(register.Memberid)
                || string.IsNullOrEmpty(register.Name)
                || string.IsNullOrEmpty(register.Nickname)
                || string.IsNullOrEmpty(register.Email)
                || string.IsNullOrEmpty(register.Password))
            {
                result.Message = "빈 값은 입력 될 수 없습니다. 입력된 값을 확인해 주세요.";
                return result;
            }


            var memberContext = _context.Members;
            if (memberContext.Any(m => m.MemberId == register.Memberid || m.Nickname == register.Nickname))
            {
                result.Message = "아이디 혹은 닉네임 중복 확인이 필요합니다.";
                return result;
            }
            if (memberContext.Any(m => m.Email == register.Email))
            {
                result.Message = "중복된 이메일입니다.";
                return result;
            }

            try
            {
                string hashedPassword = _passwordHash.HashPassword(register.Password);

                var member = new Member
                {
                    MemberId = register.Memberid,
                    Password = hashedPassword,
                    Name = register.Name,
                    Email = register.Email,
                    Nickname = register.Nickname,
                    Phone = register.Phone,
                    CreatedAt = DateTime.Now // TODO : DATABASE Default : GETDATE();
                };

                _context.Members.Add(member);
                _context.SaveChanges();

                var memberRole = _context.Roles.FirstOrDefault(r => r.RoleName == "member");
                if(memberRole == null)
                {
                    memberRole = new Role { CreatedAt = DateTime.Now };
                    _context.Roles.Add(memberRole);
                    _context.SaveChanges();
                }

                var memberRoleMap = new MemberRoleMap
                {
                    MemberId = member.MemberId,
                    RoleId = memberRole.RoleId
                };
                _context.MemberRoleMaps.Add(memberRoleMap);
                _context.SaveChanges();

                result.Success = true;
                result.Message = "회원가입에 성공하였습니다";

                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }

        }

        public RegisterResult DuplicatedCheckId(string memberId)
        {
            var result = new RegisterResult
            {
                Success = false,
                Message = "회원가입에 실패하였습니다. 다시 시도하여주십시오"
            };

            var memberContext = _context.Members;
            if (memberContext.Any(m => m.MemberId == memberId))
            {
                result.Message = "이미 존재하는 아이디입니다.";
                return result;
            }

            result.Success = true;
            result.Message = "사용 가능한 아이디입니다";

            return result;
        }

        public RegisterResult DuplicatedCheckNickname(string nickname)
        {
            var result = new RegisterResult
            {
                Success = false,
                Message = "회원가입에 실패하였습니다. 다시 시도하여주십시오"
            };

            var memberContext = _context.Members;
            if (memberContext.Any(m => m.Nickname == nickname))
            {
                result.Message = "이미 존재하는 닉네임입니다.";
                return result;
            }

            result.Success = true;
            result.Message = "사용 가능한 닉네임 입니다";

            return result;
        }
        public RegisterResult DuplicatedCheckEmail(string email)
        {
            var result = new RegisterResult
            {
                Success = false,
                Message = "회원가입에 실패하였습니다. 다시 시도하여주십시오"
            };

            var memberContext = _context.Members;
            if (memberContext.Any(m => m.Email == email))
            {
                result.Message = "이미 존재하는 이메일입니다.";
                return result;
            }

            result.Success = true;
            result.Message = "사용 가능한 이메일 입니다";

            return result;
        }

        public Tuple<bool, string> SendAuthenticationEmail(string email)
        {
            string authNumber = AuthNumberGenerator.GenerateAuthNumber();

            string subject = "GowBoard 회원가입 인증번호입니다.";
            string body = $@"
                    <p>GowBoard 회원가입을 위한 인증번호를 요청하셨습니다</p>
                    <p>인증번호는 <strong>{authNumber}</strong></p>
                    <p>해당 인증번호를 입력하여 회원가입을 진행하여주십시오</p>
                    <p>감사합니다</p>";
            bool emailSent = EmailUtility.SendEmail(email, subject, body);

            return Tuple.Create(emailSent, authNumber);
        }

        public RegisterResult Login(ReqLoginDTO login)
        {
            var loginMember = _context.Members.FirstOrDefaultAsync(m => m.MemberId == login.MemberId && m.Password == login.Password);

            if (loginMember != null) 
            {
                Session["MemberId"] = loginMember.MemberId;
                return RedirectToAction("I")
            }


            return null;
        }
    }
}