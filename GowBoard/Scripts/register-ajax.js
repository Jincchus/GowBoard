document.addEventListener('DOMContentLoaded', function () {

    // TODO: 클라이언트에서 넘어가는 값이 서버에서 인식해 볼 수가 없음 조사식에 REQUEST값을 확인 어떻게 파싱할지 
    let registerBtn = document.getElementById("register-ajax-btn");

    registerBtn.addEventListener('click', function () {

        const formData = new FormData(document.querySelector("#register-form"));

        fetch('/Member/Register', {
            method: "POST",
            body: JSON.stringify(formData)
        })
            .then((response) => {
                debugger;
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
            })
            .then(() => {
                window.location.href = '/Member/LogIn';
            })
            .catch(error => {
                console.error('Error:', error);
                return alert(response.json().Message);
            })
            .then(data => {
                if (data) {
                    alert(data.Message);
                } else {
                    alert("data else" + data.Message)
                }
            });

        /*
            .then(response => {
                response.text().then(function (text) {
                    console.log("response받아옴");
                    alert(text);
                });
        });
            */
    });

});