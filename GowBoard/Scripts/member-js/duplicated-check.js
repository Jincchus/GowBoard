document.addEventListener('DOMContentLoaded', function () {

    const idCheckBtn = document.querySelector("#id-check-ajax-btn");
    const nicknameCheckBtn = document.querySelector("#nick-check-ajax-btn");

    idCheckBtn.addEventListener('click', function () {
        const memberId = document.querySelector("#MemberId").value;

        fetch('/Member/DuplicatedCheckId', {
            method: "POST",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ MemberId: memberId })
        })
            .then((response) => {
                debugger
                if (!response.ok) {
                    throw new Error('Network response was not ok')
                }
                return response.json();
            })
            .then(data => {
                debugger
                console.log(data);

                const validationTag = document.querySelector("#id-validation-text");
                validationTag.textContent = data.message;
                validationTag.style.color = data.success ? 'green' : 'red';


            })

            .catch(error => {
                debugger
                console.error('Error:', error)
                alert('catch error : ', error.message)
            });

    });

    nicknameCheckBtn.addEventListener('click', function () {
        const nickname = document.querySelector("#Nickname").value;

        fetch('/Member/DuplicatedCheckNickname', {
            method: "POST",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ Nickname: nickname })
        })
            .then((response) => {
                debugger
                if (!response.ok) {
                    throw new Error('Network response was not ok')
                }
                return response.json();
            })
            .then(data => {
                debugger
                console.log(data);

                const validationTag = document.querySelector("#nickname-validation-text");
                validationTag.textContent = data.message;
                validationTag.style.color = data.success ? 'green' : 'red';


            })

            .catch(error => {
                debugger
                console.error('Error:', error)
                alert('catch error : ', error.message)
            });
    });












});