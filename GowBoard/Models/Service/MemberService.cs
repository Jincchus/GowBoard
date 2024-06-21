using GowBoard.Models.Context;
using GowBoard.Models.DTO.RequestDTO;
using GowBoard.Models.Entity;
using GowBoard.Models.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GowBoard.Models.Service
{
    public class MemberService : IMemberService
    {
        private readonly GowBoardContext _context;
        
        public MemberService(GowBoardContext context)
        {
            _context = context;
        }

        public bool RegisterMember(ReqMemberDTO memberDto)
        {
            var member = new Member
            {
                MemberId = memberDto.Memberid,
                Password = memberDto.Password,
                Name = memberDto.Name,
                Email = memberDto.Email,
                Nickname = memberDto.Nickname,
                Phone = memberDto.Phone
            };

            // TODO : DB 권한 주기 -> CREATE DATABASE 사용권한 거부중
            _context.Members.Add(member);
            _context.SaveChanges();

            return true;
        }
    }
}