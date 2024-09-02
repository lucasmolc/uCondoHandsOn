function ValidateEmail() {
    onNextStep();
}

function getMsalPopups() {
    // internal msal api: this may change in a future release
    if (!window.openedWindows) {
        window.openedWindows = [];
    }

    return window.openedWindows;
}

window.onclick = function (event) {
    const popUps = getMsalPopups();
    if (event.target == document.getElementById("modalMSAL") && popUps) {
        popUps.forEach((element) => {
            element.focus();
        });
    }
};

function onNextStep() {
    document.getElementById("loginContainer").style.animationName =
        "divLoginAnimation";
    document.getElementById("loginContainer").style.animationDuration = "0.6s";

    document.getElementById("TbUserName").readOnly = true;
    document.getElementById("formLogin").style.animationName = "opacityAnimation";
    document.getElementById("formLogin").style.animationDuration = "0.8s";

    document.getElementById("btnProximaEtapa").classList.add("d-none");
    document.getElementById("secondStepContainer").classList.remove("d-none");
    document.getElementById("btnVoltar").classList.remove("d-none");

    document.getElementById("banner").classList.remove("w-100");
    document.getElementById("banner").style.animationName =
        "widthReverseAnimation";
    document.getElementById("banner").style.animationDuration = "0.8s";
}

function OnPreviousStep() {
    hideErrorContainer();
    document.getElementById("loginContainer").style.animationName =
        "divLoginReverseAnimation";
    document.getElementById("loginContainer").style.animationDuration = "0.6s";

    document.getElementById("TbUserName").readOnly = false;
    document.getElementById("formLogin").style.animationName = "opacityReverseAnimation";
    document.getElementById("formLogin").style.animationDuration = "0.8s";

    document.getElementById("btnProximaEtapa").classList.remove("d-none");
    document.getElementById("secondStepContainer").classList.add("d-none");
    document.getElementById("btnVoltar").classList.add("d-none");

    document.getElementById("banner").style.animationName =
        "widthAnimation";
    document.getElementById("banner").style.animationDuration = "0.8s";

    setTimeout(function () {
        document.getElementById("banner").classList.add("w-100");
    }, 750);
}

function onViewPassword() {
    var canSeePassword =
        document.getElementById("TbPassword").type === "text" ? true : false;
    if (canSeePassword) {
        document.getElementById("TbPassword").type = "password";
        document
            .getElementById("viewPasswordIcon")
            .classList.replace("bi-eye", "bi-eye-slash");
    } else {
        document.getElementById("TbPassword").type = "text";
        document
            .getElementById("viewPasswordIcon")
            .classList.replace("bi-eye-slash", "bi-eye");
    }
}

function sendLoginForm() {
    var emailInput = document.getElementById("TbUserName");
    var passwordInput = document.getElementById("TbPassword");
    toggleLoginButton(true);
    $.ajax({
        type: "POST",
        url: "Default.aspx/doLogin",
        contentType: "application/json; charset=utf-8",
        async: false,
        data: JSON.stringify({
            TbUserName: emailInput.value,
            TbPassword: passwordInput.value,
        }),
    })
        .done(function (data) {
            var redirectURI = "";
            redirectURI = window.location.origin + "~/"

            window.location.assign(redirectURI);
        })
        .fail(function (error) {
            if (error.responseJSON.Message === "Informe uma senha válida!") {
                passwordInput.classList.add("is-invalid");
                $(".collapse").hide();
            } else {
                passwordInput.classList.remove("is-invalid");
                showErrorContainer(error.responseJSON.Message);
            }
            toggleLoginButton(false);
        });
}

function toggleLoginButton(disableButton) {
    document.getElementById('btnLogin').disable = disableButton;
    if (disableButton) {
        document.getElementById('btnLoginText').classList.add('d-none');
        document.getElementById('loadingSpinner').classList.remove('d-none');
    }
    else {
        document.getElementById('btnLoginText').classList.remove('d-none');
        document.getElementById('loadingSpinner').classList.add('d-none');
    }
}

function showErrorContainer(message) {
    $(".collapse").show();
    document.getElementById("erroField").innerHTML = message;
}

function hideErrorContainer() {
    $(".collapse").hide();
    document.getElementById("erroField").innerHTML = "";
}
