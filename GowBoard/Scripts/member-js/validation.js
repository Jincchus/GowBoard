document.addEventListener('DOMContentLoaded', function () {
    const memberId = document.querySelector("#MemberId");
    const password = document.querySelector("#Password");
    const chkPassword = document.querySelector("#passwordCheck");
    const email = document.querySelector("#Email");
    const name = document.querySelector("#Name");
    const nickname = document.querySelector("#Nickname");
    const phone = document.querySelector("#Phone");

    const idValidationTag = document.querySelector("#id-validation-text");
    const passValidationTag = document.querySelector("#pass-validation-text");
    const passCheckValidationIdTag = document.querySelector("#pass-check-validation-text");
    const emailValidationIdTag = document.querySelector("#email-validation-text");
    const nameValidationIdTag = document.querySelector("#name-validation-text");
    const nicknameValidationIdTag = document.querySelector("#nickname-validation-text");
    const phoneValidationIdTag = document.querySelector("#phone-validation-text");

    let validationPassed = {
        memberId: false,
        password: false,
        chkPassword: false,
        email: false,
        name: false,
        nickname: false,
        phone: false
    }
    // 아이디
    function validateMemberId() {
        const reUid = /^[a-zA-Z0-9]{4,12}$/;
        if (!memberId.value) {
            alert("아이디를 입력하세요.");
            memberId.focus();
            validationPassed.memberId = false;
        } else if (!reUid.test(memberId.value)) {
            idValidationTag.textContent = "사용 할 수 없는 아이디입니다.";
            idValidationTag.style.color = "red";
            validationPassed.memberId = false;
        } else if (reUid.test(memberId.value)) {
            idValidationTag.textContent = "사용 가능한 아이디입니다.";
            idValidationTag.style.color = "green";
            validationPassed.memberId = true;
        }
    }

    // 비밀번호
    function validatePassword() {
        const rePass = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$`~!@$!%*#^?&\\(\\)\-_=+]).{8,}$/;
        if (!password.value) {
            alert("비밀번호를 입력하세요.");
            password.focus();
            validationPassed.chkPassword = false;
        } else if (!rePass.test(password.value)) {
            passValidationTag.textContent = "사용 할 수 없는 비밀번호입니다.";
            passValidationTag.style.color = "red";
            password.focus();
            validationPassed.chkPassword = false;
        } else if (rePass.test(password.value)) {
            passValidationTag.textContent = "사용 가능한 비밀번호입니다.";
            passValidationTag.style.color = "green";
            validationPassed.chkPassword = true;
        }
    }

    // 비밀번호 체크
    function validatePasswordCheck() {
        if (!chkPassword.value) {
            alert("비밀번호 확인을 입력하세요.");
            chkPassword.focus();
            validationPassed.chkPassword = false;
        } else if (password.value !== chkPassword.value) {
            passCheckValidationIdTag.textContent = "비밀번호가 일치하지 않습니다.";
            passCheckValidationIdTag.style.color = "red";
            chkPassword.focus();
            validationPassed.chkPassword = false;
        } else if (password.value === chkPassword.value) {
            passCheckValidationIdTag.textContent = "비밀번호가 일치합니다.";
            passCheckValidationIdTag.style.color = "green";
            validationPassed.chkPassword = true;
        }
    }

    // 이메일
    function validateEmail() {
        const reEmail = /^[0-9a-zA-Z]([-_\.]?[0-9a-zA-Z])*@[0-9a-zA-Z]([-_\.]?[0-9a-zA-Z])*\.[a-zA-Z]{2,3}$/i;
        if (!email.value) {
            alert("이메일을 입력하세요.");
            email.focus();
            validationPassed.email = false;
        } else if (!reEmail.test(email.value)) {
            emailValidationIdTag.textContent = "사용 할 수 없는 이메일입니다.";
            emailValidationIdTag.style.color = "red";
            email.focus();
            validationPassed.email = false;
        } else if (reEmail.test(email.value)) {
            emailValidationIdTag.textContent = "사용 가능한 이메일입니다.";
            emailValidationIdTag.style.color = "green";
            validationPassed.email = true;
        }
    }
    // 이름
    function validateName() {
        const reName = /^[가-힣a-zA-Z]+$/;
        if (!name.value) {
            alert("이름을 입력하세요.");
            name.focus();
            validationPassed.name = false;
        } else if (!reName.test(name.value)) {
            nameValidationIdTag.textContent = "사용 할 수 없는 이름입니다.";
            nameValidationIdTag.style.color = "red";
            name.focus();
            validationPassed.name = false;
        } else if (reName.test(name.value)) {
            nameValidationIdTag.textContent = "사용 가능한 이름입니다.";
            nameValidationIdTag.style.color = "green";
            validationPassed.name = true;
        }
    }

    // 닉네임
    function validateNickname() {
        const reNick = /^[a-zA-Zㄱ-힣0-9][a-zA-Zㄱ-힣0-9]*$/;
        if (!nickname.value) {
            alert("닉네임을 입력하세요.");
            nickname.focus();
            validationPassed.nickname = false;
        } else if (!reNick.test(nickname.value)) {
            nicknameValidationIdTag.textContent = "사용 할 수 없는 닉네임입니다.";
            nicknameValidationIdTag.style.color = "red";
            nickname.focus();
            validationPassed.nickname = false;
        } else if (reNick.test(nickname.value)) {
            nicknameValidationIdTag.textContent = "사용 가능한 닉네임입니다.";
            nicknameValidationIdTag.style.color = "green";
            validationPassed.nickname = true;
        }
    }

    // 휴대폰
    function validatePhone() {
        const reHp = /^01(?:0|1|[6-9])-(?:\d{4})-\d{4}$/;
        if (!phone.value) {
            alert("휴대폰 번호를 입력하세요.");
            phone.focus();
            validationPassed.phone = false;
        } else if (!reHp.test(phone.value)) {
            phoneValidationIdTag.textContent = "사용 할 수 없는 휴대폰 번호입니다.";
            phoneValidationIdTag.style.color = "red";
            phone.focus();
            validationPassed.phone = false;
        } else if (reHp.test(phone.value)) {
            phoneValidationIdTag.textContent = "사용 가능한 휴대폰 번호입니다.";
            phoneValidationIdTag.style.color = "green";
            validationPassed.phone = true;
        }
    }

    memberId.addEventListener('input', validateMemberId);
    password.addEventListener('input', validatePassword);
    chkPassword.addEventListener('input', validatePasswordCheck);
    email.addEventListener('input', validateEmail);
    name.addEventListener('input', validateName);
    nickname.addEventListener('input', validateNickname);
    phone.addEventListener('input', validatePhone);

    function validateForm() {
        validateMemberId();
        validatePassword();
        validatePasswordCheck();
        validateEmail();
        validateName();
        validateNickname();
        validatePhone();


        return Object.values(validationPassed).every(val => val === true);
    }

    function checkEmptyFields() {
        if (!memberId.value || !password.value || !chkPassword.value || !email.value || !name.value || !nickname.value || !phone.value) {
            alert("모든 필수 항목을 입력하세요.");
            return false;
        }
        return true;
    }

    checkEmptyFields();

    window.checkEmptyFields = checkEmptyFields;
    window.validateForm = validateForm;





    return true;
});

///////////////////////////////////////////////////////// JS 클로저, 즉시실행함수

const validation = (() => {
    let isCheck = false;

    const memberId = document.querySelector("#MemberId");
    const password = document.querySelector("#Password");
    const chkPassword = document.querySelector("#passwordCheck");
    const email = document.querySelector("#Email");
    const name = document.querySelector("#Name");
    const nickname = document.querySelector("#Nickname");
    const phone = document.querySelector("#Phone");

    const idValidationTag = document.querySelector("#id-validation-text");
    const passValidationTag = document.querySelector("#pass-validation-text");
    const passCheckValidationIdTag = document.querySelector("#pass-check-validation-text");
    const emailValidationIdTag = document.querySelector("#email-validation-text");
    const nameValidationIdTag = document.querySelector("#name-validation-text");
    const nicknameValidationIdTag = document.querySelector("#nickname-validation-text");
    const phoneValidationIdTag = document.querySelector("#phone-validation-text");


    return {
        init: () => {
            memberId.addEventListener('input', validateMemberId);
            password.addEventListener('input', validatePassword);
            chkPassword.addEventListener('input', validatePasswordCheck);
            email.addEventListener('input', validateEmail);
            name.addEventListener('input', validateName);
            nickname.addEventListener('input', validateNickname);
            phone.addEventListener('input', validatePhone);
        },
        validation: () => {
            return false;
        }
    };

})();

const data = {
    init: function () {
        const _this = this;

        _this.validation();

    },
    validation: () => {
        return false;
    }


};
///////////////////////////////////////////////////