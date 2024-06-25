using GowBoard.Models.Context;
using GowBoard.Models.DTO.RequestDTO;
using GowBoard.Models.Service.Interface;
using System;
using System.Web.Mvc;

namespace GowBoard.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController() { }

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }


        // GET: Member
        public ActionResult Index()
        {
            return View();
        }

        // GET: Member/Register
        // 회원가입 페이지
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // Post: Member/Register
        // 회원가입
        [HttpPost]
        public ActionResult Register(ReqMemberDTO member)
        {

            var registered = _memberService.RegisterMember(member);

            return Json(new { success= registered.Success, message = registered.Message });

        }

        // POST: MEMBER/DuplicatedCheckId
        // 아이디 중복검사
        [HttpPost]
        public ActionResult DuplicatedCheckId(string memberId)
        {
            var isDuplicate = _memberService.DuplicatedCheckId(memberId);
            return Json(new { success = isDuplicate.Success, message = isDuplicate.Message});
        }

        // POST: MEMBER/DuplicatedCheckNickname
        // 아이디 중복검사
        [HttpPost]
        public ActionResult DuplicatedCheckNickname(string nickname)
        {
            var isDuplicate = _memberService.DuplicatedCheckNickname(nickname);
            return Json(new { success = isDuplicate.Success, message = isDuplicate.Message });
        }

        // GET: Member/LogIn
        // 로그인
        public ActionResult LogIn()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult LogIn(Member member) 
        //{
        //    var logInMember = _db.Members.FirstOrDefault(u => u.MemberId == member.MemberId && u.Password == member.Password);
        //    if (logInMember != null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    ModelState.AddModelError("", "Invalid username or password");
        //    return View(member);
        //}


        // GET: Member/FindId
        // 아이디 찾기
        public ActionResult FindId()
        {
            return View();
        }

        // GET: Member/NewPassword
        // 비밀번호 재설정
        public ActionResult NewPassword()
        {
            return View();
        }
    }
}