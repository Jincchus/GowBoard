using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GowBoard.Models.DTO.RequestDTO
{
    public class reqLoginDto
    {
        [Required(ErrorMessage ="ID를 입력하세요")]
        public string MemberId { get; set; }

        [Required(ErrorMessage ="패스워드를 입력하세요")]
        public string Password { get; set; }
    }
}