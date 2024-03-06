var onloadCallback = function () {
    RCJS.scriptLoaded = true;
}

RCJS = {
    scriptLoaded: null,
    dotNetObjReference: null,
    divId: null,
    publicKey: null,
    Init: function (dotNetObjReference, divId, publicKey) {
        RCJS.dotNetObjReference = dotNetObjReference;
        RCJS.divId = divId;
        RCJS.publicKey = publicKey;

        if (RCJS.scriptLoaded === true) {
            RCJS.Render();
        } else {
            RCJS.WaitForRender();
        }
    },

    WaitForRender: function () {
        if (RCJS.scriptLoaded === true) {
            RCJS.Render();
        } else {
            setTimeout(() => RCJS.WaitForRender(), 100);    
        }
    },

    Render: function () {
        grecaptcha.render(RCJS.divId,
            {
                'sitekey': RCJS.publicKey,
                'callback': (response) => { RCJS.dotNetObjReference.invokeMethodAsync('RecaptchaSuccess', response); },
                'expired-callback': () => { RCJS.dotNetObjReference.invokeMethodAsync('RecaptchaExpired');  },
            });
    }
}