document.addEventListener('DOMContentLoaded', function () {

    // TODO: 클라이언트에서 넘어가는 값이 서버에서 인식해 볼 수가 없음 조사식에 REQUEST값을 확인 어떻게 파싱할지 
    const registerBtn = document.getElementById("register-ajax-btn");

    registerBtn.addEventListener('click', function (e) {

        e.preventDefault();

        if (!validationForm()) {
            return;
        }

        if (!window.validateDuplicationChecks()) {
            alert("아이디 또는 닉네임 중복확인이 필요합니다.");
            return;
        }

        const formData = new FormData(document.querySelector("#register-form"));

        let formDataObj = {};
        formData.forEach((value, key) => {
            formDataObj[key] = value;
        });

        fetch('/Member/Register', {
            method: "POST",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(formDataObj)
        })
            .then((response) => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }

                return response.json();
            })
            .then(data => {
                if (data.success) {
                    alert(data.message);
                    window.location.href = '/Member/LogIn';
                } else {
                    alert(data.message);
                }
            })
            .catch(error => {
                alert('catch error : ', error.message)
            });

    });

});